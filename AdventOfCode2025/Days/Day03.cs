namespace AdventOfCode2025.Days;

public class Day03 : IDay
{
    public string SolvePart1(string input)
    {
        var parsedInput = input
            .Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.ToCharArray())
            .ToArray();

        long sum = 0;
        foreach (var line in parsedInput)
        {
            var highestIndex = 0;
            var highest = line[0];

            for (int i = 1; i < line.Length - 1; i++)
            {
                if (highest < line[i])
                {
                    highest = line[i];
                    highestIndex = i;
                }
            }

            if (highestIndex == line.Length - 2)
            {
                sum += long.Parse([highest, line.Last()]);
                continue;
            }

            var secondHighest = line[highestIndex + 1];
            for (int i = highestIndex + 2; i < line.Length; i++)
            {
                if (secondHighest < line[i]) secondHighest = line[i];
            }

            sum += long.Parse([highest, secondHighest]);
        }

        return sum.ToString();
    }

    public string SolvePart2(string input)
    {
        var bankSize = 12;

        var parsedInput = input
            .Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        long sum = 0;
        foreach (var line in parsedInput)
        {
            sum += Greedy(line, bankSize);
        }

        return sum.ToString();
    }

    private static long Greedy(string line, int bankSize)
    {
        var answer = new List<char>();
        Greedy(line, answer, bankSize);

        return long.Parse(answer.ToArray());
    }

    private static void Greedy(string line, List<char> answer, int bankSize)
    {
        if (bankSize == 0) return;

        var highestIndex = 0;
        var highest = line[0];

        foreach (var c in line[..(line.Length - bankSize + 1)])
        {
            if (highest < c)
            {
                highest = c;
                highestIndex = line.IndexOf(c);
            }
        }

        answer.Add(highest);

        Greedy(line[(highestIndex + 1)..], answer, bankSize - 1);
    }
}
