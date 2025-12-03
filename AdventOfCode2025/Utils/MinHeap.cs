namespace AdventOfCode2025.Utils;

public class MinHeap<T> where T : IEquatable<T>
{
    private readonly List<HeapItem?> pq = [default];
    private readonly Dictionary<T, int> indexes = [];

    public void Insert(T item, long priority)
    {
        pq.Add(new HeapItem(item, priority));
        if (indexes.TryAdd(item, pq.Count - 1))
        {
            Swim(pq.Count - 1);
        }
        else
        {
            throw new ArgumentException("Duplicate item");
        }
    }

    private void Swim(int k)
    {
        while (k > 1 && IsGreaterThan(k / 2, k))
        {
            Swap(k, k / 2);
            k /= 2;
        }
    }

    private bool IsGreaterThan(int i, int j)
    {
        return pq[i]!.Priority > pq[j]!.Priority;
    }

    public T DelMin()
    {
        var min = pq[1]!.Item;
        Swap(1, pq.Count - 1);
        Sink(1);
        pq.RemoveAt(pq.Count - 1);

        return min;
    }

    private void Swap(int i, int j)
    {
        (indexes[pq[j].Item], indexes[pq[i].Item]) = (indexes[pq[i].Item], indexes[pq[j].Item]);
        (pq[j], pq[i]) = (pq[i], pq[j]);
    }

    private void Sink(int k)
    {
        while (2 * k < pq.Count)
        {
            int j = 2 * k;

            if (j < pq.Count - 1 && IsGreaterThan(j, j + 1))
            {
                j++;
            }
            if (!IsGreaterThan(k, j))
            {
                break;
            }

            Swap(k, j);
            k = j;
        }
    }

    public bool IsEmpty()
    {
        return pq.Count == 0;
    }

    public T? Peek()
    {
        return IsEmpty() ? default : pq[1]!.Item;
    }

    public int Size()
    {
        return pq.Count;
    }

    public void Update(T item, long priority)
    {
        if (indexes.TryGetValue(item, out var index))
        {
            pq[index] = pq[index]! with { Priority = priority };
            Swim(index);
            Sink(indexes[item]);
        }
        else throw new InvalidOperationException("failed to update: item not found");
    }

    private record HeapItem(T Item, long Priority);
}
