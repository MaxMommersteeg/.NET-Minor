using System;

public class Twilight
{
    public double FindStrangeDouble()
    {
        return double.MaxValue;
    }

    public double FindSmallestStrangeDouble()
    {
        double x = 2;

        while(x != x+1)
        {
            x *= 2;
        }

        return x;
    }
}