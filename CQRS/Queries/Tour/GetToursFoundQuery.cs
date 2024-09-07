using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.Tour;

public class GetToursFoundQuery : SearchTourDto, IRequest<List<SearchTourResult>>
{

}
