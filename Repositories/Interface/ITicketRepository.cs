using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface ITicketRepository
{
    Task<List<Reservation>> GetReservationsBySearch(SearchReservationDto dto);
}
