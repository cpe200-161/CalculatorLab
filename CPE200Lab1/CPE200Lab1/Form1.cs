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
        private double sum;
        private char Op = ' ';
        private bool flag = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void display()
        {
            lblDisplay.Text = sum.ToString();
        }

        private void ShowD(int p)
        {
            if (CheckDisplay()) lblDisplay.Text = p.ToString();
            else lblDisplay.Text += p.ToString();
        }

        private void ShowD(string p)
        {
            if (lblDisplay.Text.Contains("."))
            {
                return;
            }
            else
            {
                lblDisplay.Text += p;
            }
        }

        private bool CheckDisplay()
        {
            if (flag)
            {
                flag = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            ShowD(1);
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            ShowD(2);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            ShowD(3);
        }
       private void btn4_Click(object sender, EventArgs e)
        {
            ShowD(4);
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            ShowD(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            ShowD(6);
        }
 
        private void btn7_Click(object sender, EventArgs e)
        {
            ShowD(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            ShowD(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            ShowD(9);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            ShowD(0);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            ShowD(".");
        }

        private void SetOp(char p)
        {
            Cal(Double.Parse(lblDisplay.Text));
            Op = p;
            lblDisplay.Text += lblDisplay.Text;
            lblDisplay.Text = sum.ToString();
            flag = true;
        }
        
        private void Cal(double a)
        {
            switch(Op)
            {
                case '+':
                    sum = (sum + a);
                    break;
                case '-':
                    sum = (sum - a);
                    break;
                case '*':
                    sum = (sum * a);
                    break;
                case '/':
                    sum = (sum / a);
                    break;
                case '%':
                    sum = (sum % a);
                    break;
                default: sum = a;
                    break;

            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            SetOp('+');
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            SetOp('-');
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            SetOp('*');
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            SetOp('/');
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            SetOp('%');
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Cal(Double.Parse(lblDisplay.Text));
            lblDisplay.Text = sum.ToString();
            Op = ' '; 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            Op = ' ';
            flag = true;
            sum = 0.00;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
        }
    }
}
