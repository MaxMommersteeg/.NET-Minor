using InfoSupport.Threading.MathLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minor.Dag41.ThreadingOefening
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSumOfSquares_Click(object sender, EventArgs e)
        {
            int[] invoer = new int[3];
            if (int.TryParse(txtInvoer1.Text, out invoer[0]) &&
                int.TryParse(txtInvoer2.Text, out invoer[1]) &&
                int.TryParse(txtInvoer3.Text, out invoer[2]))
            {
                new Thread(CalulateSumSquares2).Start(invoer);
            }
        }

        private void CalulateSumSquares(object invoerObj)
        {
            int[] invoer = (int[])invoerObj;

            SlowMath math = new SlowMath();
            var ar0 = math.BeginSquare(invoer[0], null, null);
            var ar1 = math.BeginSquare(invoer[1], null, null);
            var ar2 = math.BeginSquare(invoer[2], null, null);

            int sum = 0;
            sum += math.EndSquare(ar0);
            sum += math.EndSquare(ar1);
            sum += math.EndSquare(ar2);

            Invoke((MethodInvoker)(() => {
                txtUitvoer.Text = sum.ToString();
            }));
        }




        private void CalulateSumSquares2(object invoerObj)
        {
            int[] invoer = (int[])invoerObj;

            SlowMath math = new SlowMath();

            int sum = invoer.Select(n => math.BeginSquare(n, null, null))
                            .ToList()
                            .Select(ar => math.EndSquare(ar))
                            .Sum();

            Invoke(new Action(() => {
                txtUitvoer.Text = sum.ToString();
            }));
        }

        private async void btnSumOfSquaresAsync_Click(object sender, EventArgs e)
        {
            int[] invoer = new int[3];
            if (int.TryParse(txtInvoer1.Text, out invoer[0]) &&
                int.TryParse(txtInvoer2.Text, out invoer[1]) &&
                int.TryParse(txtInvoer3.Text, out invoer[2]))
            {
                SlowMath math = new SlowMath();

                //var squares1 = await Task.WhenAll(invoer.Select(n => math.SquareAsync(n)));
                var squares2 = await from n in invoer
                                     select math.SquareAsync(n);

                txtUitvoer.Text = squares2.Sum().ToString();
            }
        }
    }

    public static class IEnumerableExtension
    {
        public static TaskAwaiter GetAwaiter(this IEnumerable<Task> tasks)
        {
            return Task.WhenAll(tasks).GetAwaiter();
        }
        public static TaskAwaiter<T[]> GetAwaiter<T>(this IEnumerable<Task<T>> tasks)
        {
            return Task.WhenAll(tasks).GetAwaiter();
        }
    }
}
