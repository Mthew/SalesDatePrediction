using AutoMapper;
using SalesDatePrediction.Application.Feature.Order.Queries.GetByClientId;

namespace SalesDatePrediction.Application.Mappings;
using Domain;
using SalesDatePrediction.Application.Feature.SalesDatePrediction.Queries.GetAll;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        #region Models
        CreateMap<Order, GetOrdersByClientIdMV>().ReverseMap();
        CreateMap<SaleDatePredictionList, GetAllSalesDatePredictionMV>().ReverseMap();
        #endregion

    }
}

