using AdventOfCode2025.Utils;

namespace AdventOfCode2025.Days;

public class Day04 : IDay
{
    public string SolvePart1(string input)
    {
        var wall = input.ParseAsMatrix(c => c);
        var count = 0;
        for (int i = 0; i < wall.Length; i++)
        {
            for (int j = 0; j < wall[0].Length; j++)
            {
                if (wall[i][j] is '.') continue;
                if (CountNeighbors(wall, i, j) < 4) count++;
            }
        }

        return count.ToString();
    }

    public static int CountNeighbors(char[][] wall, int i, int j)
    {
        var rolls = 0;
        for (int x = Math.Max(i - 1, 0); x <= Math.Min(i + 1, wall.Length - 1); x++)
        {
            for (int y = Math.Max(j - 1, 0); y <= Math.Min(j + 1, wall[0].Length - 1); y++)
            {
                if (x == i && y == j) continue;
                if (wall[x][y] is '@') rolls++;
            }
        }

        return rolls;
    }

    public string SolvePart2(string input)
    {
        var wall = input.ParseAsMatrix(c => c);

        var previousCount = 0;
        var count = 0;

        do
        {
            previousCount = count;
            for (int i = 0; i < wall.Length; i++)
            {
                for (int j = 0; j < wall[0].Length; j++)
                {
                    if (wall[i][j] is '.') continue;
                    if (CountNeighbors(wall, i, j) < 4)
                    {
                        count++;
                        wall[i][j] = '.';
                    }
                }
            }
        } while (previousCount != count);

        return count.ToString();
    }
}
