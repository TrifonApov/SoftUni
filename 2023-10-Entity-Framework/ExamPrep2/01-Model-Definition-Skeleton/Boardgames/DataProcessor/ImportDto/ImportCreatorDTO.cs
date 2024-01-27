using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDTO
    {
        [Required]
        [StringLength(7), MinLength(2)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(7), MinLength(2)]
        public string LastName { get; set; }

        [XmlArray("Boardgames")]
        public ImportBoardgameDTO[] Boardgames { get; set; }
    }
}
//<?xml version='1.0' encoding='UTF-8'?>
//<Creators>
//	<Creator>
//		<FirstName>Debra</FirstName>
//		<LastName>Edwards</LastName>
//		<Boardgames>
//			<Boardgame>
//				<Name>4 Gods</Name>
//				<Rating>7.28</Rating>
//				<YearPublished>2017</YearPublished>
//				<CategoryType>4</CategoryType>
//				<Mechanics>Area Majority / Influence, Hand Management, Set Collection, Simultaneous Action Selection, Worker Placement</Mechanics>
//			</Boardgame>
//			<Boardgame>
//				<Name>7 Steps</Name>
//				<Rating>7.01</Rating>
//				<YearPublished>2015</YearPublished>
//				<CategoryType>4</CategoryType>
//				<Mechanics>Action Queue, Hand Management, Push Your Luck, Set Collection</Mechanics>
//			</Boardgame>
//	     …
//		</Boardgames>
//	</Creator>
//  …
//</ Creators>
