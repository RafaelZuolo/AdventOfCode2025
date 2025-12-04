using AdventOfCode2025.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class Day01Tests
{
    const string input =
@"L68
L30
R48
L5
R60
L55
L1
L99
R14
L82
";

    [Fact]
    public void Day01SolvePart1()
    {
        var answer = new Day01().SolvePart1(input);

        answer.Should().Be("3");
    }

    [Fact]
    public void Day01SolvePart2()
    {
        var answer = new Day01().SolvePart2(input);

        answer.Should().Be("6");
    }
}
