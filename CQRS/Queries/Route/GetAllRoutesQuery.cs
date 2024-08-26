using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.Route;

public class GetAllRoutesQuery : IRequest<List<RouteDto>>
{

}
