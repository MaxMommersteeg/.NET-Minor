using System;

namespace Minor.Dag35.MarcosCooleAttributen
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    [Developer("Me")]
    public class DeveloperAttribute : Attribute
    {
        public string Name { get; }

        // 'positional', 'required' parameter
        public DeveloperAttribute(string developername)
        {
            Name = developername;
        }

        // Named, optional parameter
        public string Date { get; set; }
    }
}
