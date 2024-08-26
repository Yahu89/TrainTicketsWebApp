using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Commands.Trip;

public class CreateTripsCommand : IRequest
{
    public IEnumerable<CreateTripsDto> trips { get; set; }
    public CreateTripsCommand(IEnumerable<CreateTripsDto> model)
    {
        trips = model;
    }
}
