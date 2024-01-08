using AutoMapper;
using Domain.Models;
using Services.Stories.ProductStories;
using Services.Stories.PromoCodeProductStories;
using Services.Stories.PromoCodeStories;
using Services.Stories.PurchaseStories;

namespace Services
{
    public class StoryAppMappingProfile : Profile
    {
        public StoryAppMappingProfile() 
        {
            CreateMap<CreateProductStory, Product>();
            CreateMap<UpdateProductStory, Product>();

            CreateMap<CreatePromoCodeStory, PromoCode>();
            CreateMap<UpdatePromoCodeStory, PromoCode>();

            CreateMap<CreatePromoCodeProductStory, PromoCodeProduct>();
            CreateMap<UpdatePromoCodeProductStory, PromoCodeProduct>();

            CreateMap<CreatePurchaseStory, Purchase>();
            CreateMap<UpdatePurchaseStory, Purchase>();
        }
    }
}
