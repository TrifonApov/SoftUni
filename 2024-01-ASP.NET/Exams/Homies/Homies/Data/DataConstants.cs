namespace Homies.Data
{
    public static class DataConstants
    {
        public const int EventNameMinLenght = 5;
        public const int EventNameMaxLenght = 20;

        public const int EventDescriptionMinLenght = 15;
        public const int EventDescriptionMaxLenght = 150;

        public const string DateTimeFormat = "yyyy-MM-dd H:mm";

        public const int TypeNameMinLenght = 5;
        public const int TypeNameMaxLenght = 15;

        public const string RequiredErrorMessage = "The field {0} is required";
        public const string LengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
    }
}
