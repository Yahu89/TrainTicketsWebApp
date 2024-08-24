using MediatR;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Commands.Station;

public class CreateTrainStationCommandHandler : IRequestHandler<CreateTrainStationCommand>
{
	private readonly ITrainStationRepository _trainStationRepository;

	public CreateTrainStationCommandHandler(ITrainStationRepository trainStationRepository)
    {
		_trainStationRepository = trainStationRepository;
	}
    public async Task<Unit> Handle(CreateTrainStationCommand request, CancellationToken cancellationToken)
	{
		//TrainStation station = new TrainStation();
		//station.Station = request.Station;
		await _trainStationRepository.Create(request);
		return Unit.Value;
	}
}
