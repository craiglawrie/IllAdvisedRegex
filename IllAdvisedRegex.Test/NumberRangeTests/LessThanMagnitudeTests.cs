using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace IllAdvisedRegex.Test
{
    [TestClass]
    public class LessThanMagnitudeTests
    {
        // NOTE: This has a dependency on LessThanOrEqualMagnitude. These tests are just for added behavior.

        [TestMethod]
        public void LessThanM_SingleDigit_RegexDoesNotMatch_Self()
        {
            string pattern = GetNumberRangePattern.ForLessThanMagnitude(2);

            Assert.IsFalse(Regex.Match("2", pattern).Success);
        }

        [TestMethod]
        public void LessThanM_MultiDigit_RegexDoesNotMatch_Self()
        {
            string pattern = GetNumberRangePattern.ForLessThanMagnitude(2222);

            Assert.IsFalse(Regex.Match("2222", pattern).Success);
        }
    }
}
