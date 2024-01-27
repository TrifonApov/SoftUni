using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("car")]
    public class ExportCarsWithParts
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("traveled-distance")]
        public long TraveledDistance { get; set; }

        [XmlElement("parts")]
        public List<ExportCarParts> Parts { get; set; }

    }
}
