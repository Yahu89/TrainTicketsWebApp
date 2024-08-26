using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.RouteDetails;

public class GetRouteDetailQuery : IRequest<List<RouteDetailDto>>
{
    public string RouteName { get; set; }
	public GetRouteDetailQuery(string routeId)
    {
		RouteName = routeId;
	}
}
