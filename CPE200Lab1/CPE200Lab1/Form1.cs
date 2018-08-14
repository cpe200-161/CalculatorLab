using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        string first = null, second = null, ans = null;
        string func = null, tempfunc = null;
        bool isSecond = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || isSecond) { lblDisplay.Text = ""; isSecond = false; }
            if (lblDisplay.Text.Length < 8) lblDisplay.Text += btn.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            first = null; second = null; func = null; tempfunc = null;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            second = lblDisplay.Text;

            if (func == "add") ans = (float.Parse(first) + float.Parse(second)).ToString();
            else if (func == "sub") ans = (float.Parse(first) - float.Parse(second)).ToString();
            else if (func == "mul") ans = (float.Parse(first) * float.Parse(second)).ToString();
            else if (func == "div") ans = (float.Parse(first) / float.Parse(second)).ToString();

            if(tempfunc != null) func = tempfunc;

            lblDisplay.Text = ans; first = ans; isSecond = true;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (func == null) { first = lblDisplay.Text; func = "add"; isSecond = true; }
            else { tempfunc = "add"; btnEqual_Click(sender, e); }
            isSecond = true;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (func == null) { first = lblDisplay.Text; func = "sub"; isSecond = true; }
            else { tempfunc = "sub"; btnEqual_Click(sender, e); }
            isSecond = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (func == null) { first = lblDisplay.Text; func = "mul"; isSecond = true; }
            else { tempfunc = "mul"; btnEqual_Click(sender, e); }
            isSecond = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (func == null) { first = lblDisplay.Text; func = "div"; isSecond = true; }
            else { tempfunc = "div"; btnEqual_Click(sender, e); }
            isSecond = true;
        }
    }
}
