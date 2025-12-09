using AdventOfCode2025.Utils;

namespace AdventOfCode2025.Days;

public class Day09 : IDay
{
    public string SolvePart1(string input)
    {
        var tiles = input.ParseLines()
        .Select(l =>
        {
            var splitted = l.Split(',');
            return new Tile(long.Parse(splitted[0]), long.Parse(splitted[1]));
        })
        .ToArray();

        long highestArea = 1;
        for (int i = 0; i < tiles.Length; i++)
        {
            for (int j = i + 1; j < tiles.Length; j++)
            {
                if (tiles[i].GetArea(tiles[j]) > highestArea)
                    highestArea = tiles[i].GetArea(tiles[j]);
            }
        }

        return highestArea.ToString();
    }

    public record Tile(long X, long Y)
    {
        public long GetArea(Tile other)
        {
            return (Math.Abs(X - other.X) + 1) * (Math.Abs(Y - other.Y) + 1);
        }
    };

    public string SolvePart2(string input)
    {
        var tiles = input.ParseLines()
        .Select(l =>
        {
            var splitted = l.Split(',');
            return new Tile(long.Parse(splitted[0]), long.Parse(splitted[1]));
        })
        .ToArray();

        var edges = new List<Edge>();
        for (int i = 0; i < tiles.Length; i++)
        {
            edges.Add(new Edge(tiles[i], tiles[(i + 1) % tiles.Length]));
        }

        long highestArea = 1;
        for (int i = 0; i < tiles.Length - 1; i++)
        {
            for (int j = i + 1; j < tiles.Length; j++)
            {
                if (tiles[i].GetArea(tiles[j]) <= highestArea) continue;
                if (CrossOutside(edges, tiles[i], tiles[j])) continue;

                highestArea = tiles[i].GetArea(tiles[j]);
            }
        }

        return highestArea.ToString();
    }

    private static bool CrossOutside(ICollection<Edge> edges, Tile a, Tile b)
    {
        return edges.Any(e => e.HaveIntersection(a, b));
    }

    public class Edge(Tile A, Tile B)
    {
        private bool IsVertical => A.X == B.X;
        private bool IsHorizontal => A.Y == B.Y;
        private long MaxX => Math.Max(A.X, B.X);
        private long MinX => Math.Min(A.X, B.X);
        private long MaxY => Math.Max(A.Y, B.Y);
        private long MinY => Math.Min(A.Y, B.Y);

        public Tile A { get; } = A;
        public Tile B { get; } = B;


        public bool HaveIntersection(Tile first, Tile second)
        {
            long rectangleMaxX = Math.Max(first.X, second.X);
            long rectangleMinX = Math.Min(first.X, second.X);
            long rectangleMaxY = Math.Max(first.Y, second.Y);
            long rectangleMinY = Math.Min(first.Y, second.Y);

            if (IsVertical)
            {
                return rectangleMinX < A.X && A.X < rectangleMaxX
                    && ((MinY <= rectangleMinY && rectangleMinY < MaxY) || (MinY < rectangleMaxY && rectangleMaxY <= MaxY));
            }

            if (IsHorizontal)
            {
                return rectangleMinY < A.Y && A.Y < rectangleMaxY
                    && ((MinX <= rectangleMinX && rectangleMinX < MaxX) || (MinX < rectangleMaxX && rectangleMaxX <= MaxX));
            }

            return false;
        }
    }
}
