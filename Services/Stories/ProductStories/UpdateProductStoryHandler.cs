using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ProductStories
{
    public class UpdateProductStoryHandler : IRequestHandler<UpdateProductStory, Product>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Product> Handle(UpdateProductStory story, CancellationToken token)
        {
            var product = _mapper.Map(story, new Product());
            return await _repository.UpdateAsync(product);
        }
    }
}
