using MediatR;

namespace TrainTicketsWebApp.CQRS.Commands.Route;

public class DeleteRouteCommand : IRequest
{
    public int Id { get; set; }
    public DeleteRouteCommand(int id)
    {
        Id = id;
    }
}
