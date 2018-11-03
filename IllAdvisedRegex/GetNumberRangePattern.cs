using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("IllAdvisedRegex.Test")]
namespace IllAdvisedRegex
{
    public static class GetNumberRangePattern
    {
        private static readonly string _notNegative = @"(?<![\-\d])";

        public static string ForGreaterThan(int number)
        {
            return ForGreaterThanOrEqualTo(number + 1);
        }

        public static string ForGreaterThanOrEqualTo(int number)
        {
            if (number >= 0)
            {
                return ForGreaterThanOrEqualMagnitude(number);
            }
            else
            {
                return @"(\-" + ForLessThanOrEqualMagnitude(Math.Abs(number)) + @"|" + 
                    _notNegative + ForGreaterThanOrEqualMagnitude(0) + @")";
            }
        }

        public static string ForLessThan(int number)
        {
            return ForLessThanOrEqualTo(number - 1);
        }

        public static string ForLessThanOrEqualTo(int number)
        {
            if (number >= 0)
            {
                return @"(" + ForLessThanOrEqualMagnitude(number) + @"|\-" + 
                    ForGreaterThanOrEqualMagnitude(0) + ")";
            }
            else
            {
                return @"\-" + ForGreaterThanOrEqualMagnitude(Math.Abs(number));
            }
        }

        internal static string ForLessThanMagnitude(int number)
        {
            return ForLessThanOrEqualMagnitude(number - 1);
        }

        internal static string ForLessThanOrEqualMagnitude(int number)
        {
            string numString = number.ToString();
            string result = @"(";

            // Case for same digit count but smaller
            result += @"[1-" + numString[0] + @"]";
            for (int i = 1; i < numString.Length; i++)
            {
                result += @"[0-" + numString[i] + @"]";
            }

            // Case for fewer digits
            if (numString.Length > 1)
            {
                result += @"|[1-9][0-9]{0," + (numString.Length - 2) + @"}";
            }

            // Case for zero
            result += @"|0";

            if (numString == "0")
            {
                result = @"(0";
            }

            // Ensure it's not a substring of a larger number
            result = @"(?<=(\b|[^\d]))" + result + @")(?=(\b|[^\d]))";

            return result;
        }

        internal static string ForGreaterThanMagnitude(int number)
        {
            string numString = number.ToString();

            // Case for number with more digits
            string result = @"([1-9][0-9]{" + numString.Length + @",}";

            // Case for number with same digits, leading 'i' digits match
            for (int i = 0; i < numString.Length; i++)
            {
                int digit = int.Parse(numString[i].ToString());
                if (digit < 9)
                {
                    result += @"|";
                    for (int j = 0; j < i; j++)
                    {
                        result += numString[j];
                    }

                    result += @"[" + (digit + 1) + @"-9][0-9]{" + (numString.Length - i - 1) + @"}";
                }
            }
            result += @")";

            return result;
        }

        internal static string ForGreaterThanOrEqualMagnitude(int number)
        {
            if (number == 0)
            {
                return @"([1-9][0-9]*|[0-9])";
            }
            else
            {
                return ForGreaterThanMagnitude(number - 1);
            }
        }
    }
}
