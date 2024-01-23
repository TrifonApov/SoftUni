using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDTO, Supplier>();
            CreateMap<Supplier, ExportLocalSuppliers>();
            CreateMap<ImportPartDTO, Part>();
            CreateMap<ImportCarDTO, Car>();
            CreateMap<Car, ExportCarsWithDistance>();
            CreateMap<Car, ExportBWMs>();
            CreateMap<ImportPartIdDTO, Part>();
            CreateMap<ImportCustomerDTO, Customer>();
            CreateMap<ImportSaleDTO, Sale>();


        }
    }
}
