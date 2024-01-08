using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.ProductStories
{
    public class GetProductByIdStory : IRequest<Product>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public int Id { get; set; }
    }
}
