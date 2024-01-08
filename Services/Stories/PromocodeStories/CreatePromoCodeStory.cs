using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.PromoCodeStories
{
    public class CreatePromoCodeStory : IRequest<PromoCode>
    {
        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Name { get; set; }

        [MaxLength(5, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Code { get; set; }
    }
}
