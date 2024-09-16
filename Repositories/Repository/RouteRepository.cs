using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Repositories.Repository;

public class RouteRepository : IRouteRepository
{
	private readonly TrainTicketsDbContext _dbContext;
	public RouteRepository(TrainTicketsDbContext dbContext)
    {
		_dbContext = dbContext;
	}
    public async Task<List<Database.Entities.Route>> GetAll()
	{
		var results = await _dbContext.Routes.ToListAsync();
		return results;
	}

	public async Task Create(Database.Entities.Route route)
	{
		if (route is null)
		{
			throw new ArgumentNullException(nameof(route));
		}

		_dbContext.Routes.Add(route);
		await _dbContext.SaveChangesAsync();
	}

	public async Task Delete(int routeId)
	{
		var route = _dbContext.Routes.FirstOrDefault(x => x.Id == routeId);
		_dbContext.Routes.Remove(route);
		await _dbContext.SaveChangesAsync();
	}
}
