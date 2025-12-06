using AdventOfCode2025.Utils;

namespace AdventOfCode2025.Days;

public class Day06 : IDay
{
    public string SolvePart1(string input)
    {
        var rows = input.ParseLines();
        var row0 = rows[0].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(long.Parse).ToArray();
        var row1 = rows[1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(long.Parse).ToArray();
        var row2 = rows[2].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(long.Parse).ToArray();
        var row3 = rows[3].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(long.Parse).ToArray();
        var operations = rows[4].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        long grandTotal = 0;
        for (int i = 0; i < row0.Length; i++)
        {
            if (operations[i] == "+")
            {
                grandTotal += row0[i] + row1[i] + row2[i] + row3[i];
            }
            else
            {
                grandTotal += row0[i] * row1[i] * row2[i] * row3[i];
            }
        }

        return grandTotal.ToString();
    }

    public string SolvePart2(string input)
    {
        var homework = input.ParseAllAsMatrix(c => c);

        long grandTotal = 0;
        var numbers = new List<long>();

        for (int i = homework[0].Length - 1; i >= 0; i--)
        {
            if (!TryGetNumber(homework, i, out var number))
            {
                continue;
            }
            numbers.Add(number);
            var operation = homework[^1][i];
            if (operation != ' ')
            {
                switch (operation)
                {
                    case '+':
                        grandTotal += numbers.Aggregate((long)0, (current, next) => current + next);
                        break;
                    case '*':
                        grandTotal += numbers.Aggregate((long)1, (current, next) => current * next);
                        break;
                }

                numbers.Clear();
            }
        }

        return grandTotal.ToString();
    }

    public static bool TryGetNumber(char[][] homework, int column, out long number)
    {
        number = -1;
        var digits = new List<char>();

        for (int i = 0; i < homework.Length - 1; i++)
        {
            digits.Add(homework[i][column]);
        }

        if (digits.All(d => d is ' ')) return false;

        number = long.Parse(digits.ToArray());

        return true;
    }
}
