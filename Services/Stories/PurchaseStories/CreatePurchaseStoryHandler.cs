using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PurchaseStories
{
    public class CreatePurchaseStoryHandler : IRequestHandler<CreatePurchaseStory, Purchase>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreatePurchaseStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Purchase> Handle(CreatePurchaseStory story, CancellationToken cancellationToken)
        {
            var purchase = _mapper.Map(story, new Purchase());
            return await _repository.InsertAsync(purchase);
        }
    }
}
