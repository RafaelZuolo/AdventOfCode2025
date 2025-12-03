using AdventOfCode2025.Utils;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class MinPQTests
{
    [Fact]
    public void Insert_DuplicatedItem_ThrowArgumentException()
    {
        var pq = new MinHeap<string>();

        pq.Insert("item", 0);
        pq.Insert("item2", 1);

        pq.Invoking(p => p.Insert("item", 500)).Should().Throw<ArgumentException>();
    }

    [Fact]
    public void DelMin_SingleItemAdded_ReturnSameItem()
    {
        var input = "foo";
        var pq = new MinHeap<string>();

        pq.Insert(input, 0);

        var item = pq.DelMin();

        item.Should().Be(input);
    }

    [Theory]
    [InlineData("foo", 2, "faa", 1)]
    public void DelMin_TwoSingleItemAdded_ReturnItemWithLowerPriority(
        string firstItem,
        long firstPriority,
        string secondItem,
        long secondPriority)
    {
        var pq = new MinHeap<string>();

        pq.Insert(firstItem, firstPriority);
        pq.Insert(secondItem, secondPriority);

        var item = pq.DelMin();

        item.Should().Be(secondItem);
    }

    [Fact]
    public void DelMin_ManyItemAdded_ReturnLowestItem()
    {
        var inputs = Enumerable.Range(0, 1000);
        var expectedMin = inputs.Min();
        var pq = new MinHeap<int>();

        foreach (var item in inputs)
        {
            pq.Insert(item, item);
        }

        var minItem = pq.DelMin();

        minItem.Should().Be(expectedMin);
    }

    [Fact]
    public void DelMin_ManyItemAddedAndPriorityReduced_ReturnLowestItem()
    {
        var inputs = Enumerable.Range(0, 1000);
        var itemToChangePriority = 500;
        var pq = new MinHeap<int>();

        foreach (var item in inputs)
        {
            pq.Insert(item, item);
        }

        pq.Update(itemToChangePriority, -1);

        var minItem = pq.DelMin();

        minItem.Should().Be(itemToChangePriority);
    }

    [Fact]
    public void DelMin_ManyItemAddedAndPriorityIncreased_ReturnLowestItem()
    {
        var inputs = Enumerable.Range(0, 1000);
        var expectedMinItem = 1;
        var pq = new MinHeap<int>();

        foreach (var item in inputs)
        {
            pq.Insert(item, item);
        }

        pq.Update(0, 99999);

        var minItem = pq.DelMin();

        minItem.Should().Be(expectedMinItem);
    }
}
