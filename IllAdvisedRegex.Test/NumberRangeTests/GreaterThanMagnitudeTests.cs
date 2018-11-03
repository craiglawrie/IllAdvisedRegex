using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace IllAdvisedRegex.Test
{
    [TestClass]
    public class GreaterThanMagnitudeTests
    {
        [TestMethod]
        public void GreaterThanM_SingleDigit_RegexMatches_LargerSingleDigit()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(1);
            string matchTo = "9";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }
        
        [TestMethod]
        public void GreaterThanM_SingleDigit_RegexMatches_MultiDigit()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(1);
            string matchTo = "222";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void GreaterThanM_SingleDigit_RegexDoesNotMatch_Self()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(1);

            Assert.IsFalse(Regex.Match("1", pattern).Success);
        }

        [TestMethod]
        public void GreaterThanM_SingleDigit_RegexDoesNotMatch_SmallerSingleDigit()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(9);

            Assert.IsFalse(Regex.Match("0", pattern).Success);
            Assert.IsFalse(Regex.Match("1", pattern).Success);
            Assert.IsFalse(Regex.Match("2", pattern).Success);
            Assert.IsFalse(Regex.Match("3", pattern).Success);
            Assert.IsFalse(Regex.Match("4", pattern).Success);
            Assert.IsFalse(Regex.Match("5", pattern).Success);
            Assert.IsFalse(Regex.Match("6", pattern).Success);
            Assert.IsFalse(Regex.Match("7", pattern).Success);
            Assert.IsFalse(Regex.Match("8", pattern).Success);
        }

        [TestMethod]
        public void GreaterThanM_MultiDigit_RegexMatches_LargerSameDigitCount()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(1234);
            string matchTo = "1235";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void GreaterThanM_MultiDigit_RegexMatches_LargerMoreDigits()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(1234);
            string matchTo = "12345";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void GreaterThanM_MultiDigit_RegexDoesNotMatch_SelfMin()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(1000);

            Assert.IsFalse(Regex.Match("1000", pattern).Success);
        }

        [TestMethod]
        public void GreaterThanM_MultiDigit_RegexDoesNotMatch_SelfMax()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(9999);

            Assert.IsFalse(Regex.Match("9999", pattern).Success);
        }

        [TestMethod]
        public void GreaterThanM_MultiDigit_RegexDoesNotMatch_SmallerSameDigits()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(1234);

            Assert.IsFalse(Regex.Match("1233", pattern).Success);
            Assert.IsFalse(Regex.Match("1000", pattern).Success);
            Assert.IsFalse(Regex.Match("0000", pattern).Success);
            Assert.IsFalse(Regex.Match("1111", pattern).Success);
        }

        [TestMethod]
        public void GreaterThanM_MultiDigit_RegexDoesNotMatch_SmallerFewerDigits()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(1234);

            Assert.IsFalse(Regex.Match("999", pattern).Success);
            Assert.IsFalse(Regex.Match("100", pattern).Success);
            Assert.IsFalse(Regex.Match("99", pattern).Success);
            Assert.IsFalse(Regex.Match("10", pattern).Success);
            Assert.IsFalse(Regex.Match("9", pattern).Success);
            Assert.IsFalse(Regex.Match("1", pattern).Success);
            Assert.IsFalse(Regex.Match("0", pattern).Success);
        }

        [TestMethod]
        public void GreaterThanM_NumberWithinText_RegexMatches_JustLargerNumber()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(1234);
            string matchToNumber = "12345";
            string matchTo = $"Abc{matchToNumber} Hello World!";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchToNumber, match.Value);
        }

        [TestMethod]
        public void GreaterThanM_0_RegexMatches_Positive()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanMagnitude(0);
            string matchTo = "1";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }
    }
}
