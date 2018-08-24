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
        float first, second, sum;
        int plus = 0, minus = 0, multiply = 0, divide = 0;
        int clearb = 0, stat = 0, dotnub = 0;//stat=checkequal
        public Form1()
        {
            InitializeComponent();
        }


        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0"||clearb==1)
            {
                lblDisplay.Text = "";
                if (dotnub == 1)
                    lblDisplay.Text = "0.";
                clearb = 0;
                dotnub = 0;
            }
            
            if (stat == 1)
            {
                first = 0;
                second = 0;
                stat = 0;
                minus = 0;
                plus = 0;
                multiply = 0;
                divide = 0;
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (clearb == 1) { }
            if (plus == 1)
            {
                second = float.Parse(lblDisplay.Text);
                sum = first * second / 100;
                lblDisplay.Text = Convert.ToString(sum);

            }
            else if (minus == 1)
            {
                second = float.Parse(lblDisplay.Text);
                sum = first * second / 100;
                lblDisplay.Text = Convert.ToString(sum);

            }
            else if (multiply == 1)
            {
                second = float.Parse(lblDisplay.Text);
                sum = second / 100;
                lblDisplay.Text = Convert.ToString(sum);

            }
            else if (divide == 1)
            {
                second = float.Parse(lblDisplay.Text);
                sum = second / 100;
                lblDisplay.Text = Convert.ToString(sum);

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "")
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            if (lblDisplay.Text == "")
                lblDisplay.Text = "0";
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            second = float.Parse(lblDisplay.Text);
            second *= -1;
            lblDisplay.Text = Convert.ToString(second);

        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (dotnub == 0)
            {
               

                dotnub++;
                lblDisplay.Text = lblDisplay.Text + ".";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (stat == 1) { plus = 0;minus = 0;divide = 0;multiply = 0; }
            if (clearb == 0 || stat == 1)
            {
                if (multiply == 1 || minus == 1 || divide == 1)
                {
                    second = float.Parse(lblDisplay.Text);
                    if (minus == 1) lblDisplay.Text = Convert.ToString(first - second);
                    else if (multiply == 1) lblDisplay.Text = Convert.ToString(first * second);
                    else if (divide == 1) lblDisplay.Text = Convert.ToString(first / second);
                    minus = 0;
                    plus = 1;
                    multiply = 0;
                    divide = 0;
                    clearb = 1;
                    first = float.Parse(lblDisplay.Text);
                    stat = 0;
                }
                else if (plus == 0)
                {
                    first = float.Parse(lblDisplay.Text);
                    plus = 1;
                    minus = 0;
                    clearb = 1;
                    stat = 0;
                }
                else if (plus == 1)
                {
                    if (lblDisplay.Text == "" || clearb == 1) { }
                    else
                    {
                        second = float.Parse(lblDisplay.Text);
                        lblDisplay.Text = Convert.ToString(first + second);
                        clearb = 1;
                        first = float.Parse(lblDisplay.Text);
                        stat = 0;
                    }
                }
            }
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (stat == 1) { plus = 0; minus = 0; divide = 0; multiply = 0; }
            if (clearb== 0 || stat == 1)
            {
                if (multiply == 1 || plus == 1 || divide == 1)
                {
                    second = float.Parse(lblDisplay.Text);
                    if (plus == 1) lblDisplay.Text = Convert.ToString(first + second);
                    else if (multiply == 1) lblDisplay.Text = Convert.ToString(first * second);
                    else if (divide == 1) lblDisplay.Text = Convert.ToString(first / second);
                    minus = 1;
                    plus = 0;
                    multiply = 0;
                    divide = 0;
                    clearb = 1;
                    first = float.Parse(lblDisplay.Text);
                    stat = 0;
                }
                else if (minus == 0)
                {
                    first = float.Parse(lblDisplay.Text);
                    minus = 1;
                    clearb = 1;
                    stat = 0;
                }
                else if (minus == 1)
                {
                    if (lblDisplay.Text == "" || clearb == 1) { }
                    else
                    {
                        second = float.Parse(lblDisplay.Text);
                        lblDisplay.Text = Convert.ToString(first - second);
                        clearb = 1;
                        first = float.Parse(lblDisplay.Text);
                        stat = 0;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            stat = 0;
            first = 0;
            second = 0;
            stat = 0;
            minus = 0;
            plus = 0;
            multiply = 0;
            divide = 0;
            clearb = 0;
            dotnub = 0;
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (stat == 1) { plus = 0; minus = 0; divide = 0; multiply = 0; }
            if (clearb == 0 || stat == 1)
            {
                if (plus == 1 || minus == 1 || divide == 1)
                {
                    second = float.Parse(lblDisplay.Text);
                    if (plus == 1) lblDisplay.Text = Convert.ToString(first + second);
                    else if (minus == 1) lblDisplay.Text = Convert.ToString(first - second);
                    else if (divide == 1) lblDisplay.Text = Convert.ToString(first / second);
                    minus = 0;
                    plus = 0;
                    divide = 0;
                    multiply = 1;
                    clearb = 1;
                    first = float.Parse(lblDisplay.Text);
                    stat = 0;
                }
                else if (multiply == 0)
                {
                    first = float.Parse(lblDisplay.Text);
                    multiply = 1;
                    minus = 0;
                    plus = 0;
                    divide = 0;
                    clearb = 1;
                    stat = 0;
                }
                else if (multiply == 1)
                {
                    if (lblDisplay.Text == "" || clearb == 1) { }
                    else
                    {
                        second = float.Parse(lblDisplay.Text);
                        lblDisplay.Text = Convert.ToString(first * second);
                        clearb = 1;
                        first = float.Parse(lblDisplay.Text);
                        stat = 0;
                    }
                }
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {

            if (stat == 1) {plus = 0; minus = 0; divide = 0; multiply = 0; }
            if (clearb == 0||stat==1)
            {
                if (multiply == 1 || minus == 1 || plus == 1)
                {
                    second = float.Parse(lblDisplay.Text);
                    if (plus == 1) lblDisplay.Text = Convert.ToString(first + second);
                    else if (minus == 1) lblDisplay.Text = Convert.ToString(first - second);
                    else if (multiply == 1) lblDisplay.Text = Convert.ToString(first * second);
                    minus = 0;
                    plus = 0;
                    multiply = 0;
                    divide = 1;
                    clearb = 1;
                    first = float.Parse(lblDisplay.Text);
                    stat = 0;
                }
                else if (divide == 0)
                {
                    first = float.Parse(lblDisplay.Text);
                    multiply = 0;
                    minus = 0;
                    plus = 0;
                    divide = 1;
                    clearb = 1;
                    stat = 0;
                }
                else if (divide == 1)
                {
                    if (lblDisplay.Text == "" || clearb == 1) { }
                    else
                    {
                        second = float.Parse(lblDisplay.Text);
                        lblDisplay.Text = Convert.ToString(first / second);
                        clearb = 1;
                        first = float.Parse(lblDisplay.Text);
                        stat = 0;
                    }
                }

            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {

            if (plus == 1)
            {
                if (stat == 0)
                
                    second = float.Parse(lblDisplay.Text);
                    sum = first + second;
                    lblDisplay.Text = Convert.ToString(sum);
                    clearb = 1;
                    stat = 1;
                    first = float.Parse(lblDisplay.Text);
                
            }


            else if (minus == 1)
            {
                if (stat == 0) second = float.Parse(lblDisplay.Text);
                sum = first - second;
                lblDisplay.Text = Convert.ToString(sum);
                clearb = 1;
                stat = 1;
                first = float.Parse(lblDisplay.Text);

            }

            else if (multiply == 1)
            {
                if (stat == 0) second = float.Parse(lblDisplay.Text);
                sum = first * second;
                lblDisplay.Text = Convert.ToString(sum);
                clearb = 1;
                stat = 1;
                first = float.Parse(lblDisplay.Text);
            }

            else if (divide == 1)
            {
                if (stat == 0) second = float.Parse(lblDisplay.Text);
                sum = first / second;
                lblDisplay.Text = Convert.ToString(sum);
                clearb = 1;
                stat = 1;
                first = float.Parse(lblDisplay.Text);
            }
        }
    }
}
