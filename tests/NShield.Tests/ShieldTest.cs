using carlosschults.NShield;
using NUnit.Framework;

namespace NShield.Tests
{
    public class Tests
    {
        [TestCase]
        public void Test1()
        {
            var expected = "doesn't look like an empty string!";
            string result = Shield.AgainstEmptyString("doesn't look like an empty string!");
            Assert.AreEqual(expected, result);
        }
    }
}