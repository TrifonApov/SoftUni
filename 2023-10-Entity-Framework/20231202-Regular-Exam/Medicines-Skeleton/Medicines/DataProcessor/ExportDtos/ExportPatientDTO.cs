using Medicines.Data.Models.Enums;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType("Patient")]
    public class ExportPatientDTO
    {
        [XmlAttribute("Gender")]
        public string Gender { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("AgeGroup")]
        public AgeGroup AgeGroup { get; set; }

        [XmlArray("Medicines")]
        public ExportMedicineDTO[] Medicines { get; set; }

    }
}
