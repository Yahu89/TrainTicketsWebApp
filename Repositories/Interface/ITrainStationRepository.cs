using TrainTicketsWebApp.Database.Entities;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface ITrainStationRepository
{
    Task<List<TrainStation>> GetAll();
    Task Create(TrainStation trainStation);
}
