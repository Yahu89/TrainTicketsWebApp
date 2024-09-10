using TrainTicketsWebApp.Database.Entities;

namespace TrainTicketsWebApp.Repositories.Interface;

public interface ITourRepository
{
	Task CreateReservation(Reservation reservation);
}
