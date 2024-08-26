using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrainTicketsWebApp.Models.Dto;

public class TripCreationView
{
    public List<SelectListItem> Routes { get; set; } = new List<SelectListItem>();
    public List<SelectListItem> TrainTypes { get; set; } = new List<SelectListItem>();
}
