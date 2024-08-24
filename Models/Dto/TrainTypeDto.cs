namespace TrainTicketsWebApp.Models.Dto;

public class TrainTypeDto
{
	public string LongName { get; set; }
	public string ShortName { get; set; }
	public int TotalPlacesAvailable { get; set; }
	public int Speed { get; set; }
}
