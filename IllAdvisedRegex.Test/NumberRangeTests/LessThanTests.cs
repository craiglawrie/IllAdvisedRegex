using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace IllAdvisedRegex.Test
{
    [TestClass]
    public class LessThanTests
    {
        // NOTE: This has a dependency on GreaterThanMagnitude, and LessThanMagnitude.
        // These tests are just for added behavior.

        [TestMethod]
        public void LessThan_Positive_RegexMatches_SmallNegative()
        {
            string pattern = GetNumberRangePattern.ForLessThan(9);
            string matchTo = "-8";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThan_Positive_RegexMatches_VeryNegative()
        {
            string pattern = GetNumberRangePattern.ForLessThan(9);
            string matchTo = "-88888888888888888888888";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThan_Positive_RegexMatches_0()
        {
            string pattern = GetNumberRangePattern.ForLessThan(9);
            string matchTo = "0";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThan_0_RegexMatches_SmallNegative()
        {
            string pattern = GetNumberRangePattern.ForLessThan(0);
            string matchTo = "-1";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThan_0_RegexMatches_VeryNegative()
        {
            string pattern = GetNumberRangePattern.ForLessThan(0);
            string matchTo = "-999999999999999999999999999999999";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThan_Negative_RegexMatches_OneSmaller()
        {
            string pattern = GetNumberRangePattern.ForLessThan(-51);
            string matchTo = "-52";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void LessThan_Negative_RegexMatches_MuchSmaller()
        {
            string pattern = GetNumberRangePattern.ForLessThan(-51);
            string matchTo = "-525252525252";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }
        
        [TestMethod]
        public void LessThan_Negative_RegexDoesNotMatch_Self()
        {
            string pattern = GetNumberRangePattern.ForLessThan(-9);

            Assert.IsFalse(Regex.Match("-9", pattern).Success);
        }

        [TestMethod]
        public void LessThan_Negative_RegexDoesNotMatch_MorePositive()
        {
            string pattern = GetNumberRangePattern.ForLessThan(-9);

            Assert.IsFalse(Regex.Match("-8", pattern).Success);
            Assert.IsFalse(Regex.Match("0", pattern).Success);
            Assert.IsFalse(Regex.Match("9", pattern).Success);
            Assert.IsFalse(Regex.Match("999", pattern).Success);
        }
    }
}
