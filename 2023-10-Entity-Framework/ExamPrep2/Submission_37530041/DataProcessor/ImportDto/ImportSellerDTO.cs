using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDTO
    {
        [Required]
        [StringLength(20), MinLength(5)]
        public string Name { get; set; }

        [Required]
        [StringLength(30), MinLength(2)]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Website { get; set; }

        public int[] Boardgames { get; set; }
    }
}
//"Name": "6am",
//"Address": "The Netherlands",
//"Country": "Belgium",
//"Website": "www.6pm.com",
//"Boardgames": [
//1,
//105,
//1,
//5,
//15
//    ]
