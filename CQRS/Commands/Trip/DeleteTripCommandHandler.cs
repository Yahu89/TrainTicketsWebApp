using MediatR;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Commands.Trip;

public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand>
{
    private readonly ITripRepository _tripRepository;
    public DeleteTripCommandHandler(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }
    public async Task<Unit> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
    {
        await _tripRepository.Delete(request.TripId);
        return Unit.Value;
    }
}
