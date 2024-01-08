using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.PromoCodeProductStories
{
    public class CreatePromoCodeProductStory : IRequest<PromoCodeProduct>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public int PromoCodeId { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public int ProductId { get; set; }

    }
}
