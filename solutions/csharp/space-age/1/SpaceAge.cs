public class SpaceAge(int seconds)
{
    enum Planet
    {
        Mercury,
        Venus,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune
    }

    private static readonly Dictionary<Planet, double> OrbitalPeriods = new()
    {
        { Planet.Mercury, 0.2408467 },
        { Planet.Venus, 0.61519726 },
        { Planet.Earth, 1.0 },
        { Planet.Mars, 1.8808158 },
        { Planet.Jupiter, 11.862615 },
        { Planet.Saturn, 29.447498 },
        { Planet.Uranus, 84.016846 },
        { Planet.Neptune, 164.79132 }
    };
    
    private const double SecondsPerEarthYear = 365.25 * 24 * 60 * 60;

    private double GetAge(Planet planet) => seconds / SecondsPerEarthYear / OrbitalPeriods[planet];

    public double OnEarth() => GetAge(Planet.Earth);

    public double OnMercury() => GetAge(Planet.Mercury);
    
    public double OnVenus() => GetAge(Planet.Venus);

    public double OnMars() => GetAge(Planet.Mars);

    public double OnJupiter() => GetAge(Planet.Jupiter);

    public double OnSaturn() => GetAge(Planet.Saturn);

    public double OnUranus() => GetAge(Planet.Uranus);

    public double OnNeptune() => GetAge(Planet.Neptune);
}