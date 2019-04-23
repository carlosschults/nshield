using System;

namespace carlosschults.NShield
{
    public static class Shield
    {
        public static string AgainstEmptyString(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("The value is an empty string.");

            return value;
        }

        public static string AgainstWhiteSpaceString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("The value is an empty or white-space string.");

            return value;
        }

        public static string AgainstInvalidString(string value)
        {
            if (value == null)
                throw new ArgumentNullException();

            return AgainstWhiteSpaceString(value);
        }
    }
}
