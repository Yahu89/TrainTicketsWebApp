using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Repositories.Repository;

public class TrainTypeRepository : ITrainTypeRepository
{
	private readonly TrainTicketsDbContext _dbContext;
	public TrainTypeRepository(TrainTicketsDbContext dbContext)
    {
		_dbContext = dbContext;
	}

	public async Task<List<TrainType>> GetAll()
	{
		var results = await _dbContext.TrainTypes.ToListAsync();
		return results;
	}
}
