using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Repositories.Repository;

public class TrainStationRepository : ITrainStationRepository
{
    private readonly TrainTicketsDbContext _dbContex;
    public TrainStationRepository(TrainTicketsDbContext dbContex)
    {
        _dbContex = dbContex;
    }

    public async Task<List<TrainStation>> GetAll()
    {
        var result = await _dbContex.TrainStations.ToListAsync();
        return result;
    }

    public async Task<int> GetAllStationsQty()
    {
        return await _dbContex.TrainStations.CountAsync();
    }
	public async Task<List<TrainStation>> GetAllPaginated(int currentPage = 1, int itemsPerPage = 10)
	{
        var result = _dbContex.TrainStations.OrderBy(x => x.Station)
                                            .Skip((currentPage - 1) * itemsPerPage)
                                            .Take(itemsPerPage)
                                            .ToList();

		return result;
	}


	public async Task Create(TrainStation model)
    {
        if (model is null)
        {
            throw new ArgumentNullException();
        }

        _dbContex.TrainStations.Add(model);
        await _dbContex.SaveChangesAsync();
    }

    public async Task<int> CreateRange(List<TrainStation> model)
    {
        if (model is null)
        {
            throw new ArgumentNullException();
        }

        int counter = 0;

        foreach (var item in model)
        {
            if (_dbContex.TrainStations.Contains(item))
            {
                continue;
            }

            _dbContex.TrainStations.Add(item);
            counter++;
        }

        try
        {
            await _dbContex.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }

        return counter;
    }

    public async Task<RouteDetailsCreationView> GetRouteDetailsCreationView()
    {
        RouteDetailsCreationView view = new RouteDetailsCreationView()
        {
            Routes = await GetRoutes(),
            From = await GetStations(),
            To = await GetStations()
        };

        return view;
    }

    private async Task<List<SelectListItem>> GetStations()
    {
        var routes = await GetAll();
        var result = routes.Select(x => new SelectListItem()
        {
            Text = x.Station,
            Value = x.Station
        }).ToList();

        return result;
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

    public async Task<bool> IsStationAlreadyUsed(string station)
    {
        var stations = await _dbContex.RouteDetails.Where(x => x.From.Contains(station) ||  x.To.Contains(station))
                                                    .CountAsync();

        return stations > 0;
    }

    public async Task Delete(string station)
    {
        TrainStation data = new TrainStation() { Station = station };
        _dbContex.TrainStations.Remove(data);
        await _dbContex.SaveChangesAsync();
    }
}