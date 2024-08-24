using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.TrainType;

public class GetAllTrainTypesQueryHandler : IRequestHandler<GetAllTrainTypesQuery, List<TrainTypeDto>>
{
	private readonly ITrainTypeRepository _trainTypeRepository;
	private readonly IMapper _mapper;
	public GetAllTrainTypesQueryHandler(ITrainTypeRepository trainTypeRepository, IMapper mapper)
    {
		_trainTypeRepository = trainTypeRepository;
		_mapper = mapper;
	}
    public async Task<List<TrainTypeDto>> Handle(GetAllTrainTypesQuery request, CancellationToken cancellationToken)
	{
		var trainTypes = await _trainTypeRepository.GetAll();
		var result = _mapper.Map<List<TrainTypeDto>>(trainTypes);
		return result;
	}
}
