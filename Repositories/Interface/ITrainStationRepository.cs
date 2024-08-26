using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface ITrainStationRepository
{
    Task<List<TrainStation>> GetAll();
    Task Create(TrainStation trainStation);
    Task<RouteDetailsCreationView> GetRouteDetailsCreationView();
}
