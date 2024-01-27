﻿using System.ComponentModel.DataAnnotations;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public string Position { get; set; }

        public ICollection<Truck> Trucks { get; set; } = new List<Truck>();
    }
}
//•	Id – integer, Primary Key
//•	Name – text with length [2, 40] (required)
//•	Position – text
//•	Trucks – collection of type Truck
