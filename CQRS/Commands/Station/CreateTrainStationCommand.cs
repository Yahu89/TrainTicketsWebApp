using MediatR;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Commands.Station;

public class CreateTrainStationCommand : TrainStation, IRequest
{

}
