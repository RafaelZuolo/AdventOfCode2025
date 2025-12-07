using AdventOfCode2025.Utils;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2025Tests;

public class AStarTests
{
    [Fact]
    public void Explore_ShouldGiveShortestCosts()
    {
        var start = 0;
        var graph = new Digraph<int>();
        graph.AddEdge(4, 5, 35);
        graph.AddEdge(5, 4, 35);
        graph.AddEdge(4, 7, 37);
        graph.AddEdge(5, 7, 28);
        graph.AddEdge(7, 5, 28);
        graph.AddEdge(5, 1, 32);
        graph.AddEdge(0, 4, 38);
        graph.AddEdge(0, 2, 26);
        graph.AddEdge(7, 3, 39);
        graph.AddEdge(1, 3, 29);
        graph.AddEdge(2, 7, 34);
        graph.AddEdge(6, 2, 40);
        graph.AddEdge(3, 6, 52);
        graph.AddEdge(6, 0, 58);
        graph.AddEdge(6, 4, 93);

        var search = new AStartSearch<int>(graph, start);
        var costs = search.Explore();
        costs[6].Should().Be(151);
    }
}
