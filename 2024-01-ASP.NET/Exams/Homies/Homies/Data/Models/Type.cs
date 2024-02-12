using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants;

namespace Homies.Data.Models
{
    [Comment("Event type")]
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TypeNameMaxLenght)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}