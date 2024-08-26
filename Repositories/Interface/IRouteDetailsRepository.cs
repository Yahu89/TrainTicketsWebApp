using TrainTicketsWebApp.Database.Entities;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface IRouteDetailsRepository
{
	Task CreateRange(List<RouteDetail> model);
	Task<List<RouteDetail>> GetRouteDetails(string routeName);
}
