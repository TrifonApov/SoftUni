using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    [Comment("Books categories")]
    public class Category
    {
        [Comment("Category ID")]
        [Key]
        public int Id { get; set; }

        [Comment("Category Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Comment("Books in category")]
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}