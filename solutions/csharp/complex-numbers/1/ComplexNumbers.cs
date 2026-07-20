public struct ComplexNumber(double real, double imaginary = 0)
{
    public double Real() => real;
    public double Imaginary() => imaginary;

    public ComplexNumber Mul(ComplexNumber other)
    {
        return new ComplexNumber(
            real * other.Real() - imaginary * other.Imaginary(),
            imaginary * other.Real() + real * other.Imaginary());
    }

    public ComplexNumber Mul(double other) => Mul(new ComplexNumber(other));

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(
            real + other.Real(), 
            imaginary + other.Imaginary());
    }
    
    public ComplexNumber Add(double other) => Add(new ComplexNumber(other));

    public ComplexNumber Sub(ComplexNumber other)
    {
        return new ComplexNumber(
            real - other.Real(), 
            imaginary - other.Imaginary());
    }
    
    public ComplexNumber Sub(double other) => Sub(new ComplexNumber(other));

    public ComplexNumber Div(ComplexNumber other)
    {
        double newImaginary = Math.Pow(other.Real(), 2) + Math.Pow(other.Imaginary(), 2);
        return new ComplexNumber(
            (real * other.Real() + imaginary * other.Imaginary()) / newImaginary, 
            (imaginary * other.Real() - real * other.Imaginary()) / newImaginary);
    }
    
    public ComplexNumber Div(double other) => Div(new ComplexNumber(other));

    public double Abs() => Math.Sqrt(real * real + imaginary * imaginary);

    public ComplexNumber Conjugate() => new ComplexNumber(real, -imaginary);
    
    public ComplexNumber Exp()
    {
        double exp = Math.Exp(real);
        return new ComplexNumber(Math.Cos(imaginary) * exp, Math.Sin(imaginary) * exp);
    }
}
