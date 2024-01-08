using AutoMapper;
using Domain.Models;

namespace Repository
{
    public class BaseAppMappingProfile : Profile
    {
        public BaseAppMappingProfile() 
        {
            CreateMap<Product, Product>();
            CreateMap<PromoCode, PromoCode>();
            CreateMap<PromoCodeProduct, PromoCodeProduct>();
            CreateMap<Purchase, Purchase>();
        }
    }
}
