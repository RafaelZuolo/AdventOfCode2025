using AdventOfCode2025.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class Day04Tests
{
    string input =
@"..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.
";

    [Fact]
    public void Day04Part1()
    {
        var output = new Day04().SolvePart1(input);

        output.Should().Be("13");
    }

    [Fact]
    public void Day04Part2()
    {
        var output = new Day04().SolvePart2(input);

        output.Should().Be("43");
    }
}
