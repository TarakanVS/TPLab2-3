using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PurchaseStories
{
    public class DeletePurchaseStoryHandler : IRequestHandler<DeletePurchaseStory, Purchase>
    {
        private readonly IRepository _repository;

        public DeletePurchaseStoryHandler(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Purchase> Handle(DeletePurchaseStory story, CancellationToken cancellationToken)
        {
            var purchase = await _repository.GetByIdAsync<Purchase>(story.Id);
            if (purchase == null)
                return default;

            return await _repository.DeleteAsync<Purchase>(purchase.Id);
        }
    }
}
