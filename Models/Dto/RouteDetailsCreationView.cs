using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrainTicketsWebApp.Models.Dto;

public class RouteDetailsCreationView
{
    public List<SelectListItem> Routes { get; set; }
    public List<SelectListItem> From { get; set; }
    public List<SelectListItem> To { get; set; }
}
