using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.Tour;

public class SearchingTourViewQuery : IRequest<RouteDetailsCreationView>
{

}
