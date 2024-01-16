using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Core.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }
        [Range(0,1000, ErrorMessage = "Please enter a value beetwen 0 and 1000")]
        public int Count { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public string ApplicationUserId { get; set; }

        [NotMapped]
        public decimal Price { get; set; }
    }
}
