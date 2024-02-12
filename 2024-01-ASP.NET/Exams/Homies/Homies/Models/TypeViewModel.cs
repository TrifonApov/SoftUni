using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants;

namespace Homies.Models
{
    public class TypeViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Name { get; set; }
    }
}
