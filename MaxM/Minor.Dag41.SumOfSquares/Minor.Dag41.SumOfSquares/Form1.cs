using InfoSupport.Threading.MathLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minor.Dag41.SumOfSquares
{
    public partial class Form1 : Form
    {
        private ConcurrentBag<int> _results;
        private DateTime _startDateTime;
        private DateTime _endDateTime;

        private int _input1, _input2, _input3;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSumOfSquares_Click(object sender, EventArgs e)
        {
            _startDateTime = DateTime.Now;

            if(!ValidateInputControls())
                return;

            _results = new ConcurrentBag<int>();
            txtOutput.Text = string.Empty;

            SlowMath slowMath = new SlowMath();
            slowMath.BeginSquare(_input1, OnSquareResultReceived, slowMath);
            slowMath.BeginSquare(_input2, OnSquareResultReceived, slowMath);
            slowMath.BeginSquare(_input3, OnSquareResultReceived, slowMath);
        }

        private void OnSquareResultReceived(IAsyncResult asyncResult)
        {
            SlowMath math = (SlowMath)asyncResult.AsyncState;
            var tempResult = math.EndSquare(asyncResult);

            _results.Add(tempResult);
            if(_results.Count == 3)
            {
                var updateTxtOutput = (MethodInvoker)(() =>
                {
                    var temp = _results.Sum().ToString();
                    txtOutput.Text = temp;
                });
                Invoke(updateTxtOutput);
                _endDateTime = DateTime.Now;
                MessageBox.Show(_startDateTime.ToString() + " - " + _endDateTime.ToString());
            }
        }

        private async void btnSumOfSquaresAsync_Click(object sender, EventArgs e)
        {
            _startDateTime = DateTime.Now;

            if (!ValidateInputControls())
                return;

            SlowMath math = new SlowMath();

            Task<int> task1 = math.SquareAsync(_input1);
            Task<int> task2 = math.SquareAsync(_input2);
            Task<int> task3 = math.SquareAsync(_input3);

            //var result = await Task.WhenAll(new List<int> { _input1, _input2, _input3 }.Select(i => math.SquareAsync(i)));

            int result1 = await task1;
            int result2 = await task2;
            int result3 = await task3;

            txtOutput.Text = (result1 + result2 + result3).ToString();

            _endDateTime = DateTime.Now;

            MessageBox.Show(_startDateTime.ToString() + " - " + _endDateTime.ToString());
        }

        private bool ValidateInputControls()
        {
            // Retrieve input
            if (string.IsNullOrWhiteSpace(txtInput1.Text) ||
                string.IsNullOrWhiteSpace(txtInput2.Text) ||
                string.IsNullOrWhiteSpace(txtInput3.Text))
            {
                MessageBox.Show("Enter numbers");
                return false;
            }

            // Some nice checks hehe
            if (!int.TryParse(txtInput1.Text, out _input1))
            {
                MessageBox.Show("Enter valid input 1");
                return false;
            }
            if (!int.TryParse(txtInput2.Text, out _input2))
            {
                MessageBox.Show("Enter valid input 2");
                return false;
            }
            if (!int.TryParse(txtInput3.Text, out _input3))
            {
                MessageBox.Show("Enter valid input 3");
                return false;
            }
            return true;
        }
    }
}
