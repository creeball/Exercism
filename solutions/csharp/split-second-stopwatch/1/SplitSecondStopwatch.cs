public enum StopwatchState
{
    Ready,
    Running,
    Stopped
}

public class SplitSecondStopwatch(TimeProvider time)
{
    private DateTimeOffset _startTime;
    private DateTimeOffset _stopTime;
    private readonly List<TimeSpan> _previousLaps = [];
    private List<TimeSpan> CurrentLapTimeSpans { get; set; } = [];
    private DateTimeOffset CurrentTime => time.GetUtcNow();
    public StopwatchState State { get; private set; } = StopwatchState.Ready;
    public TimeSpan CurrentLap => State switch
    {
        StopwatchState.Ready => TimeSpan.Zero,
        StopwatchState.Stopped => TimeSum(CurrentLapTimeSpans),
        StopwatchState.Running => TimeSum(CurrentLapTimeSpans) + (CurrentTime - _startTime),
        _ => throw new ArgumentOutOfRangeException()
    };
    public TimeSpan Total => TimeSum(_previousLaps) + CurrentLap;
    public IReadOnlyCollection<TimeSpan> PreviousLaps => _previousLaps.AsReadOnly();
    private static TimeSpan TimeSum(List<TimeSpan> timeSpans) =>
        timeSpans.Aggregate(TimeSpan.Zero, (current, next) => current + next);

    public void Start()
    {
        if (State == StopwatchState.Running) throw new InvalidOperationException();
        _startTime = CurrentTime;
        State = StopwatchState.Running;
    }

    public void Stop()
    {
        if (State == StopwatchState.Running) _stopTime = CurrentTime;
        else throw new InvalidOperationException();
        CurrentLapTimeSpans.Add(_stopTime - _startTime);
        State = StopwatchState.Stopped;
    }

    public void Reset()
    {
        if (State != StopwatchState.Stopped) throw new InvalidOperationException();
        State = StopwatchState.Ready;
        _previousLaps.Clear();
        CurrentLapTimeSpans.Clear();
    }

    public void Lap()
    {
        if (State != StopwatchState.Running) throw new InvalidOperationException();
        _previousLaps.Add(CurrentLap);
        CurrentLapTimeSpans.Clear();
        _startTime = CurrentTime;
    }
}
