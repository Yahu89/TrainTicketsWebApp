using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Repositories.Repository;

public class TourRepository : ITourRepository
{
	private readonly TrainTicketsDbContext _dbContext;
	public TourRepository(TrainTicketsDbContext dbContext)
    {
		_dbContext = dbContext;
	}

	public async Task CreateReservation(Reservation reservation)
	{
		if (reservation == null)
		{
			throw new ArgumentNullException(nameof(reservation));
		}

		_dbContext.Reservations.Add(reservation);
		await _dbContext.SaveChangesAsync();
	}
}
