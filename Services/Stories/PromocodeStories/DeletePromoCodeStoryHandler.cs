using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PromoCodeStories
{
    public class DeletePromoCodeStoryHandler : IRequestHandler<DeletePromoCodeStory, PromoCode>
    {
        private readonly IRepository _repository;

        public DeletePromoCodeStoryHandler(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<PromoCode> Handle(DeletePromoCodeStory story, CancellationToken cancellationToken)
        {
            var promoCode = await _repository.GetByIdAsync<PromoCode>(story.Id);
            if (promoCode == null)
                return default;

            return await _repository.DeleteAsync<PromoCode>(promoCode.Id);
        }
    }
}
