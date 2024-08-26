namespace TrainTicketsWebApp.Repositories.Interface;

public interface IRouteRepository
{
	Task<List<Database.Entities.Route>> GetAll();
	Task Create(Database.Entities.Route route);
}
