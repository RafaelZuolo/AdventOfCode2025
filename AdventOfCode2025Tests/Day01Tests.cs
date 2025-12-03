using AdventOfCode2025.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class Day01Tests
{
    [Fact]
    public void SolvePart1_Test()
    {
        var foo = 0;

        var boo = new Day01();

        boo.Invoking(b => b.SolvePart1("")).Should().Throw<NotImplementedException>();
        foo.Should().Be(0);
    }
}
