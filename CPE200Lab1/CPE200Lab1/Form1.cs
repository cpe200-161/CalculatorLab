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
        string first = null, second = null, ans = null, func = null;
        bool isSecond = false, isDot = false, isTrigger = false, isAns = false, isRes = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (!isAns)
            {
                second = (float.Parse(first) * float.Parse(lblDisplay.Text) / 100).ToString();
                lblDisplay.Text = second;
                isAns = true; isSecond = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            char last = lblDisplay.Text[lblDisplay.Text.Length - 1];

            if (last == '.') isDot = false;

            if (lblDisplay.Text.Length <= 1) lblDisplay.Text = "0";
            else lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
        }

        private void num_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;

            if (lblDisplay.Text == "0" || isSecond) { lblDisplay.Text = ""; isSecond = false; }
            if (lblDisplay.Text.Length < 8) lblDisplay.Text += num.Text;
            isTrigger = false; isAns = false; 
        }

        private void opr_Click(object sender, EventArgs e)
        {
            Button opr = (Button)sender;

            if (func == null || isTrigger) { first = lblDisplay.Text; isSecond = true; isDot = false; }
            else if (!isTrigger && !isRes) btnEqual_Click(sender, e);
            else if (isRes) isRes = false;
            isSecond = true; isTrigger = true; isAns = false;

            if (opr.Text == "+") func = "add";
            else if (opr.Text == "-") func = "sub";
            else if (opr.Text == "X") func = "mul";
            else if (opr.Text == "÷") func = "div";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            first = null; second = null; func = null; isDot = false; isAns = false; isSecond = false; isRes = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Button eq = (Button)sender;

            if(!isAns) second = lblDisplay.Text;

            if (first != null && second != null && func != null)
            {
                if (func == "add") ans = (float.Parse(first) + float.Parse(second)).ToString();
                else if (func == "sub") ans = (float.Parse(first) - float.Parse(second)).ToString();
                else if (func == "mul") ans = (float.Parse(first) * float.Parse(second)).ToString();
                else if (func == "div") ans = (float.Parse(first) / float.Parse(second)).ToString();
                lblDisplay.Text = ans;
            }

            if (eq.Text == "=" && !isRes) isRes = true;

            first = ans; isSecond = true; isDot = false; isTrigger = false; isAns = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(!isDot) lblDisplay.Text += "."; 
            isDot = true; isAns = false;
        }
    }
}
