using carlosschults.NShield;
using NUnit.Framework;
using System;

namespace NShield.Tests
{
    public class Tests
    {
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
        public void Excecao()
        {
            TestDelegate t = () => Shield.AgainstEmptyString(string.Empty);
            Assert.Throws<ArgumentException>(t);
        }
    }
}