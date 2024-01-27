using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientDTO
    {
        [Required]
        [StringLength(25, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10)]
        public string NumberVat { get; set; }

        [XmlArray("Addresses")]
        public ImportAddressDTO[] Address { get; set; }
    }
}
