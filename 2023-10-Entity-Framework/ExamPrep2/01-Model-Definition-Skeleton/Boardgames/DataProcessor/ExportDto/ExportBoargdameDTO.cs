using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Boardgame")]
    public class ExportBoargdameDTO
    {
        public string BoardgameName { get; set; }
        public int BoardgameYearPublished { get; set; }
    }
}