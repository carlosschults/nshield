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
        public void FromEmptyString_WithNonEmptyString_ShouldReturnTheStringItself(string value)
        {
            string expected = value;
            string result = Shield.FromEmptyString(value);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FromEmptyString()
        {
            TestDelegate t = () => Shield.FromEmptyString(string.Empty);
            Assert.Throws<ArgumentException>(t);
        }

        [TestCase(null)]
        [TestCase("some text")]
        [TestCase("x")]
        [TestCase("even more test")]
        [TestCase("old McDonald had a farm...and it exploded!")]
        public void FromWhiteSpaceString_WithNonWhiteSpaceString_ReturnsTheStringItself(string value)
        {
            string expected = value;
            string result = Shield.FromWhiteSpaceString(value);
            Assert.AreEqual(expected, result);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        [TestCase("\n\n\n\r\r")]
        public void FromWhiteSpaceString(string value)
        {
            TestDelegate t = () => Shield.FromWhiteSpaceString(value);
            Assert.Throws<ArgumentException>(t);
        }

        [TestCase("some text")]
        [TestCase("x")]
        [TestCase("even more test")]
        [TestCase("old McDonald had a farm...and it exploded!")]
        public void FromInvalidString_WithValidStrings_ShouldReturnTheStringItself(string value)
        {
            string expected = value;
            string result = Shield.FromInvalidString(value);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FromInvalidString_PassingNullReference_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => Shield.FromInvalidString(null));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        [TestCase("\n\n\n\r\r")]
        public void FromInvalidString(string value)
        {
            Assert.Throws<ArgumentException>(
                () => Shield.FromInvalidString(value));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("\n\n\n\n")]
        [TestCase("non-null string")]
        public void FromNull_PassingNonNullStrings_ReturnsTheObjectsThemselves(string value)
        {
            string expected = value;
            string result = Shield.FromNull(value);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FromNull()
        {
            string value = null;
            Assert.Throws<ArgumentNullException>(() => Shield.FromNull(value));
        }
    }
}
