using TrainTicketsWebApp.Database.Entities;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface IScheduleRepository
{
	Task CreateRange(List<Schedule> schedules);
	Task<List<Schedule>> GenerateSchedules(List<Trip> trips);
}
