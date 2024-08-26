using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Commands.Route;

public class CreateRouteCommand : RouteDto, IRequest
{

}
