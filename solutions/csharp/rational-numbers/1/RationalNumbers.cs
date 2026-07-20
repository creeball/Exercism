using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => Math.Pow(Math.Pow(realNumber, r.Numerator), 1d/r.Denominator);
}

public struct RationalNumber
{
    private int _numerator;
    private int _denominator;
    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; }
    }
    public int Denominator
    {
        get { return _denominator; }
        set { _denominator = value; }
    }
    
    

    public RationalNumber(int numerator, int denominator)
    {
        var standardized = Standardize(numerator, denominator);
        _numerator = standardized.num;
        _denominator = standardized.den;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.Numerator * r2.Denominator + r1.Denominator * r2.Numerator, r1.Denominator * r2.Denominator);

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.Numerator * r2.Denominator - r1.Denominator * r2.Numerator, r1.Denominator * r2.Denominator);

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);

    public RationalNumber Abs() => new RationalNumber(Math.Abs(Numerator), Denominator);

    public RationalNumber Reduce() => this;

    public RationalNumber Exprational(int power) => (power > 0) switch
    {
        true => new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denominator, power)),
        false => new RationalNumber((int)Math.Pow(Denominator, power * -1), (int)Math.Pow(Numerator, power * -1))
    };
    
    private (int num, int den) Standardize(int num, int den)
    {
        if (num == 0) return (0, 1);

        int gcd = GCD(Math.Max(num, den), Math.Min(num, den));
        num /= gcd;
        den /= gcd;

        if (den < 0)
        {
            num *= -1;
            den *= -1;
        }

        return (num, den);
    }

    private int GCD(int a, int b) => (a%b == 0) ? b : GCD(b, a%b);
}