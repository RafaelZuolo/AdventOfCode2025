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
}

public record Edge<T>(T To, long Weight = 1) where T : IEquatable<T>;