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
        private double val = 0, valbefore = 0, sumA = 0, sumB = 1;
        private int OperatorCalculator;
        public Form1()
        {
            InitializeComponent();
        }

        private void display(double valText, int i = 1)
        {
            if (i == 0) lblDisplay.Text = valText.ToString() + '%';
            else lblDisplay.Text = valText.ToString();
        }

        private void numClik(int n, double m = 10)
        {
            val = val * m + n;
            display(val);
        }

        private void Calculator(char Operator, double Number)
        {
            switch (Operator)
            {
                case '+' :
                    val = 0;
                    sumA += Number;
                    display(sumA);
                    sumB = sumA;
                    break;

                case '-' :
                    val = 0;
                    sumB -= Number;
                    display(sumB);
                    sumA = sumB;
                    break;

                case '*' :
                    val = 0;
                    sumB *= Number;
                    display(sumB);
                    sumA = sumB;
                    break;

                case '/':
                    val = 0;
                    //sumB /= Number;
                    display(sumB);
                    sumA = sumB;
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

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            Calculator('*', val);
            OperatorCalculator = 3;
        }
        
        private void btnPlus_Click(object sender, EventArgs e)
        {
            Calculator('+', val);
            OperatorCalculator = 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Calculator('-', val);
            OperatorCalculator = 2;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Calculator('/', val);
            OperatorCalculator = 4;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            display(val, 0);
            OperatorCalculator = 5;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            val = 0;
            valbefore = 0;
            sumA = 0;
            sumB = 1;
            display(val);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (OperatorCalculator)
            {
                case 1:
                    Calculator('+', val);
                    val = sumA;
                    break;

                case 2:
                    Calculator('-', val);
                    val = sumA;
                    break;

                case 3:
                    Calculator('*', val);
                    val = sumA;
                    break;

                case 4:
                    Calculator('/', val);
                    val = sumA;
                    break;

                case 5:
                    Calculator('%', val);
                    val = sumA;
                    break;
            }
                
        }
    }
}