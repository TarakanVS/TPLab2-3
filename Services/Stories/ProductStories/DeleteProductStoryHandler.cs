using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ProductStories
{
    public class DeleteProductStoryHandler : IRequestHandler<DeleteProductStory, Product>
    {
        private readonly IRepository _repository;

        public DeleteProductStoryHandler(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Product> Handle(DeleteProductStory story, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync<Product>(story.Id);
            if (product == null)
                return default;

            return await _repository.DeleteAsync<Product>(product.Id);
        }
    }
}
