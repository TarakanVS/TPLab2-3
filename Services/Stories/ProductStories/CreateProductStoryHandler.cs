using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ProductStories
{
    public class CreateProductStoryHandler : IRequestHandler<CreateProductStory, Product>
    {
        private readonly IRepository _repository;

        public CreateProductStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(CreateProductStory story, CancellationToken cancellationToken)
        {
            var product = new Product { Name = story.Name, Price = story.Price };
            return await _repository.InsertAsync(product);
        }
    }
}
