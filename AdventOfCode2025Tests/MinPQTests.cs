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

    [Fact]
    public void DelMin_TwoSingleItemAdded_ReturnItemWithLowerPriority()
    {
        var minItem = "foo";
        var pq = new MinHeap<string>();
        pq.Insert(minItem, 1);
        pq.Insert("bar", 2);

        var item = pq.DelMin();

        item.Should().Be(minItem);
    }

    [Fact]
    public void DelMin_TwoSingleItemAddedAndDelMinTwoTimes_ReturnItemWithCurrentLowerPriority()
    {
        var firstReturnInDelMin = "foo";
        var secondReturnInDelMin = "bar";
        var pq = new MinHeap<string>();
        pq.Insert(secondReturnInDelMin, 2);
        pq.Insert(firstReturnInDelMin, 1);

        var item = pq.DelMin();

        item.Should().Be(firstReturnInDelMin);

        item = pq.DelMin();
        item.Should().Be(secondReturnInDelMin);
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
