using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace InfoSupport.Threading.MathLib
{
    public class SlowMath
    {
        private Func<int, int> _squareDelegate;

        public SlowMath()
        {
            _squareDelegate = new Func<int, int>(Square);
        }

        public int Square(int n)
        {
            Thread.Sleep(3000);
            return n * n;
        }

        public IAsyncResult BeginSquare(int n, AsyncCallback callback, object state)
        {
            return _squareDelegate.BeginInvoke(n, callback, state);
        }

        public int EndSquare(IAsyncResult result)
        {
            return _squareDelegate.EndInvoke(result);
        }

        public Task<int> SquareAsync(int n)
        {
            return Task.Factory.StartNew(() => Square(n));
        }
    }
}
