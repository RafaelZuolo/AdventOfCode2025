namespace AdventOfCode2025.Utils;

public class Digraph<T> where T : IEquatable<T>
{
    private readonly HashSet<T> vertices = [];
    private readonly Dictionary<T, List<Edge<T>>> adjacencies = [];

    public Digraph() { }

    public Digraph(params ICollection<T> vertices)
    {
        this.vertices = [.. vertices];
    }

    public Digraph<T> AddVertices(params ICollection<T> vertices)
    {
        this.vertices.UnionWith(vertices);

        return this;
    }

    public Digraph<T> AddEdge(T from, T to, long weight = 1)
    {
        vertices.Add(from);
        vertices.Add(to);
        if (adjacencies.TryGetValue(from, out var adjacency))
        {
            adjacency.Add(new Edge<T>(to, weight));
        }
        else
        {
            adjacencies.Add(from, [new Edge<T>(to, weight)]);
        }

        return this;
    }

    internal ICollection<Edge<T>> GetNeighborsOf(T vertex)
    {
        return adjacencies.GetValueOrDefault(vertex) ?? [];
    }

    public ICollection<Edge<T>> GetAllEdges()
    {
        var edges = new HashSet<Edge<T>>();
        foreach (var vertex in vertices)
        {
            edges.UnionWith(GetNeighborsOf(vertex));
        }

        return edges;
    }
}

public record Edge<T>(T To, long Weight = 1) : IComparable<Edge<T>> where T : IEquatable<T>
{
    public int CompareTo(Edge<T>? other)
    {
        if (other is null) return 1;

        if (Weight == other.Weight) return 0;

        return Weight < other.Weight ? -1 : 1;
    }
}
