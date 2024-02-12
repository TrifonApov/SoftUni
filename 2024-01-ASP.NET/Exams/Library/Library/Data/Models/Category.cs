using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    [Comment("Category of book")]
    public class Category
    {
        [Comment("Category's identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Category's name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Comment("Book in the category")]
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
//• Has Id – a unique integer, Primary Key
//• Has Name – a string with min length 5 and max length 50 (required)
//• Has Books – a collection of type Books