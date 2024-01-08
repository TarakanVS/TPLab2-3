using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Lab2_3Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; }
    }
}
