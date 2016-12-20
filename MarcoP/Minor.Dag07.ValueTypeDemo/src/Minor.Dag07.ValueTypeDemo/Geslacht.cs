using System;

namespace Minor.Dag07.ValueTypeDemo
{
    [Flags]
    public enum Geslacht : int
    {
        Onbekend = 0,
        Vrouw = 1,
        Man = 2,
        Kind = 4,
    }
}