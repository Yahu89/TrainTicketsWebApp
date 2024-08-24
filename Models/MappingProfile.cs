using AutoMapper;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TrainType, TrainTypeDto>();
    }
}
