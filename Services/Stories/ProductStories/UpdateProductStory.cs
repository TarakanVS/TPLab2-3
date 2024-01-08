using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stories.ProductStories
{
    public class UpdateProductStory : IRequest<Product>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public int Id { get; set; }

        [MaxLength(25, ErrorMessage = "String too long!")]
        public string Name { get; set; }

        [Range(0, 999999)]
        public double Price { get; set; }
    }
}
