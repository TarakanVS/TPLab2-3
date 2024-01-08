using System.ComponentModel.DataAnnotations;

namespace Lab2_3Web.Models
{
    public class PurchaseViewModel
    {
        public int ProductId { get; set; }

        [Required]
        public string Person { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        public DateTime Date { get; set; }
    }
}
