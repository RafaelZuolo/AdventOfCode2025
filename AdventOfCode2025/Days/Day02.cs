namespace AdventOfCode2025.Days;

public class Day02 : IDay
{
    public string SolvePart1(string input)
    {
        var parsedInput = input
            .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(s =>
            {
                var split = s.Split('-');
                return new Range(long.Parse(split[0]), long.Parse(split[1]));
            })
            .ToList();

        long totalSum = 0;

        foreach (var range in parsedInput)
        {
            for (var i = range.Start; i <= range.End; i++)
            {
                var id = i.ToString();
                if (id.Length % 2 != 0) continue;
                if (id[(id.Length / 2)..] == id[..(id.Length / 2)]) totalSum += i;
            }
        }

        return totalSum.ToString();
    }

    public record Range(long Start, long End);

    public string SolvePart2(string input)
    {
        var parsedInput = input
            .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(s =>
            {
                var split = s.Split('-');
                return new Range(long.Parse(split[0]), long.Parse(split[1]));
            })
            .ToList();

        long totalSum = 0;

        foreach (var range in parsedInput)
        {
            for (var i = range.Start; i <= range.End; i++)
            {
                if (IsSilly(i)) totalSum += i;
            }
        }

        return totalSum.ToString();
    }

    public bool IsSilly(long value)
    {
        var id = value.ToString();
        var length = id.Length;
        for (int i = 1; i <= length / 2; i++)
        {
            if (length % i != 0) continue;
            var parts = ToChunks(id, i).ToArray();
            var firstPart = parts[0];
            var flag = true;
            foreach (var part in parts)
            {
                if (firstPart != part)
                {
                    flag = false;
                    break;
                }
            }

            if (!flag)
            {
                continue;
            }

            return true;
        }

        return false;
    }

    private IEnumerable<string> ToChunks(string id, int size)
    {
        for (int i = 0; i < id.Length / size; i++)
        {
            yield return id.Substring(i * size, size);
        }
    }
}
