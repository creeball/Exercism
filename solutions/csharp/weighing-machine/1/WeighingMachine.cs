class WeighingMachine(int precision)
{
    public int Precision { get; } = precision;
    public double Weight
    {
        get;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            field = value;
        }
    }
    public double TareAdjustment { get; set; } = 5;
    public string DisplayWeight => $"{(Weight - TareAdjustment).ToString($"F{Precision}")} kg";
}