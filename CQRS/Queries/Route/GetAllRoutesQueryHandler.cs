using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.Route;

public class GetAllRoutesQueryHandler : IRequestHandler<GetAllRoutesQuery, List<RouteDto>>
{
	private readonly IRouteRepository _routeRepository;
	private readonly IMapper _mapper;

	public GetAllRoutesQueryHandler(IRouteRepository routeRepository, IMapper mapper)
    {
		_routeRepository = routeRepository;
		_mapper = mapper;
	}
    public async Task<List<RouteDto>> Handle(GetAllRoutesQuery request, CancellationToken cancellationToken)
	{
		var routes = await _routeRepository.GetAll();
		var results = _mapper.Map<List<RouteDto>>(routes);
		return results;
	}
}
