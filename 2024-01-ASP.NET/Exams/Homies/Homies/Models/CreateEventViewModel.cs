using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants;

namespace Homies.Models
{
    public class CreateEventViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(EventNameMaxLenght, 
            MinimumLength = EventNameMinLenght,
            ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(EventDescriptionMaxLenght,
            MinimumLength = EventDescriptionMinLenght)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Start { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string End { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
