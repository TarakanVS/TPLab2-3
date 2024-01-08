using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.PromoCodeStories
{
    public class UpdatePromoCodeStory : IRequest<PromoCode>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public int Id { get; set; }

        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Name { get; set; }

        [MaxLength(5, ErrorMessage = "String too long!")]
        [MinLength(5, ErrorMessage = "String too short!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Code { get; set; }

    }
}
