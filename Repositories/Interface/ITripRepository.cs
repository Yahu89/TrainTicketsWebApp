using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface ITripRepository
{
	Task<List<int>> CreateRange(List<Trip> model);
	Task<TripCreationView> GetTripCreationView();
	Task<List<Trip>> GetAllTripsPaginated(int page, int pageSize);
	Task<int> AllTripsQty();
}
