using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag14.NullableAndCovarianceDemos
{

    public interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
        void Set(T item);
    }

    public interface Prison<in T>
    {
        void PutAway(T item);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Nullable<int> a;
            a = 3;
            a = null;

            int b = a.HasValue ? a.Value : 17;
            int c = a ?? a ?? 14;

            string s = null;
            s = "Hello";

            string t = s ?? "bye";
            IEnumerable<int> lijst;

        }
    }
}
