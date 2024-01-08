using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public double Price { get; set; }
        public ICollection<PromoCode> PromoCodes { get; set; } = new List<PromoCode>();
        public ICollection<Purchase> Purchses { get; set; } = new List<Purchase>();

    }
}
