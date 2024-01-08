using AutoMapper;
using Domain.Models;
using Lab2_3Web.Models;
using Services.Stories.PurchaseStories;

namespace Lab2_3Web
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<PurchaseViewModel, Purchase>();
            CreateMap<PurchaseViewModel, CreatePurchaseStory>();
        }
    }
}
