using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Commands.RouteDetails;

public class CreateRouteDetailsCommand : IRequest
{
    public List<CreateRouteDetailsDto> RouteDetailsDtos { get; set; }
    public CreateRouteDetailsCommand(List<CreateRouteDetailsDto> list)
    {
        RouteDetailsDtos = list;
    }
}
