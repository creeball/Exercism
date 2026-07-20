public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return side1 != side2 && side2 != side3 && side3 != side1 && IsTriangle(side1, side2, side3);
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        return !IsScalene(side1, side2, side3) && IsTriangle(side1, side2, side3);
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        return side1 == side2 && side2 == side3 && IsTriangle(side1, side2, side3);
    }

    public static bool IsTriangle(double side1, double side2, double side3)
    {
        return side1 + side2 > side3 && side3 > Math.Abs(side2 - side1) ;
    }
}