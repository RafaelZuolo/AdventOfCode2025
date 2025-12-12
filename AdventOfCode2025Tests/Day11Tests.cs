using AdventOfCode2025.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class Day11Tests
{
    private const string input =
@"aaa: you hhh
you: bbb ccc
bbb: ddd eee
ccc: ddd eee fff
ddd: ggg
eee: out
fff: out
ggg: out
hhh: ccc fff iii
iii: out";

    [Fact]
    public void Day11Part1()
    {
        var output = new Day11().SolvePart1(input);

        output.Should().Be("5");
    }

    private const string input2 =
@"svr: aaa bbb
aaa: fft
fft: ccc
bbb: tty
tty: ccc
ccc: ddd eee
ddd: hub
hub: fff
eee: dac
dac: fff
fff: ggg hhh
ggg: out
hhh: out";

    [Fact]
    public void Day11Part2()
    {
        var output = new Day11().SolvePart2(input2);

        output.Should().Be("2");
    }
}
