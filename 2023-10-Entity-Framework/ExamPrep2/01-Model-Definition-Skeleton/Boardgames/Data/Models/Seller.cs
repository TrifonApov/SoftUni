using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20), MinLength(5)]
        public string Name { get; set; }

        [Required]
        [StringLength(30), MinLength(2)]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Website { get; set; }

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = new List<BoardgameSeller>();
    }
    //•	Id – integer, Primary Key
    //•	Name – text with length[5…20] (required)
    //•	Address – text with length[2…30] (required)
    //•	Country – text(required)
    //•	Website – a string (required). First four characters are "www.", followed by upper and lower letters, digits or '-' and the last three characters are ".com".
    //•	BoardgamesSellers – collection of type BoardgameSeller

}
