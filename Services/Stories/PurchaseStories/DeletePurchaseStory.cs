using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.PurchaseStories
{
    public class DeletePurchaseStory : IRequest<Purchase>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public int Id { get; set; }
    }
}
