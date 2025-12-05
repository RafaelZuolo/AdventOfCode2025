using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;
public class Day05Tests
{
    string input =
@"3-5
10-14
16-20
12-18

1
5
8
11
17
32
";

    [Fact]
    public void Day05Part1()
    {
        var output = new Day05().SolvePart1(input);

        output.Should().Be("3");
    }

    [Fact]
    public void Day05Part2()
    {
        var output = new Day05().SolvePart2(input);

        output.Should().Be("14");
    }

    string otherinput =
@"3-5
10-14
12-13
16-20

1
";

    [Fact]
    public void Day05Part2Tests()
    {
        var output = new Day05().SolvePart2(otherinput);

        output.Should().Be("13");
    }
}
