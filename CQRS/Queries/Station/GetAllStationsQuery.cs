using MediatR;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.Station;

public class GetAllStationsQuery : IRequest<StationsPaginationResultView>
{
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public GetAllStationsQuery()
    {
        
    }
    public GetAllStationsQuery(int currentPage)
    {
        CurrentPage = currentPage;
    }
}
