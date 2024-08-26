using MediatR;

namespace TrainTicketsWebApp.CQRS.Commands.TrainType;

public class CreateTrainTypeCommand : IRequest
{
	public string LongName { get; set; }
	public string ShortName { get; set; }
	public int TotalPlacesAvailable { get; set; }
	public int Speed { get; set; }
}
