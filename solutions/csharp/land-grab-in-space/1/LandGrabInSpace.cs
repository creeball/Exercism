public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
    public int DistanceSquaredTo(Coord other)
    {
        int dx = X - other.X;
        int dy = Y - other.Y;

        return dx * dx + dy * dy;
    }
}

public struct Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
{
    public Coord Coord1 { get; } = coord1;
    public Coord Coord2 { get; } = coord2;
    public Coord Coord3 { get; } = coord3;
    public Coord Coord4 { get; } = coord4;
    
    public int LongestSideSquared => Math.Max(
        Math.Max(Coord1.DistanceSquaredTo(Coord2), Coord2.DistanceSquaredTo(Coord3)),
        Math.Max(Coord3.DistanceSquaredTo(Coord4), Coord4.DistanceSquaredTo(Coord1)));
}


public class ClaimsHandler
{
    private readonly List<Plot> _plots = [];

    public void StakeClaim(Plot plot)
    {
        if (!_plots.Contains(plot))
            _plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) =>
        _plots.Contains(plot);

    public bool IsLastClaim(Plot plot) =>
        _plots.Count > 0 && plot.Equals(_plots[^1]);

    public Plot GetClaimWithLongestSide()
    {
        var longest = _plots[0];

        foreach (var plot in _plots)
        {
            if (plot.LongestSideSquared > longest.LongestSideSquared)
            {
                longest = plot;
            }
        }
        return longest;
    }
}