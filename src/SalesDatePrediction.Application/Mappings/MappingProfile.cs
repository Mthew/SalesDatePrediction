using AutoMapper;
using SalesDatePrediction.Application.Feature.Order.Queries.GetByClientId;

namespace SalesDatePrediction.Application.Mappings;
using Domain;
using SalesDatePrediction.Application.Feature.Employee.Queries.GetAll;
using SalesDatePrediction.Application.Feature.Product.Queries.GetAll;
using SalesDatePrediction.Application.Feature.SalesDatePrediction.Queries.GetAll;
using SalesDatePrediction.Application.Feature.Shipper.Queries.GetAll;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        #region Models
        CreateMap<Order, GetOrdersByClientIdMV>().ReverseMap();
        CreateMap<SaleDatePredictionList, GetAllSalesDatePredictionMV>().ReverseMap();
        CreateMap<Employee, GetAllEmployeeVM>().ReverseMap();
        CreateMap<Shipper, GetAllShipperVM>().ReverseMap();
        CreateMap<Product, GetAllProductVM>().ReverseMap();
        #endregion

    }
}

