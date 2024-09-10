using MediatR;

namespace TrainTicketsWebApp.Database.Entities;

public class TrainStation
{
    public string Station { get; set; }
    public List<RouteDetail> RouteDetailsFrom { get; set; } = new List<RouteDetail>();
    public List<RouteDetail> RouteDetailsTo { get; set; } = new List<RouteDetail>();
    public List<Schedule> ScheduleStationFrom { get; set; } = new List<Schedule>();
    public List<Schedule> ScheduleStationTo { get; set; } = new List<Schedule>();
    public List<Reservation> ReservationFrom { get; set; } = new List<Reservation>();
    public List<Reservation> ReservationTo { get; set; } = new List<Reservation>();
}
