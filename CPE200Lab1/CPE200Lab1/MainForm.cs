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
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;

        private CalculatorEngine engine = new CalculatorEngine();

       
        
       


        private void resetAll()
        {
            engine.resetAll();
            resetAll();

        }

        private string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            engine.Calculator();
            lblDisplay.Text = engine.Display();
        }

        public MainForm()
        {
            InitializeComponent();

            resetAll();
            engine = new CalculatorEngine();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string x = ((Button)sender).Text;
            engine.Number(y);
            lblDisplay.Text = engine.Display();
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            engine.Operator();
            resetAll();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Equal();
            resetAll();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
        
            engine.Dot();
            lblDisplay.Text = engine.Display();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            engine.Sign();
            lblDisplay.Text = engine.Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            engine.Back();
            lblDisplay.Text = engine.Display();
        }
    }
}
