using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Repositories.Repository;

public class RouteDetailsRepository : IRouteDetailsRepository
{
	private readonly TrainTicketsDbContext _dbContext;
	public RouteDetailsRepository(TrainTicketsDbContext dbContext)
    {
		_dbContext = dbContext;
	}

	public async Task CreateRange(List<RouteDetail> model)
	{
		if (model is null)
		{
			throw new ArgumentNullException(nameof(model));
		}

		_dbContext.RouteDetails.AddRange(model);
		await _dbContext.SaveChangesAsync();
	}

	public async Task<List<RouteDetail>> GetRouteDetails(string routeName)
	{
		var result = await _dbContext.RouteDetails.Include(x => x.Routes)
									.Where(x => x.Routes.Name.Equals(routeName))
									.ToListAsync();

		return result;
	}
}
