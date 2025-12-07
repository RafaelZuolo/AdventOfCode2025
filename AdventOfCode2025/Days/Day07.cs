using AdventOfCode2025.Utils;

namespace AdventOfCode2025.Days;

public class Day07 : IDay
{
    public string SolvePart1(string input)
    {
        var manifold = input.ParseAsCharMatrix();

        long splits = 0;
        for (int i = 1; i < manifold.Length; i++)
        {
            for (int j = 0; j < manifold[i].Length; j++)
            {
                if (manifold[i - 1][j] is 'S' or '|')
                {
                    if (manifold[i][j] is '^')
                    {
                        splits++;
                        manifold[i][j - 1] = '|';
                        manifold[i][j + 1] = '|';
                    }
                    else
                    {
                        manifold[i][j] = '|';
                    }
                }
            }
        }

        return splits.ToString();
    }

    public string SolvePart2(string input)
    {
        var manifold = input.ParseAsCharMatrix();

        var timelines = new long[manifold.Length][];
        for (var row = 0; row < timelines.Length; row++) timelines[row] = new long[manifold[row].Length];

        for (int i = 1; i < manifold.Length; i++)
        {
            for (int j = 0; j < manifold[i].Length; j++)
            {
                if (manifold[i - 1][j] is 'S')
                {
                    manifold[i][j] = '|';
                    timelines[i][j] = 1;
                }
                if (manifold[i - 1][j] is '|')
                {
                    if (manifold[i][j] is '^')
                    {
                        manifold[i][j - 1] = '|';
                        timelines[i][j - 1] += timelines[i - 1][j];
                        manifold[i][j + 1] = '|';
                        timelines[i][j + 1] += timelines[i - 1][j];
                    }
                    else
                    {
                        manifold[i][j] = '|';
                        timelines[i][j] += timelines[i - 1][j];
                    }
                }
            }
        }

        return timelines.Last().Sum().ToString();
    }
}
