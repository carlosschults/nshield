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

        [Test]
        public void FromInvalidSequence_PassingNonInvalidSequence_ReturnsTheSequenceItself()
        {
            IEnumerable<DateTime> expected = Enumerable.Range(1, 30)
                .Select(x => new DateTime(2019, 5, x));

            var result = Shield.FromInvalidSequence(expected);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FromInvalidSequence_PassingNonInvalidSequenceAndParameterName_ReturnsTheSequenceItself()
        {
            IEnumerable<char> expected = "asdfg";
            var result = Shield.FromInvalidSequence(expected, "letters");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FromInvalidSequence_PassingNull_Throws()
        {
            TestDelegate t = () => Shield.FromInvalidSequence<int>(null);
            Assert.Throws<ArgumentNullException>(t);
        }

        [Test]
        public void FromInvalidSequence_PassingNullAndParameterName_Throws()
        {
            TestDelegate t = () => Shield.FromInvalidSequence<int>(null, "ages");
            Assert.Throws<ArgumentNullException>(t);
        }

        [Test]
        public void FromInvalidSequence_PassingEmptySequence_Throws()
        {
            TestDelegate t =
                () => Shield.FromInvalidSequence(Enumerable.Empty<int>());
            Assert.Throws<ArgumentException>(t);
        }

        [Test]
        public void FromInvalidSequence_PassingEmptySequenceAndParameterName_Throws()
        {
            TestDelegate t =
                () => Shield.FromInvalidSequence(Enumerable.Empty<int>(), "ages");
            Assert.Throws<ArgumentException>(t);
        }

        [TestCase(3)]
        [TestCase(30)]
        [TestCase(300)]
        [TestCase(0)]
        public void FromNegativeNumbers_PassingNonNegativeInteger_ReturnsTheNumberItself(int value)
        {
            Assert.AreEqual(value, Shield.FromNegativeNumber(value));
        }

        [TestCase(3)]
        [TestCase(30)]
        [TestCase(300)]
        [TestCase(0)]
        public void FromNegativeNumbers_PassingNonNegativeIntegerAndParameterName_ReturnsTheNumberItself(int value)
        {
            Assert.AreEqual(value, Shield.FromNegativeNumber(value, "points"));
        }

        [TestCase(-3)]
        [TestCase(-30)]
        [TestCase(-300)]
        [TestCase(-1)]
        public void FromNegativeNumbers(int value)
        {
            TestDelegate t = () => Shield.FromNegativeNumber(value);
            Assert.Throws<ArgumentOutOfRangeException>(t);
        }

        [TestCase(-3)]
        [TestCase(-30)]
        [TestCase(-300)]
        [TestCase(-1)]
        public void FromNegativeNumbersWithParameterName(int value)
        {
            TestDelegate t = () => Shield.FromNegativeNumber(value, "points");
            Assert.Throws<ArgumentOutOfRangeException>(t);
        }

        [TestCase(3.5d)]
        [TestCase(30)]
        [TestCase(300.0002d)]
        [TestCase(0)]
        public void FromNegativeNumbers_PassingNonNegativeDouble_ReturnsTheNumberItself(double value)
        {
            Assert.AreEqual(value, Shield.FromNegativeNumber(value));
        }

        [TestCase(3.234d)]
        [TestCase(12312.21d)]
        [TestCase(300d)]
        [TestCase(0d)]
        public void FromNegativeNumbers_PassingNonNegativeDoubleAndParameterName_ReturnsTheNumberItself(double value)
        {
            Assert.AreEqual(value, Shield.FromNegativeNumber(value, "points"));
        }

        [TestCase(-3d)]
        [TestCase(-30d)]
        [TestCase(-300d)]
        [TestCase(-0.0001d)]
        public void FromNegativeNumbers(double value)
        {
            TestDelegate t = () => Shield.FromNegativeNumber(value);
            Assert.Throws<ArgumentOutOfRangeException>(t);
        }

        [TestCase(-3d)]
        [TestCase(-30d)]
        [TestCase(-300d)]
        [TestCase(-1d)]
        public void FromNegativeNumbersWithParameterName(double value)
        {
            TestDelegate t = () => Shield.FromNegativeNumber(value, "points");
            Assert.Throws<ArgumentOutOfRangeException>(t);
        }

        [TestCase(3.5f)]
        [TestCase(30f)]
        [TestCase(300.0002f)]
        [TestCase(0f)]
        public void FromNegativeNumbers_PassingNonNegativeFloat_ReturnsTheNumberItself(float value)
        {
            Assert.AreEqual(value, Shield.FromNegativeNumber(value));
        }

        [TestCase(3.234f)]
        [TestCase(12312.21f)]
        [TestCase(300f)]
        [TestCase(0f)]
        public void FromNegativeNumbers_PassingNonNegativeFloatAndParameterName_ReturnsTheNumberItself(float value)
        {
            Assert.AreEqual(value, Shield.FromNegativeNumber(value, "points"));
        }

        [TestCase(-3f)]
        [TestCase(-30f)]
        [TestCase(-300f)]
        [TestCase(-0.0001f)]
        public void FromNegativeNumbers(float value)
        {
            TestDelegate t = () => Shield.FromNegativeNumber(value);
            Assert.Throws<ArgumentOutOfRangeException>(t);
        }

        [TestCase(-3f)]
        [TestCase(-30f)]
        [TestCase(-300f)]
        [TestCase(-1f)]
        public void FromNegativeNumbersWithParameterName(float value)
        {
            TestDelegate t = () => Shield.FromNegativeNumber(value, "points");
            Assert.Throws<ArgumentOutOfRangeException>(t);
        }

        [Test]
        public void FromNegativeNumbers_PassingNonNegativeDecimal_ReturnsTheNumberItself()
        {
            decimal value = 123.456m;
            Assert.AreEqual(value, Shield.FromNegativeNumber(value));
        }

        [Test]
        public void FromNegativeNumbers_PassingNonNegativeDecimalAndParameterName_ReturnsTheNumberItself()
        {
            decimal value = 50m;
            Assert.AreEqual(value, Shield.FromNegativeNumber(value, "points"));
        }

        [Test]
        public void FromNegativeNumbers()
        {
            TestDelegate t = () => Shield.FromNegativeNumber(-5.421m);
            Assert.Throws<ArgumentOutOfRangeException>(t);
        }

        [Test]
        public void FromNegativeNumbersWithParameterName()
        {
            TestDelegate t = () => Shield.FromNegativeNumber(-5m, "points");
            Assert.Throws<ArgumentOutOfRangeException>(t);
        }
    }
}
