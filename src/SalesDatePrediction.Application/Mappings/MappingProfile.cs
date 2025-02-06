using AutoMapper;
using SalesDatePrediction.Application.Feature.Order.Queries.GetByClientId;

namespace SalesDatePrediction.Application.Mappings;
using Domain;
public class MappingProfile : Profile
{
    public MappingProfile()
    {

        #region Models
        CreateMap<Order, GetOrdersByClientIdMV>().ReverseMap();
        #endregion

    }
}

