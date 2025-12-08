using AdventOfCode2025.Utils;

namespace AdventOfCode2025.Days;

public class Day08 : IDay
{
    public string SolvePart1(string input)
    {
        var junctions = input
            .ParseLines()
            .Select(l =>
            {
                var split = l.Split(',');
                return new Junction(long.Parse(split[0]), long.Parse(split[1]), long.Parse(split[2]));
            })
            .ToArray();

        var wires = new List<Wire>();

        for (int i = 0; i < junctions.Length - 1; i++)
        {
            for (int j = i + 1; j < junctions.Length; j++)
            {
                wires.Add(new Wire(junctions[i], junctions[j], junctions[i].Dist(junctions[j])));
            }
        }

        wires.Sort();

        var unions = new UnionFind<Junction>(junctions);
        for (int i = 0; i < 1000; i++)
        {
            unions.Union(wires[i].Start, wires[i].End);
        }

        var circuitSizesByJunction = junctions.ToDictionary(j => j, _ => 0);
        foreach (var junction in junctions)
        {
            circuitSizesByJunction[unions.Find(junction)] += 1;
        }

        var circuitSizes = circuitSizesByJunction.Values.ToList();
        circuitSizes.Sort();

        return (circuitSizes[^1] * circuitSizes[^2] * circuitSizes[^3]).ToString();
    }

    public record Junction(long X, long Y, long Z)
    {
        public long Dist(Junction other)
        {
            return ((X - other.X) * (X - other.X))
                + ((Y - other.Y) * (Y - other.Y))
                + ((Z - other.Z) * (Z - other.Z));
        }
    }

    public record Wire(Junction Start, Junction End, long Length) : IComparable<Wire>
    {
        public int CompareTo(Wire? other)
        {
            if (other is null) return 1;
            if (Length == other.Length) return 0;
            return this.Length < other.Length ? -1 : 1;
        }
    }

    public string SolvePart2(string input)
    {
        var junctions = input
            .ParseLines()
            .Select(l =>
            {
                var split = l.Split(',');
                return new Junction(long.Parse(split[0]), long.Parse(split[1]), long.Parse(split[2]));
            })
            .ToArray();

        var wires = new List<Wire>();

        for (int i = 0; i < junctions.Length - 1; i++)
        {
            for (int j = i + 1; j < junctions.Length; j++)
            {
                wires.Add(new Wire(junctions[i], junctions[j], junctions[i].Dist(junctions[j])));
            }
        }

        wires.Sort();

        var unions = new UnionFind<Junction>(junctions);
        var lastIndex = 0;
        for (int i = 0; !unions.IsAllConnected(); i++)
        {
            unions.Union(wires[i].Start, wires[i].End);
            lastIndex = i;
        }

        return (wires[lastIndex].Start.X * wires[lastIndex].End.X).ToString();
    }
}
