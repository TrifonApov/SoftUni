using System.ComponentModel.DataAnnotations;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(8)]
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(17)]
        public string VinNumber { get; set; }

        [Range(950,1420)]
        public int TankCapacity { get; set; }

        [Range(5000,29000)] 
        public int CargoCapacity { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required] 
        public MakeType MakeType { get; set; }

        public int DespatcherId { get; set; }

        public Despatcher Despatcher { get; set; }

        public ICollection<ClientTruck> ClientsTrucks { get; set; } = new List<ClientTruck>();
    }
}
//•	Id – integer, Primary Key
//•	RegistrationNumber – text with length 8. First two characters are upper letters [A-Z], followed by four digits and the last two characters are upper letters [A-Z] again.
//•	VinNumber – text with length 17 (required)
//•	TankCapacity – integer in range [950…1420]
//•	CargoCapacity – integer in range [5000…29000]
//•	CategoryType – enumeration of type CategoryType, with possible values (Flatbed, Jumbo, Refrigerated, Semi) (required)
//•	MakeType – enumeration of type MakeType, with possible values (Daf, Man, Mercedes, Scania, Volvo) (required)
//•	DespatcherId – integer, foreign key (required)
//•	Despatcher – Despatcher 
//•	ClientsTrucks – collection of type ClientTruck
