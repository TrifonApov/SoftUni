using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDTO
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
