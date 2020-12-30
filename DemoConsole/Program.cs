using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IllAdvisedRegex;

namespace DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Hello. What number range would you like to match?");
                Console.WriteLine("You can write '<=AAA', '<AAA', '>=AAA', or '>AAA' or 'q' to quit.");
                Console.Write("Your range:  ");
                string range = Console.ReadLine();
                Console.WriteLine();
                var numbers = Regex.Matches(range, "[\\d\\-]+").OfType<Match>().Select(m => int.Parse(m.Value)).ToList();

                string pattern;
                if (range.StartsWith("<=") && numbers.Count == 1)
                {
                    pattern = GetNumberRangePattern.ForLessThanOrEqualTo(numbers[0]);
                }
                else if (range.StartsWith("<") && numbers.Count == 1)
                {
                    pattern = GetNumberRangePattern.ForLessThan(numbers[0]);
                }
                else if (range.StartsWith(">=") && numbers.Count == 1)
                {
                    pattern = GetNumberRangePattern.ForGreaterThanOrEqualTo(numbers[0]);
                }
                else if (range.StartsWith(">") && numbers.Count == 1)
                {
                    pattern = GetNumberRangePattern.ForGreaterThan(numbers[0]);
                }
                else if (range.ToLower().StartsWith("q"))
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid format. Please try again.");
                    continue;
                }

                Console.WriteLine($"The regex pattern to match '{range}' is:");
                Console.WriteLine(pattern);
                Console.WriteLine();

                Console.Write("What number would you like to check with this pattern? ");
                var toCheck = Console.ReadLine();
                var check = Regex.IsMatch(toCheck, pattern);

                if (check)
                {
                    Console.WriteLine($"Success! {toCheck} meets the condition {range}.");
                }
                else
                {
                    Console.WriteLine($"No, {toCheck} does not meet the condition {range}.");
                }
                Console.ReadLine();
                Console.Clear();

            } while (true);
        }
    }
}
