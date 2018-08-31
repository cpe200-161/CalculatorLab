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
        private double number = 0, val = 0, answer = 0;
        private int OperatorCalculator = 0, i = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void display(double valText)
        {
            lblDisplay.Text = valText.ToString();
        }

        private void numClik(int n, double m = 10)
        {
            number = number * m + n;
            display(number);
        }
 
        private void Calculator(char Operator, double val, double valbefore)
        {
            switch (Operator)
            {
                case '+' :
                    answer = val + valbefore;
                    display(answer);
                    break;

                case '-' :
                    answer = val - valbefore;
                    display(answer);
                    break;

                case '*' :
                    answer = val * valbefore;
                    display(answer);
                    break;

                case '/':
                    answer = val / valbefore;
                    display(answer);
                    break;

                case '%':
                    val /= 100;
                    display(val);
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
            numClik(0,-1);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            
        }
      
        private void btnPlus_Click(object sender, EventArgs e)
        {
            val = number;
            number = 0;
            OperatorCalculator = 1;
            i = 1;
            if (i != 0)
            {

                Calculator('+', answer, val);       
            } 
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            val = number;
            number = 0;
            OperatorCalculator = 2;
            i = 1;
            if (answer != 0)
            {
                Calculator('-', answer, val);  
            } 
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            val = number;
            number = 0;
            OperatorCalculator = 3;
            i = 1;
            if (answer != 0)
            {
                Calculator('*', answer, val); 
            } 
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            val = number;
            number = 0;
            OperatorCalculator = 4;
            i = 1;
            if (answer != 0)
            {
                Calculator('/', answer, val);
            }   
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            val = number;
            number = 0;
            OperatorCalculator = 5;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            number = 0;
            val = 0;
            answer = 0;
            OperatorCalculator = 0;
            i = 0;
            display(answer);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (OperatorCalculator)
            {
                case 1:
                    Calculator('+', val, number);
                    break;

                case 2:
                    Calculator('-', val, number);
                    break;

                case 3:
                    Calculator('*', val, number);
                    break;

                case 4:
                    Calculator('/', val, number);
                    break;

                case 5:
                    Calculator('%', val, number);
                    break;
            }
                
        }
    }
}