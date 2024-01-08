using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stories.PurchaseStories
{
    public class UpdatePurchaseStory : IRequest<Purchase>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public int Id { get; set; }

        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Person { get; set; }

        [MaxLength(60, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Address { get; set; }
    }
}
