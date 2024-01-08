using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ProductStories
{
    public class GetProductByIdStoryHandler : IRequestHandler<GetProductByIdStory, Product>
    {
        private readonly IRepository _repository;

        public GetProductByIdStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdStory story, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync<Product>(story.Id);

            return product;
        }
    }
}
