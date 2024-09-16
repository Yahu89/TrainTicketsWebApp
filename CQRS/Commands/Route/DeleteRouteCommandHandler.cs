using MediatR;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Commands.Route;

public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand>
{
    private readonly IRouteRepository _routeRepository;

    public DeleteRouteCommandHandler(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }
    public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
    {
        await _routeRepository.Delete(request.Id);
        return Unit.Value;
    }
}
