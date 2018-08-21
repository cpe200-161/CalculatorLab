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
        float n1=0, n2=0;
        Boolean oper=false, plus=false, minus=false, mul=false, div=false, re_num=false, dot=false;

        public Form1()
        {
            InitializeComponent();
        }

        private void click_butt(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (lblDisplay.Text == "0" || re_num == true)
            {
                lblDisplay.Text = "";
                re_num = false;
            }
            if(lblDisplay.Text.Length<8) lblDisplay.Text += bt.Text;
            n1 = float.Parse(lblDisplay.Text);
        }

        private void click_Operbutt(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            re_num = true;
            if(oper == true)
            {
                if (plus == true)
                {
                    n2 += n1;
                    plus = false;
                }
                else if (minus == true)
                {
                    n2 -= n1;
                    minus = false;
                }
                else if (mul == true)
                {
                    n2 *= n1;
                    mul = false;
                }
                else if (div == true)
                {
                    n2 /= n1;
                    div = false;
                }
                oper = false;
            }
            else n2 = n1;
            lblDisplay.Text = n2.ToString();
            oper = true;
            if (bt.Text == "+") plus = true;
            else if (bt.Text == "-") minus = true;
            else if (bt.Text == "X") mul = true;
            else if (bt.Text == "÷") div = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            n1 = n1 * n2 / 100;
            lblDisplay.Text = n1.ToString();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(dot == false && lblDisplay.Text.Length < 8) lblDisplay.Text += ".";
            dot = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length == 1) lblDisplay.Text = "0";
            else lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length-1,1);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            n1 *= -1;
            lblDisplay.Text = n1.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            n1 = 0;
            n2 = 0;
            oper = false;
        }
    }
}