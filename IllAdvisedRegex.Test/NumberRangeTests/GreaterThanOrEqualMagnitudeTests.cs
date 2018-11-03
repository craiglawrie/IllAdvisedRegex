using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace IllAdvisedRegex.Test
{
    [TestClass]
    public class GreaterThanOrEqualMagnitudeTests
    {
        // NOTE: This has a dependency on GreaterThanMagnitude. These tests are just for added behavior.

        [TestMethod]
        public void GreaterThanOrEqualM_0_RegexMatches_0()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanOrEqualMagnitude(0);
            string matchTo = "0";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void GreaterThanOrEqualM_SingleDigit_RegexMatches_Self()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanOrEqualMagnitude(8);
            string matchTo = "8";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }

        [TestMethod]
        public void GreaterThanOrEqualM_MultiDigit_RegexMatches_Self()
        {
            string pattern = GetNumberRangePattern.ForGreaterThanOrEqualMagnitude(8765);
            string matchTo = "8765";

            var match = Regex.Match(matchTo, pattern);
            Assert.IsTrue(match.Success);
            Assert.AreEqual(matchTo, match.Value);
        }
    }
}
