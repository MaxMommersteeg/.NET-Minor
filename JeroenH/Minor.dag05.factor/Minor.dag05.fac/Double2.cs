using System;
using System.Diagnostics;

public class Double2
{
    public Double2()
    {

    }

    public double FindStrangeAnyDouble()
    {
        return double.MaxValue;
    }

    public double FindStrangeLowDouble()
    {
        double smallest = Math.Pow(2, 53);
        while (true)
        {
            bool bla = smallest == smallest + 1;
            if (bla)
            {
                Debug.WriteLine("YAY! " + smallest);
                return smallest;
            }
            else
            {
                if (smallest > 1e30)
                {
                    return 1;
                }
                Debug.WriteLine(smallest);
                smallest+= 1;
            }
        }
    }
}