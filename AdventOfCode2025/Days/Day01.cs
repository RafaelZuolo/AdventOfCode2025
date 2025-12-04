namespace AdventOfCode2025.Days;

public class Day01 : IDay
{
    public string SolvePart1(string input)
    {
        var parsedInput = input
            .Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var zeroes = (long)0;
        var currentVal = 50;

        foreach (var item in parsedInput)
        {
            if (item[0] == 'R')
            {
                currentVal += int.Parse(item.Substring(1, item.Length - 1));
                currentVal %= 100;
            }
            if (item[0] == 'L')
            {
                currentVal += 100 - int.Parse(item.Substring(1, item.Length - 1));
                currentVal %= 100;
            }

            if (currentVal == 0)
            {
                zeroes++;
            }
        }

        return zeroes.ToString();
    }

    public string SolvePart2(string input)
    {
        var parsedInput = input
            .Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var zeroes = (long)0;
        var currentVal = 50;


        foreach (var item in parsedInput)
        {
            if (item[0] == 'R')
            {
                var rot = int.Parse(item[1..]);
                for (int i = 0; i < rot; i++)
                {
                    if (currentVal == 100) { currentVal = 0; }

                    currentVal++;
                    if (currentVal == 100)
                    {
                        currentVal = 0;
                        zeroes++;
                    }
                }
            }
            if (item[0] == 'L')
            {
                var rot = int.Parse(item[1..]);
                for (int i = 0; i < rot; i++)
                {
                    if (currentVal == 0) { currentVal = 100; }

                    currentVal--;
                    if (currentVal == 0)
                    {
                        currentVal = 100;
                        zeroes++;
                    }
                }
            }
        }

        return zeroes.ToString();
    }
}
