using System;

public struct Tijd : IEquatable<Tijd>
{
    public int Uren { get; }
    public readonly int Minuten;

    public Tijd(int uren, int minuten)
    {
        Uren = uren + minuten / 60;
        Minuten = minuten % 60;
    }
    
    public Tijd PlusMinuten(int extraMinuten)
    {
        return new Tijd(Uren, Minuten + extraMinuten);
    }

    public static Tijd operator+ (Tijd t, Tijd u)
    {
        return new Tijd(t.Uren + u.Uren, t.Minuten + u.Minuten);
    }
    public static Tijd operator +(Tijd t, int n)
    {
        return new Tijd(t.Uren, t.Minuten + n);
    }

    public static implicit operator Tijd (int n)
    {
        return new Tijd(0, n);
    }

    #region IEquatable
    private static bool AreEqual(Tijd t, Tijd u)
    {
        return t.Uren == u.Uren && t.Minuten == u.Minuten;
    }

    public static bool operator == (Tijd t, Tijd u)
    {
        return AreEqual(t,u);
    }

    public static bool operator != (Tijd t, Tijd u)
    {
        return !AreEqual(t, u);
    }

    public override bool Equals(object that)
    {
        return that is Tijd && AreEqual(this, (Tijd) that);
    }

    public bool Equals(Tijd that)
    {
        return AreEqual(this, that);
    }

    public override int GetHashCode()
    {
        return Uren.GetHashCode() ^ Minuten.GetHashCode();
        //return Uren * 60 + Minuten;
    }
    #endregion IEquatable

    public static Tijd operator++ (Tijd t)
    {
        return t + 1;
    }

}