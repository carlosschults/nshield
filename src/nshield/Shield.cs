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
            return value;
        }
    }
}
