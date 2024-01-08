using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.PromoCodeProductStories
{
    public class DeletePromoCodeProductStory : IRequest<PromoCodeProduct>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public int Id { get; set; }
    }
}
