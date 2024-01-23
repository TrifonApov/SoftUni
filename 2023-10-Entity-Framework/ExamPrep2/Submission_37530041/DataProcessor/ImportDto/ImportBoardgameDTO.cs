using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgameDTO
    {
        [Required]
        [StringLength(20), MinLength(10)]
        public string Name { get; set; }

        [Required]
        [Range(1.00, 10.00)]
        public double Rating { get; set; }

        [Required]
        [Range(2018, 2023)]
        public int YearPublished { get; set; }

        [Required]
        [EnumDataType(typeof(CategoryType))]
        public int CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; }

    }
}


//<Boardgame>
//	<Name>4 Gods</Name>
//	<Rating>7.28</Rating>
//	<YearPublished>2017</YearPublished>
//	<CategoryType>4</CategoryType>
//	<Mechanics>Area Majority / Influence, Hand Management, Set Collection, Simultaneous Action Selection, Worker Placement</Mechanics>
//</Boardgame>
