using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Repositories.Repository;

public class TripRepository : ITripRepository
{
	private readonly TrainTicketsDbContext _dbContex;
	public TripRepository(TrainTicketsDbContext dbContex)
    {
		_dbContex = dbContex;
	}

	public async Task<List<Trip>> CreateRange(List<Trip> trips)
	{
		if (trips is null)
		{
			throw new ArgumentNullException(nameof(trips));
		}

		_dbContex.Trips.AddRange(trips);
		await _dbContex.SaveChangesAsync();

		var idList = trips.Select(x => x.Id).ToList();

		List<Trip> tripList = new List<Trip>();

		foreach (var id in idList)
		{
			var trip = await _dbContex.Trips.Include(x => x.TrainType)
											.Include(x => x.Route.RouteDetails)
											.FirstOrDefaultAsync(x => x.Id == id);
			tripList.Add(trip);
		}

		return tripList;
	}

	public async Task<TripCreationView> GetTripCreationView()
	{
		TripCreationView view = new TripCreationView()
		{
			Routes = await GetRoutes(),
			TrainTypes = await GetTrainTypes()
		};

		return view;
	}

	public async Task<List<Trip>> GetAllTripsPaginated(int itemsPerPage = 20, int currentPageNumber = 1)
	{
		int totalRecords = _dbContex.Trips.Count();
		var result = await _dbContex.Trips.Include(x => x.Route)
									.Skip(itemsPerPage * (currentPageNumber - 1))
									.Take(itemsPerPage)
									.OrderBy(x => x.DepartureTime)
									.ToListAsync();

		return result;
	}

	public async Task<int> AllTripsQty()
	{
		return await _dbContex.Trips.CountAsync();
	}

	private async Task<List<SelectListItem>> GetRoutes()
	{
		var routes = await _dbContex.Routes.Select(x => new SelectListItem()
		{
			Text = x.Name,
			Value = x.Id.ToString()
		}).ToListAsync();

		return routes;
	}

	private async Task<List<SelectListItem>> GetTrainTypes()
	{
		var trainTypes = await _dbContex.TrainTypes.Select(x => new SelectListItem()
		{
			Text = x.ShortName,
			Value = x.ShortName
		}).ToListAsync();

		return trainTypes;
	}
}
