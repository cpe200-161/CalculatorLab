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
        private double val = 0;
        private double sum = 0;
        private string num;
        private int Oper = 0, i = 0;


        public Form1()
        {
            InitializeComponent();
        }


        private void display(string text, int i = 0) {
            if (text.Length > 9)
            {
                display("Error");
            }
            else {
                switch (i)
                {
                    case 1:
                        lblDisplay.Text = "-" + text;
                        num = lblDisplay.Text;
                        break;

                    case 2:
                        lblDisplay.Text = text + ".";
                        num = lblDisplay.Text;
                        break;

                    case 3:
                        lblDisplay.Text = text + "%";
                        num = lblDisplay.Text;
                        break;

                    default:
                        lblDisplay.Text = text;
                        break;
                        
                }

            }

        }
        private void numclick(double m)
        {
            if (num == "0")
            {
                num = null;
            }
            num += m.ToString();
            display(num);
        }

        private void check(string num, int i = 0)
        {
            if (i == 0)
            {
                if (num == null)
                {
                    this.num = "0"; }
            }
            if (i == 1)
            {
                string ans;
                while ((sum.ToString()).Length > 9)
                {
                    ans = (sum.ToString()).Substring(0, (sum.ToString()).Length - 1);
                    sum = double.Parse(ans);
                }
            }

        }

        private void calcu(char oprt, double val, double before)
        {
            switch (oprt)
            {
                case '+':
                    sum = val + before;
                    display(sum.ToString());
                    break;

                case '-':
                    sum = val - before;
                    display(sum.ToString());
                    break;

                case '*':
                    sum = val * before;
                    display(sum.ToString());
                    break;

                case '/':
                    sum = val / before;
                    check(sum.ToString(), 1);
                    display(sum.ToString());
                    break;

                case '%':
                    sum = val / 100;
                    check(sum.ToString(), 1);
                    display(sum.ToString());
                    break;
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            numclick(1);    
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            numclick(2);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            numclick(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            numclick(4);
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            numclick(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            numclick(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            numclick(7);
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            numclick(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            numclick(9);
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            numclick(0);
        }

       
        private void btnSign_Click(object sender, EventArgs e)
        {
            display(num, 1);
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            display(num, 2);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
                num = null;
                val = 0;
                sum = 0;
                Oper = 0;
                i = 0;
                display("0");

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
                check(num);
                val = double.Parse(num);
                if (Oper != 3 && Oper != 0)
                {
                    if (Oper == 1)
                    {
                        calcu('+', sum, val);
                    }
                    else if (Oper == 2)
                    {
                        calcu('-', sum, val);
                    }
                    else if (Oper == 4)
                    {
                        calcu('/', sum, val);
                    }
                    val = sum;
                }else
                {
                if (i != 0)
                {
                    calcu('*', sum, val);
                } else
                {
                    i = 1;
                    calcu('*', val, 1);
                }
            }
            Oper = 3;
            num = null;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            check(num);
            val = double.Parse(num);
            if (Oper != 4 && Oper != 0)
            {
                if (Oper == 1)
                {
                    calcu('+', sum, val);
                }
                else if (Oper == 2)
                {
                    calcu('-', sum, val);
                }
                else if (Oper == 3)
                {
                    calcu('*', sum, val);
                }
                val = sum;
            }
            else
            {
                if (i != 0)
                {
                    calcu('/', sum, val);
                }
                else
                {
                    i = 1;
                    calcu('/', val, 1);
                }
            }
            Oper = 4;
            num = null;
        }


        private void btnPlus_Click(object sender, EventArgs e)
        {
            check(num);
            val = double.Parse(num);
            if (Oper != 1 && Oper != 0)
            {
                if (Oper == 2)
                {
                    calcu('-', sum, val);
                } else if (Oper == 3)
                {
                    calcu('*', sum, val);
                } else if (Oper == 4)
                {
                    calcu('/', sum, val);
                }
                val = sum;
            }
            else
            {
                if (i != 0)
                {
                    calcu('+', sum, val);
                }
                else
                {
                    i = 1;
                    calcu('+', val, 0);
                }
            }
            Oper = 1;
            num = null;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            check(num);
            val = double.Parse(num);
            if (Oper != 2 && Oper != 0)
            {
                if (Oper == 1)
                {
                    calcu('+', sum, val);
                }
                else if (Oper == 3)
                {
                    calcu('*', sum, val);
                }
                else if (Oper == 4)
                {
                    calcu('/', sum, val);
                }
                val = sum;
            }
            else
            {
                if (i != 0)
                {
                    calcu('-', sum, val);
                }
                else
                {
                    i = 1;
                    calcu('-', val, 0);
                }
            }
            Oper = 2;
            num = null;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if(num.Length == 1)
            {
                num = "0";
            }else
            {
                num = num.Substring(0,num.Length - 1);
            }
            display(num);
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            check(num);
            val = double.Parse(num);
            display(val.ToString(), 3);
            calcu('%', val, 0);
            Oper = 5;
            num = null;
        }


        private void btnEqual_Click(object sender, EventArgs e)
        {

            switch (Oper)
            {
                case 1:
                    calcu('+', val, double.Parse(num));
                    break;
                case 2:
                    calcu('-', val, double.Parse(num));
                    break;
                case 3:
                    calcu('*', val, double.Parse(num));
                    break;
                case 4:
                    calcu('/', val, double.Parse(num));
                    break;
                case 5:
                    display(sum.ToString());
                    break;
            }
                num = sum.ToString();
                i = 0;
        }
    } 
}
