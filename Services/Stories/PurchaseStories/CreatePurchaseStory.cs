using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.PurchaseStories
{
    public class CreatePurchaseStory : IRequest<Purchase>
    {
        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Person { get; set; }

        [MaxLength(60, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Address { get; set; }

        [Range(0, 999999)]
        [Required(ErrorMessage = "Field can't be empty")]
        public int ProductId { get; set; }

        public DateTime Date { get; set; }
    }
}
