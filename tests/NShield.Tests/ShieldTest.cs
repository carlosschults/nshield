using carlosschults.NShield;
using NUnit.Framework;
using System;

namespace NShield.Tests
{
    public class Tests
    {
        [TestCase(null)]
        [TestCase("doesn't look like an empty string!")]
        [TestCase(" ")]
        [TestCase("\n\n\r")]
        public void AgainstEmptyString_WithNonEmptyString_ShouldReturnTheStringItself(string value)
        {
            string expected = value;
            string result = Shield.AgainstEmptyString(value);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AgainstEmptyString()
        {
            TestDelegate t = () => Shield.AgainstEmptyString(string.Empty);
            Assert.Throws<ArgumentException>(t);
        }

        [TestCase(null)]
        [TestCase("some text")]
        [TestCase("x")]
        [TestCase("even more test")]
        [TestCase("old McDonald had a farm...and it exploded!")]
        public void AgainstWhiteSpaceString_WithNonWhiteSpaceString_ReturnsTheStringItself(string value)
        {
            string expected = value;
            string result = Shield.AgainstWhiteSpaceString(value);
            Assert.AreEqual(expected, result);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        [TestCase("\n\n\n\r\r")]
        public void AgainstWhiteSpaceString(string value)
        {
            TestDelegate t = () => Shield.AgainstWhiteSpaceString(value);
            Assert.Throws<ArgumentException>(t);
        }

        [TestCase("some text")]
        [TestCase("x")]
        [TestCase("even more test")]
        [TestCase("old McDonald had a farm...and it exploded!")]
        public void AgainstInvalidString_WithValidStrings_ShouldReturnTheStringItself(string value)
        {
            string expected = value;
            string result = Shield.AgainstInvalidString(value);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AgainstInvalidString_PassingNullReference_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => Shield.AgainstInvalidString(null));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        [TestCase("\n\n\n\r\r")]
        public void AgainstInvalidString(string value)
        {
            Assert.Throws<ArgumentException>(
                () => Shield.AgainstInvalidString(value));
        }
    }
}