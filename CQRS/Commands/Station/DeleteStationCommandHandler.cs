using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Commands.Station;

public class DeleteStationCommandHandler : IRequestHandler<DeleteStationCommand>
{
    private readonly ITrainStationRepository _trainStationRepository;
    private readonly IMapper _mapper;
    public DeleteStationCommandHandler(ITrainStationRepository trainStationRepository, IMapper mapper)
    {
        _trainStationRepository = trainStationRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteStationCommand request, CancellationToken cancellationToken)
    {
        //var station = _mapper.Map<TrainStation>(request);

        await _trainStationRepository.Delete(request.StationName);
        return Unit.Value;
    }
}
