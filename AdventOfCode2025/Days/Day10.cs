using AdventOfCode2025.Utils;

namespace AdventOfCode2025.Days;

public class Day10 : IDay
{
    public string SolvePart1(string input)
    {
        var lights = input.ParseLines()
            .Select(l =>
            {
                var parts = l.Split(' ');
                var targetLightState = new List<bool>();
                foreach (var c in parts[0])
                {
                    if (c is '.') targetLightState.Add(false);
                    if (c is '#') targetLightState.Add(true);
                }
                var buttons = new List<int[]>();
                for (int i = 1; i < parts.Length - 1; i++)
                {
                    var button = parts[i][1..^1].Split(',').Select(int.Parse).ToArray();
                    buttons.Add(button);
                }

                return new Machine(targetLightState, buttons, []);
            })
            .ToArray();

        return lights.Select(MinButtonsBFS).Sum().ToString();
    }

    public class Machine(IReadOnlyList<bool> targetLightState, IList<int[]> buttons, ICollection<int> joltage)
    {
        public IReadOnlyList<bool> TargetLightState { get; } = targetLightState;
        public IReadOnlyDictionary<int, int[]> Buttons { get; } = Enumerable.Range(0, buttons.Count).ToDictionary(k => k, i => buttons[i]);
        public ICollection<int> Joltage { get; } = joltage;
    }

    public static int MinButtonsBFS(Machine machine)
    {
        var states = new LinkedList<MachineState>();
        states.AddFirst(new MachineState(machine));

        while (states.Count > 0)
        {
            var state = states.First!.Value;
            states.RemoveFirst();

            if (state.Lights.SequenceEqual(state.Machine.TargetLightState))
                return state.PressedButtons.Count;

            foreach (var button in state.NotPressedButtons)
            {
                states.AddLast(state.PressButton(button));
            }
        }

        throw new InvalidOperationException("Did not find any button presses");
    }

    public class MachineState
    {
        public Machine Machine { get; }
        public bool[] Lights { get; }
        public HashSet<int> PressedButtons { get; } = [];
        public HashSet<int> NotPressedButtons { get; }

        public MachineState(Machine machine)
        {
            Machine = machine;
            Lights = new bool[machine.TargetLightState.Count];
            NotPressedButtons = [.. machine.Buttons.Keys];
        }

        public MachineState(MachineState machineState)
        {
            Machine = machineState.Machine;
            Lights = machineState.Lights?.Clone() as bool[] ?? new bool[Machine.TargetLightState.Count];
            NotPressedButtons = [.. machineState.NotPressedButtons];
            PressedButtons = [.. machineState.PressedButtons];
        }

        public MachineState PressButton(int button)
        {
            if (PressedButtons.Contains(button)) throw new Exception($"button {button} already pressed! check BFS");

            var nextState = new MachineState(this);
            nextState.PressedButtons.Add(button);
            nextState.NotPressedButtons.Remove(button);

            var lightsToToggle = Machine.Buttons[button];
            foreach (var light in lightsToToggle)
            {
                nextState.Lights[light] = !nextState.Lights[light];
            }

            return nextState;
        }
    }

    public string SolvePart2(string input)
    {
        return "foo";
    }
}
