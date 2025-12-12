using AdventOfCode2025.Utils;
using System.Diagnostics;

namespace AdventOfCode2025.Days;

public class Day11 : IDay
{
    public string SolvePart1(string input)
    {
        var devices = GetDevicesByName(input);

        var start = devices["you"];
        var end = devices["out"];

        return GetNumberOfPathsByDFS(start, end).ToString();
    }

    public static long GetNumberOfPathsByDFS(Device start, Device end)
    {
        if (start == end) return 1;

        return start.Outputs.Sum(o => GetNumberOfPathsByDFS(o, end));
    }

    private static Dictionary<string, Device> GetDevicesByName(string input)
    {
        var devices = new Dictionary<string, Device>();
        var lines = input.ParseLines();
        foreach (var line in lines)
        {
            var firstSplit = line.Split(": ");
            Device device;
            if (devices.TryGetValue(firstSplit[0], out var d))
            {
                device = d;
            }
            else
            {
                device = new Device(firstSplit[0]);
                devices.Add(device.Name, device);
            }

            var outputNames = firstSplit[1].Split(' ');

            foreach (var outputName in outputNames)
            {
                Device output;
                if (devices.TryGetValue(outputName, out var o))
                {
                    output = o;
                }
                else
                {
                    output = new Device(outputName);
                    devices.Add(output.Name, output);
                }

                device.Outputs.Add(output);
            }
        }

        return devices;
    }

    public class Device(string name) : IEquatable<Device>
    {
        public string Name { get; } = name;
        public ISet<Device> Outputs { get; } = new HashSet<Device>();
        public long Paths { get; set; } = 0;
        public bool WasVisited { get; set; } = false;

        public bool CanReach(Device device) // helps analyze our input
        {
            return device == this
                || Outputs.Aggregate(false, (prev, output) => prev || output.CanReach(device));
        }

        public override bool Equals(object? other)
        {
            return Equals(other as Device);
        }

        public bool Equals(Device? other)
        {
            return other is not null && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    public string SolvePart2(string input)
    {
        var devices = GetDevicesByName(input);

        //var fftReachDac = devices["fft"].CanReach(devices["dac"]); // returns true for our input
        //var dacReachfft = devices["dac"].CanReach(devices["fft"]); // returns false for our input
        //var svrReachDac = devices["svr"].CanReach(devices["dac"]); // returns true for our input
        //var svrReachfft = devices["svr"].CanReach(devices["fft"]); // enter in a loop

        // we just need to calculate # of svr to fft, multiply by # of fft to dac, and multiply by # of dac to out

        var start = devices["svr"];
        var fft = devices["fft"];
        var dac = devices["dac"];
        var end = devices["out"];

        var svrToFft = GetNumberOfPathsByDFSWithMemorization(start, fft);
        Reset(devices.Values);
        var fftToDac = GetNumberOfPathsByDFSWithMemorization(fft, dac);
        Reset(devices.Values);
        var dacToOut = GetNumberOfPathsByDFSWithMemorization(dac, end);

        return (svrToFft * fftToDac * dacToOut).ToString();
    }

    public static long GetNumberOfPathsByDFSWithMemorization(Device start, Device end)
    {
        if (start == end) return 1;
        if (start.WasVisited) return start.Paths;

        start.WasVisited = true;
        start.Paths = start.Outputs.Sum(o => GetNumberOfPathsByDFSWithMemorization(o, end));

        Debug.WriteLine($"{start.Name} - {start.Paths}");

        return start.Paths;
    }

    public static void Reset(ICollection<Device> devices)
    {
        foreach (var device in devices)
        {
            device.WasVisited = false;
            device.Paths = 0;
        }
    }
}
