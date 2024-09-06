using TrainTicketsWebApp.Database.Configuration;

namespace TrainTicketsWebApp.Repositories.Repository;

public class TourRepository
{
	private readonly TrainTicketsDbContext _dbContext;
	public TourRepository(TrainTicketsDbContext dbContext)
    {
		_dbContext = dbContext;
	}


}
