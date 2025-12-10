using AdventOfCode2025.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class Day10Tests
{
    private const string input =
@"[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
";

    [Fact]
    public void Day10Part1()
    {
        var output = new Day10().SolvePart1(input);

        output.Should().Be("7");
    }

    [Fact]
    public void Day10Part2()
    {
        var output = new Day10().SolvePart2(input);

        output.Should().Be("33");
    }
}
