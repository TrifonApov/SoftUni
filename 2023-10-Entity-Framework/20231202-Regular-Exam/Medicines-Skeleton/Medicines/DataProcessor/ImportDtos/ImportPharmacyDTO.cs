using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDTO
    {
        [XmlAttribute("non-stop")]
        public string IsNonStop { get; set;}

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(14)]
        [MinLength(14)]
        public string PhoneNumber { get; set; }

        [XmlArray("Medicines")]
        public ImportMedicineDTO[] ImportMedicineDTOs { get; set; }

    }
}
