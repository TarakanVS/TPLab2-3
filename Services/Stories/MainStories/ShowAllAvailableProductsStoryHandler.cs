using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;
using Services.Stories.ProductStories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stories.MainStories
{
    public class ShowAllAvailableProductsStoryHandler : IRequestHandler<ShowAllAvailableProductsStory, List<Product>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ShowAllAvailableProductsStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Product>> Handle(ShowAllAvailableProductsStory story, CancellationToken cancellationToken)
        {
            var promoCodesProducts = await _repository.GetAllAsync<PromoCodeProduct>();

            if (promoCodesProducts.Count == 0)
            {
                return null;
            }

            var products = await _repository.GetByPredicateAsync<Product>(x => x.PromoCodes.Count == 0);

            if (products.Count == 0)
            {
                return null;
            }

            return products;
        }
    }
}
