using Minor.Dag35.MarcosCooleAttributen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Minor.Dag35.TestTool
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Assembly assembly = Assembly.Load(new AssemblyName("Minor.Dag35.TtyItOutLibje"));
            Console.WriteLine(assembly.FullName);

            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine($"public class {type.Name}");

                foreach(var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    foreach(var devAttr in method.GetCustomAttributes<DeveloperAttribute>())
                    {
                        Console.WriteLine($"\tDeveloper was: {devAttr.Name}");
                    }
                    if (method.DeclaringType == type)
                    {
                        Console.WriteLine($"\tpublic int {method.Name}(int n)");

                        object instance = Activator.CreateInstance(type);
                        object[] parameters = { 5 };

                        object result = method.Invoke(instance, parameters);

                        Console.WriteLine($"\t\t{method.Name}(5) = {result}");
                    }
                    
                }
            }
            
        }
    }
}
