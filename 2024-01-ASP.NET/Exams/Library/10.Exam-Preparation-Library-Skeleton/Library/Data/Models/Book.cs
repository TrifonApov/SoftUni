using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    [Comment("Books for the library.")]
    public class Book
    {
        [Comment("Book Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Book Title")]
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [Comment("Book Author")]
        [Required]
        [MaxLength(50)]
        public string Author { get; set; } = string.Empty;

        [Comment("Description")]
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; } = string.Empty;

        [Comment("Book cover URL")]
        [Required]
        public string ImageUrl {  get; set; } = string.Empty;

        [Comment("Book rating")]
        [Required]
        public decimal Rating { get; set; }

        [Comment("Categoty ID of the book")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Categoty of the book")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Comment("Users Books")]
        public ICollection<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
    }
}
//Book
//• Has Id – a unique integer, Primary Key
//• Has Title – a string with min length 10 and max length 50 (required)
//• Has Author – a string with min length 5 and max length 50 (required)
//• Has Description – a string with min length 5 and max length 5000 (required)
//• Has ImageUrl – a string (required)
//• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//• Has CategoryId – an integer, foreign key (required)
//• Has Category – a Category (required)
//• Has UsersBooks – a collection of type IdentityUserBook
