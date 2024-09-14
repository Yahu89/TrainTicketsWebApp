using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface ITrainStationRepository
{
    Task<int> GetAllStationsQty();
    Task<List<TrainStation>> GetAll();
    Task<List<TrainStation>> GetAllPaginated(int page, int pageSize);
    Task Create(TrainStation trainStation);
    Task<int> CreateRange(List<TrainStation> trainStationList);
    Task<RouteDetailsCreationView> GetRouteDetailsCreationView();
    Task<bool> IsStationAlreadyUsed(string station);
    Task Delete(string trainStation);
}
