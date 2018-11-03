using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace IllAdvisedRegex.Test
{
    [TestClass]
    public class GreaterThanOrEqualToTests
    {
        // NOTE: This has a dependency on GreaterThanOrEqualMagnitude, and LessThanOrEqualMagnitude.
        // These tests are just for added behavior.

        [TestMethod]
        public void GreaterThanOrEqualTo_Negative_RegexMatches_NegativeCloserToZero()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanOrEqualTo(-9);
            string matchTo = "-8";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_Negative_RegexMatches_Zero()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanOrEqualTo(-9);
            string matchTo = "0";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_Negative_RegexMatches_Positive()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanOrEqualTo(-9);
            string matchTo = "9";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_Negative_RegexMatches_Self()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanOrEqualTo(-9);
            string matchTo = "-9";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void GreaterThanOrEqualTo_Negative_RegexDoesNotMatch_MoreNegative()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanOrEqualTo(-123);

            Assert.IsFalse(Regex.Match("-124", pattern).Success);
            Assert.IsFalse(Regex.Match("-1230", pattern).Success);
            Assert.IsFalse(Regex.Match("-1000", pattern).Success);
            Assert.IsFalse(Regex.Match("-9999", pattern).Success);
            Assert.IsFalse(Regex.Match("-999999999999999999999999999999", pattern).Success);
        }
    }
}
