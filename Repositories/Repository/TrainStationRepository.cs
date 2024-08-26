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

    public async Task Create(TrainStation model)
    {
        if (model is null)
        {
            throw new ArgumentNullException();
        }

        _dbContex.TrainStations.Add(model);
        await _dbContex.SaveChangesAsync();
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
}
