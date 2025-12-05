using AdventOfCode2025;
using AdventOfCode2025.Utils;

public class Day05 : IDay
{
    public string SolvePart1(string input)
    {
        var splitInput = input.Split(
            Environment.NewLine + Environment.NewLine,
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var ranges = splitInput[0].ParseLines()
            .Select(l =>
            {
                var t = l.Split('-');
                return new FreshRange(long.Parse(t[0]), long.Parse(t[1]));
            })
            .ToArray();
        var ingredients = splitInput[1].ParseLines().Select(long.Parse).ToArray();

        return ingredients.Where(i => ranges.Any(r => r.IsFresh(i))).Count().ToString();
    }

    public record FreshRange(long Start, long End)
    {
        public bool IsFresh(long ingredient) => Start <= ingredient && ingredient <= End;
    }

    public string SolvePart2(string input)
    {
        var splitInput = input.Split(
            Environment.NewLine + Environment.NewLine,
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var ranges = splitInput[0].ParseLines()
            .Select(l =>
            {
                var t = l.Split('-');
                return new FreshRange(long.Parse(t[0]), long.Parse(t[1]));
            })
            .OrderBy(f => f.Start)
            .ToArray();

        var rangeSet = new HashSet<FreshRange>();
        for (var i = 0; i < ranges.Length - 1; i++)
        {
            var processed = ProcessRanges(ranges[i], ranges[i + 1]);
            if (processed.Length == 1)
            {
                ranges[i + 1] = processed[0];
                if (i == ranges.Length - 2)
                {
                    rangeSet.Add(processed[0]);
                }
            }
            else
            {
                rangeSet.Add(processed[0]);
                if (i == ranges.Length - 2)
                {
                    rangeSet.Add(processed[1]);
                }
            }
        }

        return rangeSet.Select(f => f.End - f.Start + 1).Sum().ToString();
    }

    public FreshRange[] ProcessRanges(FreshRange a, FreshRange b)
    {
        if (a.End < b.Start || b.End < a.Start) return [a, b];

        var lowerStart = Math.Min(a.Start, b.Start);
        var higherEnd = Math.Max(a.End, b.End);

        return [new FreshRange(lowerStart, higherEnd)];
    }
}