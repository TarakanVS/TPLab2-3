using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PromoCodeStories
{
    public class GetPromoCodeByIdStoryHandler : IRequestHandler<GetPromoCodeByIdStory, PromoCode>
    {
        private readonly IRepository _repository;

        public GetPromoCodeByIdStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<PromoCode> Handle(GetPromoCodeByIdStory story, CancellationToken cancellationToken)
        {
            var promoCode = await _repository.GetByIdAsync<PromoCode>(story.Id);

            return promoCode;
        }
    }
}
