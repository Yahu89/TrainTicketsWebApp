using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.Station;

public class GetAllStationsQueryHandler : IRequestHandler<GetAllStationsQuery, List<TrainStation>>
{
    private readonly ITrainStationRepository _trainStationRepository;

    public GetAllStationsQueryHandler(ITrainStationRepository trainStationRepository)
    {
        _trainStationRepository = trainStationRepository;
    }
    public async Task<List<TrainStation>> Handle(GetAllStationsQuery request, CancellationToken cancellationToken)
    {
        var result = await _trainStationRepository.GetAll();
        return result;
    }
}
