using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PromoCodeProductStories
{
    public class GetPromoCodeProductByIdStoryHandler : IRequestHandler<GetPromoCodeProductByIdStory, PromoCodeProduct>
    {
        private readonly IRepository _repository;

        public GetPromoCodeProductByIdStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<PromoCodeProduct> Handle(GetPromoCodeProductByIdStory story, CancellationToken cancellationToken)
        {
            var promoCodeProduct = await _repository.GetByIdAsync<PromoCodeProduct>(story.Id);

            promoCodeProduct.PromoCode = await _repository.GetByIdAsync<PromoCode>(promoCodeProduct.PromoCodeId);
            promoCodeProduct.Product = await _repository.GetByIdAsync<Product>(promoCodeProduct.ProductId);

            return promoCodeProduct;
        }
    }
}
