namespace AdventOfCode2025.Utils;

public class AStartSearch<T> where T : IEquatable<T>
{
    private readonly Digraph<T> digraph;
    private readonly T start;
    private readonly Func<T, T, long> heuristic;

    private MinHeap<T> frontier = new();
    private Dictionary<T, long> currentCost = [];
    private Dictionary<T, long> currentGuess = [];
    private Dictionary<T, T> previousVertex = new();

    public AStartSearch(Digraph<T> digraph, T start, Func<T, T, long>? heuristic = null)
    {
        this.digraph = digraph;
        this.start = start;
        this.heuristic = heuristic ?? ((_, _) => 0);
    }

    public IReadOnlyDictionary<T, long> Explore()
    {
        frontier = new();
        frontier.Insert(start, 0);

        currentCost = new()
        {
            { start, 0 }
        };

        currentGuess = new()
        {
            { start, heuristic(start, start) }
        };

        var last = start;
        while (!frontier.IsEmpty())
        {
            var current = frontier.DelMin();
            previousVertex.Add(current, last);
            last = current;

            foreach (var neighbor in digraph.GetNeighborsOf(current))
            {
                if (!currentCost.TryGetValue(neighbor.To, out var value))
                {
                    value = currentCost[current] + neighbor.Weight;
                    currentCost.Add(neighbor.To, value);
                    frontier.Insert(neighbor.To, value + heuristic(start, neighbor.To));
                    continue;
                }

                var tentativeCost = currentCost[current] + neighbor.Weight;
                if (tentativeCost < value)
                {
                    currentCost[neighbor.To] = tentativeCost;
                    frontier.Upsert(neighbor.To, tentativeCost + heuristic(start, neighbor.To));
                }
            }
        }

        return currentCost.AsReadOnly();
    }
}
