using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
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
}
