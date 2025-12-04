using AdventOfCode2025.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class Day02Tests
{
    private const string input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

    [Fact]

    public void Day02Part1()
    {
        var output = new Day02().SolvePart1(input);

        output.Should().Be("1227775554");
    }

    [Fact]
    public void Day02Part2()
    {
        var output = new Day02().SolvePart2(input);

        output.Should().Be("4174379265");
    }

    [Fact]
    public void Day02IsSilly()
    {
        _ = new Day02().IsSilly(11).Should().BeTrue();
        _ = new Day02().IsSilly(22).Should().BeTrue();
        _ = new Day02().IsSilly(99).Should().BeTrue();
        _ = new Day02().IsSilly(111).Should().BeTrue();
        _ = new Day02().IsSilly(999).Should().BeTrue();
        _ = new Day02().IsSilly(1010).Should().BeTrue();
        _ = new Day02().IsSilly(1188511885).Should().BeTrue();
        _ = new Day02().IsSilly(222222).Should().BeTrue();
        _ = new Day02().IsSilly(446446).Should().BeTrue();
        _ = new Day02().IsSilly(38593859).Should().BeTrue();
        _ = new Day02().IsSilly(565656).Should().BeTrue();
        _ = new Day02().IsSilly(824824824).Should().BeTrue();
        _ = new Day02().IsSilly(2121212121).Should().BeTrue();
    }
}
