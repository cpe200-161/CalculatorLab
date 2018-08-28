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
        float num1=0, num2=0;
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
            num1 = float.Parse(lblDisplay.Text);
        }

        private void click_Operbutt(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            re_num = true;
            if(oper == true)
            {
                if (plus == true)
                {
                    num2 += num1;
                    plus = false;
                }
                else if (minus == true)
                {
                    num2 -= num1;
                    minus = false;
                }
                else if (mul == true)
                {
                    num2 *= num1;
                    mul = false;
                }
                else if (div == true)
                {
                    num2 /= num1;
                    div = false;
                }
                oper = false;
            }
            else num2 = num1;
            lblDisplay.Text = num2.ToString();
            oper = true;
            dot = false;
            if (bt.Text == "+") plus = true;
            else if (bt.Text == "-") minus = true;
            else if (bt.Text == "X") mul = true;
            else if (bt.Text == "÷") div = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            num1 = num1 * num2 / 100;
            lblDisplay.Text = num1.ToString();
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
            num1 *= -1;
            lblDisplay.Text = num1.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            num1 = 0;
            num2 = 0;
            oper = false;
        }
    }
}