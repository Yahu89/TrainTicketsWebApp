using Microsoft.EntityFrameworkCore;
using System.Collections;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Repositories.Repository;

public class TicketRepository : ITicketRepository
{
    private readonly TrainTicketsDbContext _dbContex;

    public TicketRepository(TrainTicketsDbContext dbContex)
    {
        _dbContex = dbContex;
    }

    public async Task<List<Reservation>> GetReservationsBySearch(SearchReservationDto model)
    {
        List<Reservation> results = await _dbContex.Reservations.ToListAsync();

        ArrayList array = new ArrayList();
        array.Add(model.ReservationId);
        array.Add(model.Email);

        bool correctFormFilled = false;

        for (int i = 0; i < array.Count; i++)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(array[i])))
            {
                correctFormFilled = true;

                switch (i)
                {
                    case 0:
                        {
                            results = results.Where(x => x.Id == (int)array[i]).ToList();
                            break;
                        }

                    case 1:
                        {
                            results = results.Where(x => x.Email.Equals(array[i])).ToList();
                            break;
                        }
                }
            }

        }

        if (!correctFormFilled)
        {
            return new List<Reservation>();
        }

        return results;
    }
}
