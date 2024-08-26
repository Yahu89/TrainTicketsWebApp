using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Repositories.Repository;

public class ScheduleRepository : IScheduleRepository
{
	private readonly TrainTicketsDbContext _dbContex;
	public ScheduleRepository(TrainTicketsDbContext dbContex)
    {
		_dbContex = dbContex;
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

	public async Task<List<Schedule>> GenerateSchedules(List<Trip> trips)
	{
		List<Schedule> schedules = new List<Schedule>();
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
				Schedule newSchedule = new Schedule()
				{
					TripId = trip.Id,
					From = routeDetail.From,
					To = routeDetail.To,
					DepartureTime = begin
				};

				begin = begin.AddMinutes(CalculateSingleSectionTime(routeDetail.Distance, routeDetail.MaxSpeed));
				schedules.Add(newSchedule);
			}
		}

		return schedules;
	}

	private int CalculateSingleSectionTime(int distance, int speed)
	{
		double divide = (distance / (double)speed);
		int result = (int)(divide * 60);

		return result;
	}
}
