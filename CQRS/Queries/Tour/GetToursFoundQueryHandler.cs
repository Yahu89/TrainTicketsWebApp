using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.Tour;

public class GetToursFoundQueryHandler : IRequestHandler<GetToursFoundQuery, SearchTourModelView>
{
	private readonly IScheduleRepository _scheduleRepository;
    private readonly ITrainStationRepository _trainStationRepository;

    public GetToursFoundQueryHandler(IScheduleRepository scheduleRepository, ITrainStationRepository trainStationRepository)
    {
		_scheduleRepository = scheduleRepository;
        _trainStationRepository = trainStationRepository;
    }
    public async Task<SearchTourModelView> Handle(GetToursFoundQuery request, CancellationToken cancellationToken)
	{
        var fillComboBoxesForSearchingTour = await _trainStationRepository.GetRouteDetailsCreationView();
		var result = await _scheduleRepository.GetFoundTours(request);

        SearchTourModelView model = new SearchTourModelView()
        {
            SearchResultList = result,
            Routes = fillComboBoxesForSearchingTour.Routes,
            From = fillComboBoxesForSearchingTour.From,
            To = fillComboBoxesForSearchingTour.To
        };

		return model;
	}
}
