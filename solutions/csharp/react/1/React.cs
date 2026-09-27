public class Reactor
{
    public InputCell CreateInputCell(int value) => new(value);

    public ComputeCell CreateComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute) =>
        new(producers.ToArray(), compute);
}

public abstract class Cell
{
    public List<ComputeCell> Dependents { get; } = [];

    public int Value
    {
        get;
        set
        {
            if (field == value) return;
            field = value;
            OnChanged();
        }
    }

    protected abstract void OnChanged();
}

public class InputCell : Cell
{
    internal InputCell(int value) => Value = value;

    protected override void OnChanged()
    {
        List<ComputeCell> current = Dependents;
        while (current.Count != 0)
        {
            List<ComputeCell> next = [];
            HashSet<ComputeCell> visited = [];
            foreach (var cell in current.Where(cell => cell.ReCompute()))
            {
                next.AddRange(cell.Dependents.Where(visited.Add));
            }
            current = next;
        }
    }
}

public class ComputeCell : Cell
{
    private Cell[] Producers { get; }
    private Func<int[], int> Compute { get; }

    public event EventHandler<int>? Changed;

    internal ComputeCell(Cell[] producers, Func<int[], int> compute)
    {
        Producers = producers;
        Compute = compute;
        Value = compute(producers.Select(p => p.Value).ToArray());

        foreach (var producer in producers)
            producer.Dependents.Add(this);
    }

    public bool ReCompute()
    {
        var next = Compute(Producers.Select(p => p.Value).ToArray());
        if (next == Value) return false;
        Value = next;
        return true;
    }

    protected override void OnChanged() => Changed?.Invoke(this, Value);
}
