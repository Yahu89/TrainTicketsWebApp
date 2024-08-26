using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.RouteDetails;

public class GetRouteDetailDtoQueryHandler : IRequestHandler<GetRouteDetailQuery, List<RouteDetailDto>>
{
	private readonly IRouteDetailsRepository _routeDetailsRepository;
	private readonly IMapper _mapper;

	public GetRouteDetailDtoQueryHandler(IRouteDetailsRepository routeDetailsRepository, IMapper mapper)
    {
		_routeDetailsRepository = routeDetailsRepository;
		_mapper = mapper;
	}
    public async Task<List<RouteDetailDto>> Handle(GetRouteDetailQuery request, CancellationToken cancellationToken)
	{
		var routeDetails = await _routeDetailsRepository.GetRouteDetails(request.RouteName);
		var result = _mapper.Map<List<RouteDetailDto>>(routeDetails);
		return result;
	}
}
