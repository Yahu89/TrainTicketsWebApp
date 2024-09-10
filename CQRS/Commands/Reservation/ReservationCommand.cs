using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Commands.Reservation;

public class ReservationCommand : ReservationDto, IRequest
{
    public ReservationCommand(ReservationDto dto)
    {
        TripId = dto.TripId; 
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        Email = dto.Email;
        From = dto.From;
        To = dto.To;
        DepartureTime = dto.DepartureTime;
        ArrivalTime = dto.ArrivalTime;
        TrainType = dto.TrainType;
        SegmentNumberFrom = dto.SegmentNumberFrom;
        SegmentNumberTo = dto.SegmentNumberTo;
    }
}
