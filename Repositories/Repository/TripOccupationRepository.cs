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
				if (matrix[j, i] != false)
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

	//public async Task<TripOccupation> GetTrip()
	//{
	//	var filter = Builders<TripOccupation>.Filter.Eq("_id", "79");
	//	var tripOccupation = await _tripOccupation.Find(filter).FirstOrDefaultAsync();
	//	return tripOccupation;
	//}
}
