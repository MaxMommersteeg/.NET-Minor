using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class TestAttribute : Attribute
{
    private object _output;
    private string _expectedException;
    public object[] InputArgs { get;}

    public TestAttribute(params object[] arguments)
    {
        InputArgs = arguments;
        _output = Output;
        _expectedException = ExpectedException;
    }

    public object Output { get; set; }
    public string ExpectedException { get; set; }
}