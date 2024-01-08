using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PurchaseStories
{
    public class UpdatePurchaseStoryHandler : IRequestHandler<UpdatePurchaseStory, Purchase>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePurchaseStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Purchase> Handle(UpdatePurchaseStory story, CancellationToken token)
        {
            var purchase = _mapper.Map(story, new Purchase());
            return await _repository.UpdateAsync(purchase);
        }
    }
}
