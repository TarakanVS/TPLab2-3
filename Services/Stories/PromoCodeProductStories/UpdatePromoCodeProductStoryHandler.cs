using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PromoCodeProductStories
{
    public class UpdatePromoCodeProductStoryHandler : IRequestHandler<UpdatePromoCodeProductStory, PromoCodeProduct>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePromoCodeProductStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PromoCodeProduct> Handle(UpdatePromoCodeProductStory story, CancellationToken token)
        {
            var promoCodeProduct = _mapper.Map(story, new PromoCodeProduct());

            var promoCode = await _repository.GetByIdAsync<PromoCode>(promoCodeProduct.PromoCodeId);

            if (promoCode == null)
            {
                return null;
            }

            promoCodeProduct.PromoCode = promoCode;

            var product = await _repository.GetByIdAsync<Product>(promoCodeProduct.ProductId);

            if (product == null)
            {
                return null;
            }

            promoCodeProduct.Product = product;

            return await _repository.UpdateAsync(promoCodeProduct);
        }
    }
}
