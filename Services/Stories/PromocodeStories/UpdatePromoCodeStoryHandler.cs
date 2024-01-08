using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PromoCodeStories
{
    public class UpdatePromoCodeStoryHandler : IRequestHandler<UpdatePromoCodeStory, PromoCode>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePromoCodeStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PromoCode> Handle(UpdatePromoCodeStory story, CancellationToken token)
        {
            var promoCode = _mapper.Map(story, new PromoCode());
            return await _repository.UpdateAsync(promoCode);
        }
    }
}
