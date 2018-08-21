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
        private int a;
        private double b;
        private char op = ' ';
        private bool flag = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void showDigit(int p)
        {
            if (checkDisplay()) lblDisplay.Text = p.ToString();
            else lblDisplay.Text += p.ToString();
        }

        private void showDigit(string p)
        {
            if (lblDisplay.Text.Contains(".")) return;
            else lblDisplay.Text += p;
        }

        private bool checkDisplay()
        {
            if (flag)
            {
                flag = false;
                return true;
            }else
            {
                return false;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            showDigit(1);

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            showDigit(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            showDigit(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            showDigit(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            showDigit(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            showDigit(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            showDigit(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            showDigit(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            showDigit(9);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            showDigit(0);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            showDigit(".");
        }

        private void Cal(double a)
        {
            switch (op)
            {
                case '+':
                    b = (b + a);
                    break;
                case '-':
                    b = (b - a);
                    break;
                case '*':
                    b = (b * a);
                    break;
                case '/':
                    b = (b / a);
                    break;
                case '%':
                    b = (b % a);
                    break;
                default: b = a;
                    break;
            }
        }

        private void setOperator(char p)
        {
            Cal(double.Parse(lblDisplay.Text));
            op = p;
            lblDisplay.Text += lblDisplay.Text + p;
            lblDisplay.Text = b.ToString();

            flag = true;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            setOperator('+');
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Cal(double.Parse(lblDisplay.Text));
            lblDisplay.Text = b.ToString();
            op = ' ';
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            op = ' ';
            flag = true;
            b = 0.00;
            
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.StartsWith("-"))
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1);
            }
            else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            /*
            if (lblDisplay.Text == "0")
            {
               lblDisplay.Text = "0";
            }
            else
            {
               lblDisplay.Text = lblDisplay.Text.Substring(lblDisplay.Text.Length);
             }
             */
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            setOperator('/');
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            setOperator('*');
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            setOperator('-');
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            setOperator('%');
        }
    }
}
