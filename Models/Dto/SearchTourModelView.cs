namespace TrainTicketsWebApp.Models.Dto;

public class SearchTourModelView : RouteDetailsCreationView
{
    public List<SearchTourResult> SearchResultList { get; set; } = new List<SearchTourResult>();
    public SearchTourDto SearchTourData { get; set; } = new SearchTourDto();
}
