using MediatR;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.Station;

public class GetAllStationsQuery : IRequest<List<TrainStation>>
{

}
