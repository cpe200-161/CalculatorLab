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
        public Form1()
        {
            InitializeComponent();
        }

        bool dot = false;
        bool firstTime = false;
        bool first = false;
        bool doIt = false;
        bool change = false;
        string one = null;
        string two = null;
        string type = null;
        int iNum = 0;
        int iType = 0;

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (first)
            {
                lblDisplay.Text = "0";
                first = false;
                dot = false;
                doIt = false;
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length < 8 && btn.Text != ".")
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
            if (btn.Text == "." && dot == false)
            {
                if(lblDisplay.Text == "") lblDisplay.Text = "0" + btn.Text;
                else lblDisplay.Text = lblDisplay.Text + btn.Text;
                dot = true;
            }
            change = true;
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (firstTime == false)
            {
                one = lblDisplay.Text;
                firstTime = true;
            }else
            {
                two = lblDisplay.Text;
                if (type == "+" && doIt == false)
                {
                    lblDisplay.Text = Convert.ToString(float.Parse(one) + float.Parse(two));
                    one = lblDisplay.Text;
                }
                else if (type == "-" && doIt == false)
                {
                    lblDisplay.Text = Convert.ToString(float.Parse(one) - float.Parse(two));
                    one = lblDisplay.Text;
                }
                else if (type == "X" && doIt == false)
                {
                    lblDisplay.Text = Convert.ToString(float.Parse(one) * float.Parse(two));
                    one = lblDisplay.Text;
                }
                else if (type == "÷" && doIt == false)
                {
                    lblDisplay.Text = Convert.ToString(float.Parse(one) / float.Parse(two));
                    one = lblDisplay.Text;
                }
            }
            type = btn.Text;
            first = true;
            doIt = true;
            change = false;
            iType++;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (type != "=" && doIt == false)
            {
                two = lblDisplay.Text;
                doIt = true;
            }
            if (type == "+")
            {
                lblDisplay.Text = Convert.ToString(float.Parse(one) + float.Parse(two));
                one = lblDisplay.Text;
            }else if (type == "-")
            {
                lblDisplay.Text = Convert.ToString(float.Parse(one) - float.Parse(two));
                one = lblDisplay.Text;
            }
            else if (type == "X")
            {
                lblDisplay.Text = Convert.ToString(float.Parse(one) * float.Parse(two));
                one = lblDisplay.Text;
            }
            else if (type == "÷")
            {
                lblDisplay.Text = Convert.ToString(float.Parse(one) / float.Parse(two));
                one = lblDisplay.Text;
            }
            change = false;
            first = true;
            firstTime = false;
            iType++;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            one = null;
            two = null;
            type = null;
            dot = false;
            first = false;
            firstTime = false;
            doIt = false;
            change = false;
            iType = 0;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = Convert.ToString(-1 * float.Parse(lblDisplay.Text));
            if (change == false && iType >= 2) one = lblDisplay.Text;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (type == "+" || type == "-") lblDisplay.Text = Convert.ToString(float.Parse(one) * float.Parse(lblDisplay.Text) / 100);
            else lblDisplay.Text = Convert.ToString(float.Parse(lblDisplay.Text) / 100);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            if (lblDisplay.Text == "") lblDisplay.Text = "0";
        }
    }
}
