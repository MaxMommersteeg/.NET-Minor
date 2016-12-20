using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class TestAttribute : Attribute
{
    private object[] _inputargs;
    private object _output;
    private string _expectedException;
    public object InputArgs { get; private set; }

    public TestAttribute( object Output = null, string ExpectedException = null, params object[] arguments)
    {
        _inputargs = arguments;
        _output = Output;
        _expectedException = ExpectedException;
    }
}