using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(7), MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(7), MinLength(2)]
        public string LastName { get; set; }

        public ICollection<Boardgame> Boardgames { get; set; } = new List<Boardgame>();

    }
    //•	Id – integer, Primary Key
    //•	FirstName – text with length[2, 7] (required) 
    //•	LastName – text with length[2, 7] (required)
    //•	Boardgames – collection of type Boardgame

}
