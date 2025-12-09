using AdventOfCode2025.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class Day09Tests
{
    private const string input =
@"7,1
11,1
11,7
9,7
9,5
2,5
2,3
7,3
";

    [Fact]
    public void Day9Part1()
    {
        var output = new Day09().SolvePart1(input);

        output.Should().Be("50");
    }

    [Fact]
    public void Day9Part2()
    {
        var output = new Day09().SolvePart2(input);

        output.Should().Be("24");
    }

    [Fact]
    public void Day9Part2Other()
    {
        var output = new Day09().SolvePart2(input2);

        output.Should().Be("28");
    }

    private const string input2 =
@"1,0
0,0
0,9
3,9
3,3
4,3
4,1
2,2
2,2
1,2
";
}