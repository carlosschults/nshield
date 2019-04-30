using System;

namespace carlosschults.NShield
{
    public static class Shield
    {
        public static string FromEmptyString(string value, string paramName = null)
        {
            if (value == string.Empty)
            {
                throw new ArgumentException(
                    "The value is an empty string.",
                    paramName);
            }

            return value;
        }

        public static string FromWhiteSpaceString(
            string value,
            string paramName = null)
        {
            if (value?.Trim() == string.Empty)
                throw new ArgumentException(
                    "The value is an empty or white-space string.",
                    paramName);

            return value;
        }

        public static string FromInvalidString(string value, string paramName = null)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);

            return FromWhiteSpaceString(value, paramName);
        }

        public static T FromNull<T>(T value, string paramName = null)
            where T:class
        {
            if (value == null)
                throw new ArgumentNullException(paramName);

            return value;
        }
    }
}
