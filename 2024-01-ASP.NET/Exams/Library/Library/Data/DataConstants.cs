namespace Library.Data
{
    public static class DataConstants
    {
        public const int TitleMaximumLength = 30;
        public const int TitleMinimumLength = 10;

        public const int AuthorMaximumLength = 50;
        public const int AuthorMinimumLength = 5;

        public const int DescriptionMaximumLength = 5000;
        public const int DescriptionMinimumLength = 5;

        public const string RatingMaximumValue = "10.0";
        public const string RatingMinimumValue = "0.0";

        public const int CategoryNameMaximumLength = 50;
        public const int CategoryNameMinimumLength = 5;

        public const string RequiredErrorMessage = "The field {0} is required";
        public const string LengthErrorMessage = "The field {0} must be between {2} and {1} characters long";

        public const string RatingRangeErrorMessage = "The field {0} must be between {1} and {2}";
    }
}
