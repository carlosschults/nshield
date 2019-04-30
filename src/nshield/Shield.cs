﻿using System;

namespace carlosschults.NShield
{
    /// <summary>
    /// Static class that stores the guard methods.
    /// </summary>
    public static class Shield
    {
        /// <summary>
        /// Checks whether the specified <see cref="string"/>
        /// is empty. If it is, then it throws <see cref="ArgumentException"/>;
        /// otherwise, it returns the string itself.
        /// </summary>
        /// <param name="value">The string to be checked.</param>
        /// <param name="paramName">
        /// The name of the parameter, to be included when throwing.
        /// </param>
        /// <remarks>
        /// A string containing white-space isn't considered empty; so isn't 
        /// a string containing only control-characters. <c>null</c> is different than
        /// empty as well. For this method, null is valid input and it'll be returned.
        /// </remarks>
        /// <returns>The specified string when it's not empty.</returns>
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

        /// <summary>
        /// Checks whether the specified <see cref="string"/> is empty or contains only white-space.
        /// If it's empty or white-space, throws <see cref="ArgumentException"/>.
        /// Otherwise, it returns the string itself.
        /// </summary>
        /// <param name="value">The string to be checked.</param>
        /// <param name="paramName">The name of the parameter to be used when throwing.</param>
        /// <returns>
        /// The <see cref="string"/> specified, if it's not empty/white-space.
        /// </returns>
        /// <remarks>
        /// For this method, null is valid input and it'll be returned, just as a valid string.
        /// </remarks>
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

        /// <summary>
        /// Checks whether the specified <see cref="string"/> is invalid,
        /// i.e. empty, white-space or <c>null</c>. If it is, throws.
        /// Otherwise, it returns the string itself.
        /// </summary>
        /// <param name="value">The string to be checked.</param>
        /// <param name="paramName">The parameter name to be used when throwing.</param>
        /// <returns>
        /// The <see cref="string"/> specified, if it's not empty/white-space.
        /// </returns>
        public static string FromInvalidString(string value, string paramName = null)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);

            return FromWhiteSpaceString(value, paramName);
        }

        /// <summary>
        /// Checks whether the specified object of type <typeparamref name="T"/> is <c>null</c>.
        /// If so, an exception is thrown. Otherwise, the object itself is returned.
        /// </summary>
        /// <typeparam name="T">The type parameter for <paramref name="value"/>.</typeparam>
        /// <param name="value">The object to be checked for <c>null</c>.</param>
        /// <param name="paramName">The parameter name to be used when throwing.</param>
        /// <returns>
        /// <paramref name="value"/>, if it's not <c>null</c>.
        /// </returns>
        public static T FromNull<T>(T value, string paramName = null)
            where T:class
        {
            if (value == null)
                throw new ArgumentNullException(paramName);

            return value;
        }
    }
}
