using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("promocodes_products")]
    public class PromoCodeProduct : BaseEntity
    {
        [Column("promocode_id")]
        [ForeignKey("promocode")]
        public int PromoCodeId { get; set; }

        [Column("product_id")]
        [ForeignKey("product")]
        public int ProductId { get; set; }

        public PromoCode PromoCode { get; set; } = new PromoCode();
        public Product Product { get; set; } = new Product();
    }
}
