using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("NumberVat")]
        public string NumberVat { get; set; }

        [XmlArray("Addresses")]
        public ImportAddressDTO[] Address { get; set; }
    }
}
