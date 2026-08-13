public static class Prism
{
    public readonly record struct LaserInfo(double X, double Y, double Angle);

    public readonly record struct PrismInfo(int Id, double X, double Y, double Angle);

    public static int[] FindSequence(LaserInfo laser, PrismInfo[] prisms)
    {
        var left = prisms.ToList();
        List<int> result = new();
        var currentLaser = laser;
        while (true)
        {
            var nextPrisms = left.Where(p => p.OnLaser(currentLaser)).ToArray();
            if (nextPrisms.Length == 0) break;
            var currentPrism = nextPrisms.MinBy(p => Math.Pow(p.X - currentLaser.X, 2) + Math.Pow(p.Y - currentLaser.Y, 2));
            currentLaser = new LaserInfo(currentPrism.X, currentPrism.Y, currentLaser.Angle + currentPrism.Angle);
            result.Add(currentPrism.Id);
        }
        return result.ToArray();
    }

    public static bool OnLaser(this PrismInfo prism, LaserInfo laser)
    {
        double angle = double.DegreesToRadians(laser.Angle);
        double dx = double.Cos(angle);
        double dy = double.Sin(angle);
        double px = prism.X - laser.X;
        double py = prism.Y - laser.Y;
        if (Math.Pow(px * dy - py * dx, 2) / (px * px + py * py) > 1e-6) return false;
        double dot = px * dx + py * dy;
        return dot > 0;
    }
}
