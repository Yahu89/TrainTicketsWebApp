using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.Trip;

public class GetAllTripsQuery : IRequest<List<TripDto>>
{
    public int ItemsPerPage { get; set; }
	public int CurrentPageNumber { get; }
	public GetAllTripsQuery(int itemsPerPage = 20, int currentPageNumber = 1)
    {
		ItemsPerPage = itemsPerPage;
		CurrentPageNumber = currentPageNumber;
	}

	
}
