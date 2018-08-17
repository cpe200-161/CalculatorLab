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
        private Stack<double> valStack = new Stack<double>();
        private Stack<int> opStack = new Stack<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void display()
        {
            lblDisplay.Text = val.ToString();
        }

        private void numClick(int n)
        {
            val = val * 10 + n;
            display();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            numClick(0);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            numClick(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            numClick(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            numClick(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            numClick(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            numClick(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            numClick(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            numClick(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            numClick(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            numClick(9);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            val = 0;
            valStack.Clear();
            opStack.Clear();
            display();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            while (opStack.Count > 0)
            {
                ComputeAndDisplay();
            }
        }

        private void ComputeAndDisplay()
        {
            val = DoOp(valStack.Pop(), opStack.Pop(), val);
            display();
        }

        private double DoOp(double op1, int op, double op2)
        {
            switch (op)
            {
                case 1: // plus
                    return op1 + op2;
                case 2: // minus
                    return op1 - op2;
                case 3: // mult
                    return op1 * op2;
                case 4: // div
                    return op1 / op2;
                default:
                    return 0;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            while (opStack.Count > 0)
            {
                ComputeAndDisplay();
            }
            valStack.Push(val);
            opStack.Push(1);
            val = 0;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            while (opStack.Count > 0)
            {
                ComputeAndDisplay();
            }
            valStack.Push(val);
            opStack.Push(2);
            val = 0;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            while (opStack.Count > 0 && opStack.Peek() >= 3)
            {
                ComputeAndDisplay();
            }
            valStack.Push(val);
            opStack.Push(3);
            val = 0;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            while (opStack.Count > 0 && opStack.Peek() >= 3)
            {
                ComputeAndDisplay();
            }
            valStack.Push(val);
            opStack.Push(4);
            val = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            val = (val - val%10) / 10;
            display();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            val = -val;
            display();
        }
    }
}
