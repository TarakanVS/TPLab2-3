using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.MainStories
{
    public class ShowProductsByPromocodeStory : IRequest<List<Product>>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        [MaxLength(5, ErrorMessage = "String too long!")]
        [MinLength(5, ErrorMessage = "String too short!")]
        public string Code { get; set; }
    }
}
