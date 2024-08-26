using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Commands.TrainType;

public class CreateTrainTypeCommandHandler : IRequestHandler<CreateTrainTypeCommand>
{
	private readonly ITrainTypeRepository _trainTypeRepository;
	private readonly IMapper _mapper;
	public CreateTrainTypeCommandHandler(ITrainTypeRepository trainTypeRepository, IMapper mapper)
    {
		_trainTypeRepository = trainTypeRepository;
		_mapper = mapper;
	}
    public async Task<Unit> Handle(CreateTrainTypeCommand request, CancellationToken cancellationToken)
	{
		var result = _mapper.Map<Database.Entities.TrainType>(request);
		await _trainTypeRepository.Create(result);
		return Unit.Value;
	}
}
