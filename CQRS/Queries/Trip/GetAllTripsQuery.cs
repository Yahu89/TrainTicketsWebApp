using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.Trip;

public class GetAllTripsQuery : IRequest<TripsPaginationResultView>
{
    public int ItemsPerPage { get; set; }
	public int CurrentPageNumber { get; }
    public int TotalPages { get; set; }
    public GetAllTripsQuery(int totalPages, int itemsPerPage = 20, int currentPageNumber = 1)
    {
		ItemsPerPage = itemsPerPage;
		CurrentPageNumber = currentPageNumber;
		TotalPages = totalPages;
	}

	
}
