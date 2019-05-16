using carlosschults.NShield;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [TestCase(null)]
        [TestCase("doesn't look like an empty string!")]
        [TestCase(" ")]
        [TestCase("\n\n\r")]
        public void FromEmptyStringWithNamedParameter_WithNonEmptyString_ShouldReturnTheStringItself(string value)
        {
            string expected = value;
            string result = Shield.FromEmptyString(value, "someParameter");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FromEmptyString()
        {
            TestDelegate t = () => Shield.FromEmptyString(string.Empty);
            Assert.Throws<ArgumentException>(t);
        }

        [Test]
        public void FromEmptyString_PassingParameterName()
        {
            TestDelegate action = () => Shield.FromEmptyString(string.Empty, "paramName");

            Assert.That(action,
                Throws.Exception
                  .TypeOf<ArgumentException>()
                  .With.Property("ParamName")
                  .EqualTo("paramName"));
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

        [TestCase(null)]
        [TestCase("some text")]
        [TestCase("x")]
        [TestCase("even more test")]
        [TestCase("old McDonald had a farm...and it exploded!")]
        public void FromWhiteSpaceStringPassingParameterName_WithNonWhiteSpaceString_ReturnsTheStringItself(string value)
        {
            string expected = value;
            string result = Shield.FromWhiteSpaceString(value, "paramName");
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

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        [TestCase("\n\n\n\r\r")]
        public void FromWhiteSpaceString_PassingParameterName(string value)
        {
            TestDelegate t = () => Shield.FromWhiteSpaceString(value, "someVar");

            Assert.That(t,
                Throws.Exception
                  .TypeOf<ArgumentException>()
                  .With.Property("ParamName")
                  .EqualTo("someVar"));
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

        [TestCase("some text")]
        [TestCase("x")]
        [TestCase("even more test")]
        [TestCase("old McDonald had a farm...and it exploded!")]
        public void FromInvalidString_WithValidStringsAndPassingParamName_ShouldReturnTheStringItself(string value)
        {
            string expected = value;
            string result = Shield.FromInvalidString(value, "someParamName");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FromInvalidString_PassingNullReference_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => Shield.FromInvalidString(null));
        }

        [Test]
        public void FromInvalidString_PassingNullReferenceAndParamName_Throws()
        {
            TestDelegate action = () => Shield.FromInvalidString(null, "someParamName");

            Assert.That(action,
                Throws.Exception
                  .TypeOf<ArgumentNullException>()
                  .With.Property("ParamName")
                  .EqualTo("someParamName"));
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
        [TestCase("    ")]
        [TestCase("\n\n\n\r\r")]
        public void FromInvalidString_WithParamName(string value)
        {
            TestDelegate action = () => Shield.FromInvalidString(value, "someParamName");

            Assert.That(action,
                Throws.Exception
                  .TypeOf<ArgumentException>()
                  .With.Property("ParamName")
                  .EqualTo("someParamName"));
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

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("\n\n\n\n")]
        [TestCase("non-null string")]
        public void FromNull_PassingNonNullStringsAndParameterName_ReturnsTheObjectsThemselves(string value)
        {
            string expected = value;
            string result = Shield.FromNull(value, "someParamName");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FromNull()
        {
            string value = null;
            Assert.Throws<ArgumentNullException>(() => Shield.FromNull(value));
        }

        [Test]
        public void FromNull_WithNamedParameter()
        {
            string value = null;
            TestDelegate action = () => Shield.FromNull(value, paramName: "someVar");

            Assert.That(action,
                Throws.Exception
                  .TypeOf<ArgumentNullException>()
                  .With.Property("ParamName")
                  .EqualTo("someVar"));
        }

        [Test]
        public void FromEmptySequence_PassingNonEmptySequence_ReturnsTheSequenceItself()
        {
            IEnumerable<int> expected = new[] { 1, 2, 3, 4, 5 };
            var result = Shield.FromEmptySequence(expected);
            Assert.True(expected.SequenceEqual(result));
        }

        [Test]
        public void FromEmptySequence_PassingNonEmptySequenceAndParameterName_ReturnsTheSequenceItself()
        {
            IEnumerable<int> expected = new[] { 1, 2, 3, 4, 5 };
            var result = Shield.FromEmptySequence(expected, "numbers");
            Assert.True(expected.SequenceEqual(result));
        }

        [Test]
        public void FromEmptySequence_PassingNull_ReturnsNull()
        {
            IEnumerable<int> expected = null;
            var result = Shield.FromEmptySequence(expected);
            Assert.Null(result);
        }

        [Test]
        public void FromEmptySequence_PassingNullAndParameterName_ReturnsNull()
        {
            IEnumerable<int> expected = null;
            var result = Shield.FromEmptySequence(expected, "numbers");
            Assert.Null(result);
        }

        [Test]
        public void FromEmptySequence()
        {
            TestDelegate t =
                () => Shield.FromEmptySequence(Enumerable.Empty<string>());
            Assert.Throws<ArgumentException>(t);
        }

        [Test]
        public void FromEmptySequence_WithParameterName()
        {
            TestDelegate t =
                () => Shield.FromEmptySequence(Enumerable.Empty<string>(), "names");
            Assert.Throws<ArgumentException>(t);
        }
    }
}
