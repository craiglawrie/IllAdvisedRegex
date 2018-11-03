using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace IllAdvisedRegex.Test
{
    [TestClass]
    public class LessThanOrEqualMagnitudeTests
    {
        [TestMethod]
        public void LessThanOrEqualM_SingleDigit_RegexMatches_SmallerSingleDigit()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(2);
            string matchTo = "1";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThanOrEqualM_MultiDigit_RegexMatches_SmallerSameDigitCountMin()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(9999);
            string matchTo = "1000";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThanOrEqualM_MultiDigit_RegexMatches_SmallerSameDigitCountMinusOne()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(9999);
            string matchTo = "9998";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThanOrEqualM_MultiDigit_RegexMatches_0()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(9999);
            string matchTo = "0";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThanOrEqualM_NumberWithinText_RegexMatches_JustSmallerNumber()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(1000);
            string matchToNumber = "999";
            string matchTo = $"Abc{matchToNumber} Hello World!";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchToNumber, match.Value);
        }

        [TestMethod]
        public void LessThanOrEqualM_SingleDigit_RegexMatches_Same()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(2);
            string matchTo = "2";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }
        
        [TestMethod]
        public void LessThanOrEqualM_SingleDigit_RegexDoesNotMatch_LargerSingleDigit()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(2);

            Assert.IsFalse(Regex.Match("3", pattern).Success);
            Assert.IsFalse(Regex.Match("4", pattern).Success);
            Assert.IsFalse(Regex.Match("5", pattern).Success);
            Assert.IsFalse(Regex.Match("6", pattern).Success);
            Assert.IsFalse(Regex.Match("7", pattern).Success);
            Assert.IsFalse(Regex.Match("8", pattern).Success);
            Assert.IsFalse(Regex.Match("9", pattern).Success);
        }

        [TestMethod]
        public void LessThanOrEqualM_MultiDigit_RegexMatches_Same()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(1234);
            string matchTo = "1234";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThanOrEqualM_MultiDigit_RegexDoesNotMatch_LargerSameDigitCount()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(1000);

            Assert.IsFalse(Regex.Match("1001", pattern).Success);
            Assert.IsFalse(Regex.Match("9999", pattern).Success);
        }

        [TestMethod]
        public void LessThanOrEqualM_0_RegexMatches_Self()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(0);
            string matchTo = "0";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThanOrEqualM_MultiDigit_RegexDoesNotMatch_LargerMoreDigits()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(1000);

            Assert.IsFalse(Regex.Match("10000", pattern).Success);
            Assert.IsFalse(Regex.Match("101000", pattern).Success);
            Assert.IsFalse(Regex.Match("100000000000000000000000000000", pattern).Success);
        }

        [TestMethod]
        public void LessThanOrEqualM_MultiDigit_RegexDoesNotMatch_LeadingZero()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualMagnitude(1000);

            Assert.IsFalse(Regex.Match("010", pattern).Success);
        }
    }
}