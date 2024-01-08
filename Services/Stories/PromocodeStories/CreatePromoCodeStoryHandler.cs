using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.PromoCodeStories
{
    public class CreatePromoCodeStoryHandler : IRequestHandler<CreatePromoCodeStory, PromoCode>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreatePromoCodeStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PromoCode> Handle(CreatePromoCodeStory story, CancellationToken cancellationToken)
        {
            var promoCode = _mapper.Map(story, new PromoCode());
            return await _repository.InsertAsync(promoCode);
        }
    }
}
