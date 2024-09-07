using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Repositories.Repository;

public class ScheduleRepository : IScheduleRepository
{
	private readonly TrainTicketsDbContext _dbContex;
	private readonly ITripOccupationRepository _tripOccupationRepository;
	private readonly IMapper _mapper;

	public ScheduleRepository(TrainTicketsDbContext dbContex, 
								ITripOccupationRepository tripOccupationRepository,
								IMapper mapper)
    {
		_dbContex = dbContex;
		_tripOccupationRepository = tripOccupationRepository;
		_mapper = mapper;
	}
    public async Task CreateRange(List<Schedule> schedules)
	{
		if (schedules is null)
		{
			throw new ArgumentNullException(nameof(schedules));
		}

		_dbContex.Schedules.AddRange(schedules);
		await _dbContex.SaveChangesAsync();
	}

	public async Task<List<ScheduleDto>> GenerateSchedules(List<Trip> trips)
	{
		List<ScheduleDto> schedules = new List<ScheduleDto>();
		var idList = trips.Select(x => x.Id).ToList();
		var tripsWithReferences = await _dbContex.Trips
								.Include(x => x.Route)
								.ThenInclude(x => x.RouteDetails)
								.Where(x => idList.Contains(x.Id))
								.ToListAsync();

		foreach (var trip in tripsWithReferences)
		{
			DateTime begin = trip.DepartureTime;

			foreach (var routeDetail in trip.Route.RouteDetails)
			{
				var departureTime = trip.DepartureTime;
				var arrivalTime = begin.AddMinutes(CalculateSingleSectionTime(routeDetail.Distance, routeDetail.MaxSpeed));

				ScheduleDto newSchedule = new ScheduleDto()
				{
					TripId = trip.Id,
					From = routeDetail.From,
					To = routeDetail.To,
					DepartureTime = begin,
					ArrivalTime = arrivalTime
				};

				begin = begin.AddMinutes(CalculateSingleSectionTime(routeDetail.Distance, routeDetail.MaxSpeed));
				schedules.Add(newSchedule);
			}
		}

		return schedules;
	}

	public async Task<List<SearchTourResult>> GetFoundTours(SearchTourDto tour)
	{
		List<ScheduleDto> toursByDateAndFrom = new List<ScheduleDto>();

		var day = DateTime.Parse($"{tour.DepartureDay.ToString("yyyy-MM-dd")} {tour.DepartureTime}");
		var endOfDay = new DateTime(day.Year, day.Month, day.Day, 23, 59, 0);

		toursByDateAndFrom = _mapper.Map<List<ScheduleDto>>(await _dbContex.Schedules.Include(x => x.Trip)
			.Where(x => x.DepartureTime >= day && x.DepartureTime <= endOfDay)			
			.Where(x => x.From.Equals(tour.From)).ToListAsync());

		if (!toursByDateAndFrom.Any() )
		{
			return new List<SearchTourResult>();
		}

		List<SearchTourResult> finalResults = new List<SearchTourResult>();

		for (int i = 0; i <  toursByDateAndFrom.Count; i++)
		{
			var toursByTo = await _dbContex.Schedules.Include(x => x.Trip)
													 .ThenInclude(x => x.Route)
													 .ThenInclude(x => x.RouteDetails)
													 .Where(x => x.TripId == toursByDateAndFrom[i].TripId)
													 .FirstOrDefaultAsync(x => x.To.Equals(tour.To));

			if (toursByTo == null)
			{
				continue;
			}

			SearchTourResult element = new SearchTourResult()
			{
				TripId = toursByDateAndFrom[i].TripId,
				From = tour.From,
				To = toursByTo.To,
				DepartureTime = toursByDateAndFrom[i].DepartureTime,
				ArrivalTime = toursByTo.ArrivalTime,
				TrainType = toursByDateAndFrom[i].Trip.TrainTypeName,
				SegmentNumberFrom = toursByTo.Trip.Route.RouteDetails.Where(x => x.From.Equals(toursByDateAndFrom[i].From))
																	 .Select(x => x.SegmentNumber)
																	 .FirstOrDefault(),
				SegmentNumberTo = toursByTo.Trip.Route.RouteDetails.Where(x => x.To.Equals(toursByTo.To))
																	 .Select(x => x.SegmentNumber)
																	 .FirstOrDefault(),
			};

			finalResults.Add(element);
		}

		var placesAvailable = await _tripOccupationRepository.CalculateRemainPlacesList(finalResults);

		if (finalResults.Count == placesAvailable.Count)
		{
			for (int i = 0; i < placesAvailable.Count; i++)
			{
				finalResults[i].PlacesAvailable = placesAvailable[i];
			}
		}

		return finalResults;
	}

	private int CalculateSingleSectionTime(int distance, int speed)
	{
		double divide = (distance / (double)speed);
		int result = (int)(divide * 60);

		return result;
	}
}
