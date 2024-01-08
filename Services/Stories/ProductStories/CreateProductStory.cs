using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.ProductStories
{
    public class CreateProductStory : IRequest<Product>
    {
        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Name { get; set; }

        [Range(0, 999999)]
        [Required(ErrorMessage = "Field can't be empty")]
        public double Price { get; set; }
    }
}
