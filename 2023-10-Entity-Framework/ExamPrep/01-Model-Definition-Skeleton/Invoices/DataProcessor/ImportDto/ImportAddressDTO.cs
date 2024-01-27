<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportAddressDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 10)]
        public string StreetName { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string City { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Country { get; set; }
=======
﻿namespace Invoices.DataProcessor.ImportDto
{
    public class ImportAddressDTO
    {
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
    }
}