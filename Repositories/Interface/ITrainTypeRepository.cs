using TrainTicketsWebApp.Database.Entities;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface ITrainTypeRepository
{
	Task<List<TrainType>> GetAll();
	Task Create(TrainType trainType);
}
