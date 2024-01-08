using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("promocodes")]
    public class PromoCode : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("code")]
        public string Code { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
