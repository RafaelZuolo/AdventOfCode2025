using AdventOfCode2025.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class Day03Tests
{
    string input =
@"987654321111111
811111111111119
234234234234278
818181911112111
";

    [Fact]
    public void Day03Part1()
    {
        var output = new Day03().SolvePart1(input);

        output.Should().Be("357");
    }

    [Fact]
    public void Day03Part2()
    {
        var output = new Day03().SolvePart2(input);

        output.Should().Be("3121910778619");
    }
}
