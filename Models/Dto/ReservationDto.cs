using TrainTicketsWebApp.Database.Entities;

namespace TrainTicketsWebApp.Models.Dto;

public class ReservationDto : Reservation
{
	public int SegmentNumberFrom { get; set; }
	public int SegmentNumberTo { get; set; }
}
