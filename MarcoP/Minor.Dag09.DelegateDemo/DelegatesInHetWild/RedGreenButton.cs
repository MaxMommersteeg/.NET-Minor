using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegatesInHetWild
{
    public class RedGreenButton : Button
    {
        protected override void OnClick(EventArgs e)
        {
            this.BackColor = Color.Red;
            base.OnClick(e);
            this.BackColor = Color.GreenYellow;
        }
    }
}
