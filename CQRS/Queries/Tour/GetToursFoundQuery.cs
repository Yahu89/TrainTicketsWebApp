using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.Tour;

public class GetToursFoundQuery : SearchTourModelView, IRequest<SearchTourModelView>
{
    //public GetToursFoundQuery()
    //{
        
    //}

    public GetToursFoundQuery(SearchTourModelView model)
    {
        SearchResultList = model.SearchResultList;
        SearchTourData = model.SearchTourData;
    }

    public GetToursFoundQuery(SearchTourDto data)
    {
        SearchTourData = data;
    }
    //public GetToursFoundQuery(List<SearchTourResult> data)
    //{
    //    SearchResultList = data;
    //}
}
