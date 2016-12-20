using System;

public class Fac
{
    public Fac()
    {
    }

    public int Fact(int n)
    {
        if(n<1)
        {
            throw new InvalidOperationException();
        }
        int result = 1;
        while(n>=2)
        {
            result=result* n;
            n--;
        }
        return result;
    }
}