using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.Trip;

public class GetAllTripsCreationViewQuery : TripCreationView, IRequest<TripCreationView>
{

}
