﻿namespace TrainTicketsWebApp.Models.Dto;

public class SearchTourDto
{
    public string From { get; set; }
    public string To { get; set; }
    public TimeSpan DepartureTime { get; set; }
    public DateTime DepartureDay { get; set; }
    public bool InterchangeApproved { get; set; }
}
