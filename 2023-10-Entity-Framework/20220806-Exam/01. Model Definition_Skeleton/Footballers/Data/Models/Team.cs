using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; } = new List<TeamFootballer>();
    }
}
//•	Id – integer, Primary Key
//•	Name – text with length [3, 40].Should contain letters(lower and upper case), digits, spaces, a dot sign ('.') and a dash ('-'). (required)
//•	Nationality – text with length [2, 40] (required)
//•	Trophies – integer (required)
//•	TeamsFootballers – collection of type TeamFootballer
