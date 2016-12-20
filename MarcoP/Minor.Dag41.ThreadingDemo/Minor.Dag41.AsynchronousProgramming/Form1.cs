using InfoSupport.Threading.MathLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minor.Dag41.AsynchronousProgramming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            int invoer = int.Parse(txtInput.Text);

            SlowMath math = new SlowMath();
            IAsyncResult ar = math.BeginSquare(invoer, SquareCalculated, math);
        }

        private void SquareCalculated(IAsyncResult ar)
        {
            SlowMath math = (SlowMath) ar.AsyncState;

            int uitvoer = math.EndSquare(ar);

            var somedelegate = (MethodInvoker)(() =>
            {
                txtOutput.Text = uitvoer.ToString();
            });

            Invoke(somedelegate);
        }
    }
}
