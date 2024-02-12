using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.DataConstants;
namespace Library.Data.Models
{
    [Comment("Library book")]
    public class Book
    {
        [Comment("Book's identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Book's title")]
        [Required]
        [StringLength(TitleMaximumLength)]
        public string Title { get; set; } = string.Empty;

        [Comment("Book's author")]
        [Required]
        [StringLength(AuthorMaximumLength)]
        public string Author { get; set; } = string.Empty;

        [Comment("Book's description")]
        [Required]
        [StringLength(DescriptionMaximumLength)]
        public string Description { get; set; } = string.Empty;

        [Comment("Book's cover image URL")]
        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Comment("Book's rating")]
        [Required]
        [Range(typeof(decimal), RatingMinimumValue, RatingMaximumValue)]
        public decimal Rating { get; set; }

        [Comment("Book's category ID")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Book's category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public ICollection<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
    }
}
//• Has Id – a unique integer, Primary Key
//• Has Title – a string with min length 10 and max length 50 (required)
//• Has Author – a string with min length 5 and max length 50 (required)
//• Has Description – a string with min length 5 and max length 5000 (required)
//• Has ImageUrl – a string (required)
//• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//• Has CategoryId – an integer, foreign key (required)
//• Has Category – a Category (required)
//• Has UsersBooks – a collection of type IdentityUserBook