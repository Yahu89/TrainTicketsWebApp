using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Commands.Route;

public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand>
{
	private readonly IRouteRepository _routeRepository;
	private readonly IMapper _mapper;

	public CreateRouteCommandHandler(IRouteRepository routeRepository, IMapper mapper)
    {
		_routeRepository = routeRepository;
		_mapper = mapper;
	}
    public async Task<Unit> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
	{
		var result = _mapper.Map<Database.Entities.Route>(request);
		await _routeRepository.Create(result);
		return Unit.Value;
	}
}
