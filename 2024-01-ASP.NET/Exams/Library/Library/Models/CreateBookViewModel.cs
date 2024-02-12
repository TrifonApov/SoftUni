using Library.Data.Models;
using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants;
namespace Library.Models
{
    public class CreateBookViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TitleMaximumLength,
            MinimumLength = TitleMinimumLength,
            ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(AuthorMaximumLength,
            MinimumLength = AuthorMinimumLength,
            ErrorMessage = LengthErrorMessage)]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaximumLength,
            MinimumLength = DescriptionMinimumLength,
            ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Url { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(typeof(decimal), RatingMinimumValue, RatingMaximumValue, ErrorMessage = RatingRangeErrorMessage)]
        public decimal Rating { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
