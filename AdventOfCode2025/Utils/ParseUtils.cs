namespace AdventOfCode2025.Utils;

public static class ParseUtils
{
    public static string[] ParseLines(this string input)
    {
        return [.. input.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)];
    }

    public static T[][] ParseAsMatrix<T>(this string input, Func<char, T> selector)
    {
        return [.. input.ParseLines().Select(l => l.Select(selector).ToArray())];
    }

    public static T[][] ParseAllAsMatrix<T>(this string input, Func<char, T> selector)
    {
        return [.. input.Split(Environment.NewLine).Select(l => l.Select(selector).ToArray())];
    }
}
