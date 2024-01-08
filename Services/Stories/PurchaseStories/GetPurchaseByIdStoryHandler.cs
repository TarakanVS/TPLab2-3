using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PurchaseStories
{
    public class GetPurchaseByIdStoryHandler : IRequestHandler<GetPurchaseByIdStory, Purchase>
    {
        private readonly IRepository _repository;

        public GetPurchaseByIdStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Purchase> Handle(GetPurchaseByIdStory story, CancellationToken cancellationToken)
        {
            var purchase = await _repository.GetByIdAsync<Purchase>(story.Id);

            return purchase;
        }
    }
}
