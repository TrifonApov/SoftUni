namespace CompanyHierarchy.Validation
{
    using System;

    public static class Validate
    {
        /// <summary>
        /// Check string for null, empty or any white spaces 
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="value">Value</param>
        public static void IsNullOrEmpty(string property, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(String.Format("{0} cannot be null or empty", property));
            }
        }

        /// <summary>
        /// Check is number negative
        /// </summary>
        /// <param name="property">property</param>
        /// <param name="value">value</param>
        public static void IsNegative(string property, decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(property, string.Format("{0} cannot be negative",property));
            }
        }

        /// <summary>
        /// Check if the date is in the future
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="value">value</param>
        public static void DateOfSale(string property, DateTime value)
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(property, string.Format("{0} cannot be in the future", property));
            }
        }
    }
}