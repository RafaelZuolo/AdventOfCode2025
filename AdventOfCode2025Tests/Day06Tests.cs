using AdventOfCode2025.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class Day06Tests
{
    string modifiedinputPart1 =
@"123 328  51 64 
 45 64  387 23 
  6 98  215 314
  1 0 1 0 
*   +   *   +  
";

    [Fact]
    public void Day06Part1()
    {
        var output = new Day06().SolvePart1(modifiedinputPart1);

        output.Should().Be("4277556");
    }

    string input =
@"123 328  51 64 
 45 64  387 23 
  6 98  215 314
*   +   *   +  ";

    [Fact]
    public void Day06Part2()
    {
        var output = new Day06().SolvePart2(input);

        output.Should().Be("3263827");
    }
}
