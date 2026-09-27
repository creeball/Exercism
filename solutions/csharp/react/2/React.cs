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
        HashSet<ComputeCell> affected = [];
        Collect(this, affected);
        Dictionary<ComputeCell, int> pending = affected
            .ToDictionary(
                c => c,
                c => c.Producers
                    .OfType<ComputeCell>()
                    .Count(affected.Contains));
        Queue<ComputeCell> ready = new(affected.Where(cell => pending[cell] == 0));
        while (ready.Count > 0)
        {
            var cell = ready.Dequeue();
            cell.ReCompute();
            foreach (var dependent in cell.Dependents)
            {
                if (--pending[dependent] == 0)
                    ready.Enqueue(dependent);
            }
        }
    }

    private static void Collect(Cell cell, HashSet<ComputeCell> affected)
    {
        foreach (var dependent in cell.Dependents.Where(affected.Add))
        {
            Collect(dependent, affected);
        }
    }
}

public class ComputeCell : Cell
{
    internal Cell[] Producers { get; }
    private Func<int[], int> Compute { get; }

    public event EventHandler<int>? Changed;

    internal ComputeCell(Cell[] producers, Func<int[], int> compute)
    {
        Producers = producers;
        Compute = compute;
        Value = compute(producers.Select(p => p.Value).ToArray());
        foreach (var producer in producers) producer.Dependents.Add(this);
    }

    public void ReCompute() => Value = Compute(Producers.Select(p => p.Value).ToArray());

    protected override void OnChanged() => Changed?.Invoke(this, Value);
}
