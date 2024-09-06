using TrainTicketsWebApp.Database.Collections;

namespace TrainTicketsWebApp.Models.Dto;

public class TripOccupationDto : TripOccupation
{
	public TripOccupationDto(string tripId, int segmentsQty, int placesAvailable) : base(tripId, segmentsQty, placesAvailable)
	{

	}
}
