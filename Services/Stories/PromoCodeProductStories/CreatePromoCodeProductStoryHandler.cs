using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PromoCodeProductStories
{
    public class CreatePromoCodeProductStoryHandler : IRequestHandler<CreatePromoCodeProductStory, PromoCodeProduct>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreatePromoCodeProductStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PromoCodeProduct> Handle(CreatePromoCodeProductStory story, CancellationToken cancellationToken)
        {
            var promoCodeProduct = _mapper.Map(story, new PromoCodeProduct());
            var promoCode = await _repository.GetByIdAsync<PromoCode>(promoCodeProduct.PromoCodeId);

            if (promoCode == null)
            {
                return null;
            }

            var product = await _repository.GetByIdAsync<Product>(promoCodeProduct.ProductId);

            if (product == null)
            {
                return null;
            }

            if ((await _repository.GetByPredicateAsync<PromoCodeProduct>(x => x.ProductId == product.Id)).Count != 0
                && (await _repository.GetByPredicateAsync<PromoCodeProduct>(x => x.PromoCodeId == promoCode.Id)).Count != 0)
            {
                return null;
            }

            promoCode.Products.Add(product);
            product.PromoCodes.Add(promoCode);
            var p = _repository.UpdateAsync(product);
            var m = _repository.UpdateAsync(promoCode);

            promoCodeProduct.Product = product;
            promoCodeProduct.PromoCode = promoCode;

            return await _repository.InsertAsync(promoCodeProduct); ;
        }
    }
}
