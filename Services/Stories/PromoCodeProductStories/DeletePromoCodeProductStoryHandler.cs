using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PromoCodeProductStories
{
    public class DeletePromoCodeProductStoryHandler : IRequestHandler<DeletePromoCodeProductStory, PromoCodeProduct>
    {
        private readonly IRepository _repository;

        public DeletePromoCodeProductStoryHandler(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<PromoCodeProduct> Handle(DeletePromoCodeProductStory story, CancellationToken cancellationToken)
        {
            var promoCodeProduct = await _repository.GetByIdAsync<PromoCodeProduct>(story.Id);
            if (promoCodeProduct == null)
                return default;

            return await _repository.DeleteAsync<PromoCodeProduct>(promoCodeProduct.Id);
        }
    }
}
