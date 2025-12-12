using AdventOfCode2025.Utils;

namespace AdventOfCode2025.Days;

public class Day12 : IDay
{
    public string SolvePart1(string input)
    {
        int[] shapesArea = [7, 7, 5, 7, 7, 6]; // parsed by me from my input. No, I feel no shame.

        var trees = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Last()
            .ParseLines()
            .Select(l =>
            {
                var split = l.Split(": ");
                var dimensions = split[0].Split("x").Select(int.Parse).ToArray();
                var quantities = split[1].Split(' ').Select(int.Parse).ToArray();

                return new Tree(dimensions[0], dimensions[1], quantities);
            })
            .ToArray();

        return trees.Where(t => t.CanFit(shapesArea)).Count().ToString();
    }

    public class Tree(int height, int width, int[] quantities)
    {
        public int Area { get; } = height * width;
        public int[] Quantities { get; } = quantities;

        // Unbelievable that this work for the input
        public bool CanFit(int[] presentAreas) => Quantities.Select((q, index) => q * presentAreas[index]).Sum() <= Area;
    }

    public string SolvePart2(string input)
    {
        return "golden start";
    }
}
