using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegatesInHetWild
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, EventArgs e)
        {
            ShowDialog();
            SetText();
        }

        private void SetText()
        {
            txtGroet.Text = "Hello, world";
        }

        private new void ShowDialog()
        {
            MessageBox.Show("Hello, world");
        }
    }
}
