using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class ExportCreatorsDTO
    {
        public string CreatorName{ get; set; }

        [XmlAttribute("BoardgamesCount")]
        public int BoardgamesCount { get; set; }
        
        [XmlArray("Boardgames")]
        public ExportBoargdameDTO[] Boardgames { get; set; }
    }
}
