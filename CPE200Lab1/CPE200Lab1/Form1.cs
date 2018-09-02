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
        private string number;
        private double val = 0, answer = 0;
        private int OperatorCalculator = 0, i = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void display(string text, int i = 0)
        {
            if (text.Length >= 9)
            {
                display("Error");
            }
            else
            {
                switch (i)
                {
                    case 1:
                        lblDisplay.Text = "-" + text;
                        number = lblDisplay.Text;
                        break;

                    case 2:
                        lblDisplay.Text = text + ".";
                        number = lblDisplay.Text;
                        break;

                    case 3:
                        lblDisplay.Text = text + "%";
                        number = lblDisplay.Text;
                        break;

                    default:
                        lblDisplay.Text = text;
                        break;
                }
            }
        }

        private void numClik(double n)
        {
            if (number == "0")
            {
                number = null;
            }
            number += n.ToString();
            display(number);
        }

        private void check(string number)
        {
            if (number == null)
            {
                this.number = "0";
            }
        }
 
        private void Calculator(char Operator, double val, double valbefore)
        {
            switch (Operator)
            {
                case '+' :
                    answer = val + valbefore;
                    display(answer.ToString());
                    break;

                case '-' :
                    answer = val - valbefore;
                    display(answer.ToString());
                    break;

                case '*' :
                    answer = val * valbefore;
                    display(answer.ToString());
                    break;

                case '/':
                    answer = val / valbefore;
                    display(answer.ToString());
                    break;

                case '%':
                    answer = val / 100;
                    number = answer.ToString();
                    break;
            } 
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            numClik(0); 
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            numClik(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            numClik(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            numClik(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            numClik(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            numClik(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            numClik(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            numClik(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            numClik(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            numClik(9);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            display(number, 1);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            display(number, 2);
        }
      
        private void btnPlus_Click(object sender, EventArgs e)
        {
            check(number);
            val = double.Parse(number);
            number = null;
            OperatorCalculator = 1; 
            if (i != 0)
            {
                Calculator('+', answer, val);
            }
            else
            {
                i = 1;
                //Calculator('+', val, 0);
                answer = val;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            check(number);
            val = double.Parse(number);
            number = null;
            OperatorCalculator = 2;
            if (i != 0)
            {
                Calculator('-', answer, val);
            }
            else
            {
                i = 1;
                //Calculator('-', val, 0);
                answer = val;
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            check(number);
            val = double.Parse(number);
            number = null;
            OperatorCalculator = 3;
            if (i != 0)
            {
                Calculator('*', answer, val);
            }
            else
            {
                i = 1;
                //Calculator('*', val, 1);
                answer = val;
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            check(number);
            val = double.Parse(number);
            number = null;
            OperatorCalculator = 4;
            if (i != 0)
            {
                Calculator('/', answer, val);
            }
            else
            {
                i = 1;
                //Calculator('/', val, 1);
                answer = val;
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            check(number);
            val = double.Parse(number);
            number = null;
            display(val.ToString(), 3);
            OperatorCalculator = 5;
            Calculator('%', val, 0);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (number.Length == 1)
            {
                number = "0";
            }
            else
            {
                number = number.Substring(0, number.Length - 1);
            }
            display(number);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            number = null;
            val = 0;
            answer = 0;
            OperatorCalculator = 0;
            i = 0;
            display("0");        
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (OperatorCalculator)
            {
                case 1:
                    Calculator('+', val, double.Parse(number));
                    break;

                case 2:
                    Calculator('-', val, double.Parse(number));
                    break;

                case 3:
                    Calculator('*', val, double.Parse(number));
                    break;

                case 4:
                    Calculator('/', val, double.Parse(number));
                    break;

                case 5:
                    display(answer.ToString());
                    break;
            }
            number = answer.ToString();
        }
    }
}