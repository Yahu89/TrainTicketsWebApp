using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.Tour;

public class GetToursFoundQueryHandler : IRequestHandler<GetToursFoundQuery, List<SearchTourResult>>
{
	private readonly IScheduleRepository _scheduleRepository;

	public GetToursFoundQueryHandler(IScheduleRepository scheduleRepository)
    {
		_scheduleRepository = scheduleRepository;
	}
    public async Task<List<SearchTourResult>> Handle(GetToursFoundQuery request, CancellationToken cancellationToken)
	{
		var result = await _scheduleRepository.GetFoundTours(request);
		return result;
	}
}
