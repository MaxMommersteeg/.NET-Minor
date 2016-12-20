using System;

public class DemoDing
{
    public void AddOne(ref int n)
    {
        n++;
    }

    public void MakeSix(out int n)
    {
        n = 6;
    }

    public string M(int n) { return "M(int n)"; }
    public string M(ref int n) { return "M(ref int n)"; }
    //public string M(int m, int n) { return "M(int m, int n)"; }
    //public string M(int m, int k) { return "M(int m, int k)"; }
    public string M(int m, double k) { return "M(int m, double k)"; }
    public string M(int m, float k) { return "M(int m, float k)"; }
    public string M(int m, decimal k) { return "M(int m, decimal k)"; }

    public string M(params int[] m) { return "params int[] m"; }
    public string M(int k, params int[] m) { return "int k, params int[] m"; }

    public string M(int a, int b = 2, int c = 4) { return "M(int a, int b = 2, int c = 4)"; }

}