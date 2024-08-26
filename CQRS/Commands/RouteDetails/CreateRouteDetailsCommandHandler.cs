using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Commands.RouteDetails;

public class CreateRouteDetailsCommandHandler : IRequestHandler<CreateRouteDetailsCommand>
{
	private readonly IRouteDetailsRepository _routeDetailsRepository;
	private readonly IMapper _mapper;
	public CreateRouteDetailsCommandHandler(IRouteDetailsRepository routeDetailsRepository, IMapper mapper)
    {
		_routeDetailsRepository = routeDetailsRepository;
		_mapper = mapper;
	}
    public async Task<Unit> Handle(CreateRouteDetailsCommand request, CancellationToken cancellationToken)
	{
		var routeDetails = _mapper.Map<List<RouteDetail>>(request.RouteDetailsDtos);

		for (int i = 1; i <= routeDetails.Count; i++)
		{
			routeDetails[i-1].SegmentNumber = i;
		}

		await _routeDetailsRepository.CreateRange(routeDetails);
		return Unit.Value;
	}
}
