using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace IllAdvisedRegex.Test
{
    [TestClass]
    public class LessThanOrEqualToTests
    {
        // NOTE: This has a dependency on GreaterThanOrEqualMagnitude, and LessThanOrEqualMagnitude.
        // These tests are just for added behavior.

        [TestMethod]
        public void LessThanOrEqualTo_Positive_RegexMatches_Self()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualTo(9);
            string matchTo = "9";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThanOrEqualTo_0_RegexMatches_Self()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualTo(0);
            string matchTo = "0";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThanOrEqualTo_Negative_RegexMatches_Self()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualTo(-110);
            string matchTo = "-110";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThan_Negative_RegexDoesNotMatch_MorePositive()
        {
            string pattern = GetNumberRangePattern.ForLessThanOrEqualTo(-9);

            Assert.IsFalse(Regex.Match("-8", pattern).Success);
            Assert.IsFalse(Regex.Match("0", pattern).Success);
            Assert.IsFalse(Regex.Match("9", pattern).Success);
            Assert.IsFalse(Regex.Match("999", pattern).Success);
        }
    }
}
