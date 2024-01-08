using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.MainStories
{
    public class ShowProductsByPromocodeStoryHandler : IRequestHandler<ShowProductsByPromocodeStory, List<Product>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ShowProductsByPromocodeStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Product>> Handle(ShowProductsByPromocodeStory story, CancellationToken cancellationToken)
        {
            var products = await _repository.GetByPredicateAsync<Product>(x => x.PromoCodes.Count == 0);

            if (products == null)
            {
                return null;
            }

            var promoCodesProducts = await _repository.GetByPredicateAsync<PromoCodeProduct>(x => x.PromoCode.Code == story.Code);

            if (promoCodesProducts.Count == 0)
            {
                return products;
            }

            foreach (PromoCodeProduct x in promoCodesProducts)
            {
                products.Add(await _repository.GetByIdAsync<Product>(x.ProductId));
            }

            return products;
        }
    }
}
