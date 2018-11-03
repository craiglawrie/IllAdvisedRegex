# IllAdvisedRegex
Regular expressions are a horrible way to compare integers. If there's a number somewhere in your text, and you need to know that it's within a given range, or that it's greater than 5, or some such requirement, then you really should parse it out, use some kind of integer value comparison, and move on.

On the other hand, if the regex pattern is already generated for you, then there's no real cost. Performance? Maybe, but you might be using regular expressions already to extract an integer with an unknown number of digits. And, building the generator tool is an interesting challenge and fun to do. Perhaps even fun to contribute to!

Beyond that, there are legitimate reasons that you may want to do your number comparisons. Perhaps the allowed number range is dependent in part on what word precedes the number. Perhaps you need to compare a number that has significantly more digits than can be reasonably be parsed. Perhaps there are multiple number ranges within a single string, and the context between them also matters. Perhaps you just want to use regular expressions and can't be bothered to do it the easy way.

## What's in the box
This is a class library in .NET, along with some tests. The tests are not truly unit tests, because checking that the returned string is what was expected is hardly as interesting as whether System.Text.RegularExpressions can match a target with the provided pattern.

## How to contribute
If you would love to add a new regex pattern generation tool to this project, or if you have the itch to refactor my code, or if there's a spelling mistake that you just can't look past anymore, please feel free to fork and fix, or open an issue.

## How to use it
Feel free to grab the .dll and include it as a dependency in your project. Or, clone the whole solution and modify as you need. Public methods are:

* `GetNumberRangePattern.ForGreaterThan(int number)`
* `GetNumberRangePattern.ForGreaterThanOrEqualTo(int number)`
* `GetNumberRangePattern.ForLessThan(int number)`
* `GetNumberRangePattern.ForLessThanOrEqualTo(int number)`

### Example:

`GetNumberRangePattern.ForGreaterThan(-123)` returns `(\\-(?<=(\\b|[^\\d]))([1-1][0-2][0-2]|[1-9][0-9]{0,1}|0)(?=(\\b|[^\\d]))|(?<![\\-\\d])([1-9][0-9]*|[0-9]))` which matches any number from -122 and larger.

Note that regex special characters use backslashes, and the backslashes themselves are escaped by more backslashes for .NET.
