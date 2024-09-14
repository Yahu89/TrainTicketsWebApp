

using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Commands.Station
{
    public class DeleteStationCommand : IRequest
    {
        public string StationName { get; set; }
        public DeleteStationCommand(string station)
        {
            StationName = station;
        }
    }
}
