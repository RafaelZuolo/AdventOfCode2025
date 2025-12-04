using AdventOfCode2025;
using AdventOfCode2025.Days;

Dictionary<int, IDay> DayByNumber = new Dictionary<int, IDay>
{
    { 01, new Day01() },
    { 02, new Day02() },
    { 03, new Day03() },
    { 04, new Day04() },
    //{ 05, new Day05() },
    //{ 06, new Day06() },
    //{ 07, new Day07() },
    //{ 08, new Day08() },
    //{ 09, new Day09() },
    //{ 10, new Day10() },
    //{ 11, new Day11() },
    //{ 12, new Day12() },
};

var DebugDay = DayByNumber.Last().Key;
const string InputFolder = "Inputs";

var projectPath = Directory.GetCurrentDirectory();
var currentDay = args.Contains("-d") ? int.Parse(args[Array.IndexOf(args, "-d") + 1]) : DebugDay;
var onlyPart1 = args.Contains("-p1");
var onlyPart2 = !onlyPart1 && args.Contains("-p2");
Console.WriteLine();

var message = $"Solving day {currentDay:D2}";
Console.WriteLine(message + Environment.NewLine);


var path = Path.Combine(projectPath, InputFolder, currentDay.ToString("D2") + ".txt");
var input = File.ReadAllText(path);

var problemDay = DayByNumber[currentDay];
if (!onlyPart2) Console.WriteLine($"Part 1: {problemDay.SolvePart1(input)}");
if (!onlyPart1) Console.WriteLine($"Part 2: {problemDay.SolvePart2(input)}");
