using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.TrainType;

public class GetAllTrainTypesQuery : IRequest<List<TrainTypeDto>>
{

}
