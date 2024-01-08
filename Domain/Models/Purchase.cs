using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("purchases")]
    public class Purchase : BaseEntity
    {
        [Column("person")]
        public string Person { get; set; } = null!;

        [Column("address")]
        public string Address { get; set; } = null!;

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("product_id")]
        [ForeignKey("product")]
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;
    }
}
