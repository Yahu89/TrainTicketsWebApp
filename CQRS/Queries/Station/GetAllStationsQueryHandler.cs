using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainTicketsWebApp.Database.Configuration;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.Station;

public class GetAllStationsQueryHandler : IRequestHandler<GetAllStationsQuery, StationsPaginationResultView>
{
    private readonly ITrainStationRepository _trainStationRepository;
    private readonly IMapper _mapper;

    public GetAllStationsQueryHandler(ITrainStationRepository trainStationRepository, IMapper mapper)
    {
        _trainStationRepository = trainStationRepository;
        _mapper = mapper;
    }

    public async Task<StationsPaginationResultView> Handle(GetAllStationsQuery request, CancellationToken cancellationToken)
    {
        var result = await _trainStationRepository.GetAllPaginated(request.CurrentPage, 10);
        var stationsQty = await _trainStationRepository.GetAllStationsQty();
        var stationsDto = _mapper.Map<List<TrainStationDto>>(result);
        int totalPages = (int)Math.Ceiling((stationsQty / (double)10));
        //request.TotalItems = stationsQty;
        //request.ItemsPerPage = 10;
        //request.TotalPages = totalPages;
        StationsPaginationResultView stations = new StationsPaginationResultView(totalPages: totalPages, stationsDto, request.CurrentPage);
        return stations;
    }

}
