using AutoMapper;
using TrainTicketsWebApp.CQRS.Commands.Route;
using TrainTicketsWebApp.CQRS.Commands.RouteDetails;
using TrainTicketsWebApp.CQRS.Commands.TrainType;
using TrainTicketsWebApp.CQRS.Commands.Trip;
using TrainTicketsWebApp.Database.Collections;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TrainType, TrainTypeDto>();

        CreateMap<CreateTrainTypeCommand, TrainType>();

        CreateMap<CreateRouteCommand, Database.Entities.Route>();

        CreateMap<Database.Entities.Route, RouteDto>();

        CreateMap<CreateRouteDetailsDto, RouteDetail>();

        CreateMap<CreateTripsDto, Trip>()
            .ForMember(x => x.DepartureTime, y => y.MapFrom(src => DateTime.Now))
            .ForMember(x => x.TrainTypeName, y => y.MapFrom(src => src.TrainType))
            .ForMember(x => x.RouteId, y => y.MapFrom(src => src.RouteId));

        CreateMap<RouteDetail, RouteDetailDto>()
            .ForMember(x => x.Name, y => y.MapFrom(src => src.Routes.Name));

        CreateMap<Trip, TripDto>()
            .ForMember(x => x.RouteName, y => y.MapFrom(src => src.Route.Name))
            .ForMember(x => x.DepartureDate, y => y.MapFrom(src => src.DepartureTime.Date))
            .ForMember(x => x.DepartureTime, y => y.MapFrom(src => src.DepartureTime.ToString("HH:mm")))
            .ForMember(x => x.TrainType, y => y.MapFrom(src => src.TrainTypeName));

        CreateMap<TripOccupation,  TripOccupationDto>().ReverseMap();
    }
}
