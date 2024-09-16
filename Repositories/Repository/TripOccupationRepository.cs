using MongoDB.Bson;
using MongoDB.Driver;
using TrainTicketsWebApp.Database.Collections;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Repositories.Repository;

public class TripOccupationRepository : ITripOccupationRepository
{
	private readonly IMongoCollection<TripOccupation> _tripOccupation;
	public TripOccupationRepository(IMongoDatabase mongoDatabase)
    {
		_tripOccupation = mongoDatabase.GetCollection<TripOccupation>("TripOccupation");
	}

	public async Task CreateTripOccupation(TripOccupation dto)
	{
		await _tripOccupation.InsertOneAsync(dto);
	}

	public async Task<List<int>> CalculateRemainPlacesList(List<SearchTourResult> tours)
	{
		List<int> placesAvailable = new List<int>();

		foreach (var tour in tours)
		{
			var tripId = tour.TripId;
			var filter = Builders<TripOccupation>.Filter.Eq("_id", tripId.ToString());
			var tripOccupation = await _tripOccupation.Find(filter).FirstOrDefaultAsync();
			
			placesAvailable.Add(CalculatePlacesAvailable(tripOccupation.OccupationMatrix, 
														tour.SegmentNumberFrom, 
														tour.SegmentNumberTo));

		}

		return placesAvailable;
	}

	private int CalculatePlacesAvailable(bool[,] matrix, int startSegment, int stopSegment)
	{
		int places = 0;

		for (int i = 0; i < matrix.GetLength(1); i++)
		{
			for (int j = startSegment; j <= stopSegment; j++)
			{
				if (matrix[j - 1, i] != false)
				{
					break;
				}

				if (j == stopSegment)
				{
					places++;
				}
			}
		}

		return places;
	}

	public async Task<int> ReservePlace(ReservationDto dto)
	{
		var tripId = dto.TripId;
		var filter = Builders<TripOccupation>.Filter.Eq("_id", tripId.ToString());
		var tripOccupation = await _tripOccupation.Find(filter).FirstOrDefaultAsync();
		var matrix = tripOccupation.OccupationMatrix;
		int placeNumber = 0;

		if (CalculatePlacesAvailable(tripOccupation.OccupationMatrix, dto.SegmentNumberFrom, dto.SegmentNumberTo) <= 0)
        {
			throw new Exception();
        }

		for (int i = 0; i < matrix.GetLength(1); i++)
		{
			int start = dto.SegmentNumberFrom - 1;

			for (int j = dto.SegmentNumberFrom; j <= dto.SegmentNumberTo; j++)
			{
				if (matrix[j - 1, i] != false)
				{
					break;
				}

				start++;
			}

			if (start == dto.SegmentNumberTo)
			{
				for (int k = dto.SegmentNumberFrom;  k <= dto.SegmentNumberTo; k++)
				{
					matrix[k - 1, i] = true;
				}

				placeNumber = i + 1;

				break;
			}
		}

		tripOccupation.OccupationMatrix = matrix;		

		await _tripOccupation.ReplaceOneAsync(filter, tripOccupation);

		return placeNumber;
    }

}
