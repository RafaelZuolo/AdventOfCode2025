namespace AdventOfCode2025.Utils;

public class UnionFind<T>(ICollection<T> elements) where T : IEquatable<T>
{
    private readonly Dictionary<T, T> parent = elements.ToDictionary(e => e);
    private readonly Dictionary<T, int> treeSize = elements.ToDictionary(e => e, _ => 1);

    public T Find(T x)
    {
        if (parent[x].Equals(x)) return x;

        parent[x] = Find(parent[x]);

        return parent[x];
    }

    public void Union(T x, T y)
    {
        T rootX = Find(x);
        T rootY = Find(y);

        if (rootX.Equals(rootY)) return;
        if (treeSize[rootX] < treeSize[rootY])
        {
            parent[rootX] = rootY;
            treeSize[rootY] += treeSize[rootX];
        }
        else
        {
            parent[rootY] = rootX;
            treeSize[rootX] += treeSize[rootY];
        }
    }

    public IReadOnlyDictionary<T, T> GetSetLabelByElement() => parent;

    public bool IsAllConnected()
    {
        var firstSet = Find(parent.Keys.First());

        foreach (var key in parent.Keys)
        {
            if (!firstSet.Equals(Find(key))) return false;
        }

        return true;
    }
}
