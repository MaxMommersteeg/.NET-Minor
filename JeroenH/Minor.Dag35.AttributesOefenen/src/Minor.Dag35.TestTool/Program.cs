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

            Assembly assembly = Assembly.Load(new AssemblyName("Minor.Dag35.VoorbeeldKlasse"));
            foreach (Type type in assembly.GetTypes())
            {

                Console.WriteLine(type.FullName);
                foreach (var method in type.GetMethods(
                    BindingFlags.DeclaredOnly
                    | BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance)
                    )
                {
                    PrintMethodSignature(method);
                    foreach (var testAttr in method.GetCustomAttributes<TestAttribute>())
                    {
                        object[] inputParameters = testAttr.InputArgs;
                        object outputParameter = testAttr.Output;
                        string expectedException = testAttr.ExpectedException;

                        object instance = Activator.CreateInstance(type);
                        try
                        {
                            object result = method.Invoke(instance, inputParameters);
                            OutputCheck(outputParameter, expectedException, result);
                        }
                        catch (Exception e)
                        {
                            ExceptionCheck(expectedException, e);
                        }
                    }
                }
            }
        }

        private static void ExceptionCheck(string expectedException, Exception e)
        {
            if (expectedException != null)
            {
                if (e.GetBaseException().GetType().Name != expectedException)
                {
                    Console.WriteLine($"Test Failed. test produced an unexpected exception of type {e.GetType().Name}");
                }
                else
                {
                    Console.WriteLine("Test Succes");
                }
            }
            else
            {
                Console.WriteLine($"Test Failed. test produced an unexpected exception of type {e.GetType().Name}");
            }
        }

        private static void PrintMethodSignature(MethodInfo method)
        {
            string accessModifier = "";
            string staticCheck = "";


            if (method.IsPublic)
                accessModifier = "public";
            else if (method.IsPrivate)
                accessModifier = "private";
            else if (method.IsAssembly)
                accessModifier = "internal";
            else if (method.IsFamily)
                accessModifier = "protected";
            if (method.IsFamilyOrAssembly)
                accessModifier = "protected internal";


            if (method.IsStatic)
                staticCheck = "static ";

            String[] param = method.GetParameters()
                .Select(p => String.Format("{0} {1}", p.ParameterType.Name, p.Name))
                .ToArray();

            string signature = String.Format("{0} {1}({2})", method.ReturnType.Name, method.Name, String.Join(",", param));


            Console.WriteLine($"\t {accessModifier} {staticCheck}{signature}");
        }

        private static void OutputCheck(object outputParameter, string expectedException, object result)
        {
            if (expectedException == null)
            {
                if (outputParameter != null)
                {
                    if (outputParameter.Equals(result))
                    {
                        Console.WriteLine("Test Succes");
                    }
                    else
                    {
                        Console.WriteLine($"Test Failed. Output was {result} instead of {outputParameter}");
                    }
                }
                else
                {
                    Console.WriteLine("Test Succes");
                }
            }
            else
            {
                Console.WriteLine($"Test Failed. Test did not produce expected exception of type {expectedException}");
            }
        }
    }
}
