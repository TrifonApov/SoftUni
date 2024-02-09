<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
=======
﻿using System.Xml.Serialization;
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientDTO
    {
<<<<<<< HEAD
        [Required]
        [StringLength(25, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10)]
=======
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("NumberVat")]
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
        public string NumberVat { get; set; }

        [XmlArray("Addresses")]
        public ImportAddressDTO[] Address { get; set; }
    }
}
