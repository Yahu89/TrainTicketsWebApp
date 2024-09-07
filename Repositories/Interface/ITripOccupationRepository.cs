using TrainTicketsWebApp.Database.Collections;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface ITripOccupationRepository
{
	Task CreateTripOccupation(TripOccupation tripOccupation);
	Task<List<int>> CalculateRemainPlacesList(List<SearchTourResult> searchTourResults);
	//Task<TripOccupation> GetTrip();
	//Task CreateDocument(T doc);
}
