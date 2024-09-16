using MediatR;

namespace TrainTicketsWebApp.CQRS.Commands.Trip;

public class DeleteTripCommand : IRequest
{
    public int TripId { get; set; }
    public DeleteTripCommand(int tripId)
    {
        TripId = tripId;
    }
}
