using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Entities;

namespace TrainTicketsWebApp.Database.Configuration;

public class Seeder
{
    private readonly TrainTicketsDbContext _dbContext;
    public Seeder(TrainTicketsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task SeedData()
    {
        await _dbContext.Database.MigrateAsync();

        if (!_dbContext.TrainStations.Any())
        {
            await SeedTrainStations();
        }

        if (!_dbContext.TrainTypes.Any())
        {
            await SeedTrainTypes();
        }

        if (!_dbContext.Routes.Any())
        {
            await SeedRoutes();
        }
    }

    private async Task SeedRoutes()
    {
        List<Entities.Route> Routes = new List<Entities.Route>()
        {
            new Entities.Route()
            {
                Name = "GDA - WAW 01",
                Description = "Gdańsk - Warszawa (Wszystkie stacje)"
            },

            new Entities.Route()
            {
                Name = "POZ - WAW 02",
                Description = "Poznań - Warszawa (Skrócona)"
            }
        };

        _dbContext.Routes.AddRange(Routes);
        await _dbContext.SaveChangesAsync();
    }

    private async Task SeedTrainStations()
    {
        List<TrainStation> Stations = new List<TrainStation>()
        {
            new TrainStation()
            {
                Station = "Gdańsk"
            },

            new TrainStation()
            {
                Station = "Warszawa"
            },

            new TrainStation()
            {
                Station = "Poznań"
            },

            new TrainStation()
            {
                Station = "Tczew"
            },

            new TrainStation()
            {
                Station = "Laskowice Pomorskie"
            },

            new TrainStation()
            {
                Station = "Bydgoszcz"
            },

            new TrainStation()
            {
                Station = "Malbork"
            },

            new TrainStation()
            {
                Station = "Iława"
            },

            new TrainStation()
            {
                Station = "Działdowo"
            },

            new TrainStation()
            {
                Station = "Nowy Dwór Mazowiecki"
            },

            new TrainStation()
            {
                Station = "Swarzędz"
            },

            new TrainStation()
            {
                Station = "Września"
            },

            new TrainStation()
            {
                Station = "Konin"
            },

            new TrainStation()
            {
                Station = "Kutno"
            },

            new TrainStation()
            {
                Station = "Koło"
            },

            new TrainStation()
            {
                Station = "Łowicz"
            }
        };

        _dbContext.TrainStations.AddRange(Stations);
        await _dbContext.SaveChangesAsync();
    }

    private async Task SeedTrainTypes()
    {
        List<TrainType> TrainTypes = new List<TrainType>()
        {
            new TrainType()
            {
                LongName = "Inter City",
                ShortName = "IC",
                TotalPlacesAvailable = 300,
                Speed = 160
            },

            new TrainType()
            {
                LongName = "Inter City Premium",
                ShortName = "ICP",
                TotalPlacesAvailable = 500,
                Speed = 200
            }
        };

        _dbContext.TrainTypes.AddRange(TrainTypes);
        await _dbContext.SaveChangesAsync();
    }
}
