using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface IScheduleRepository
{
	Task CreateRange(List<Schedule> schedules);
	Task<List<Schedule>> GenerateSchedules(List<Trip> trips);
	Task<List<SearchTourResult>> GetFoundTours(SearchTourDto schedules);
}
