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
    public partial class ExtendForm : Form
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private CalculatorEngine engine;

        

        
        public ExtendForm()
        {
            InitializeComponent();
            engine =Engine();
        }


        protected virtual CalculatorEngine Engine()
        {
            return new CalculatorEngine();

        }

        private bool isOperator(char ch)
        {
            switch(ch) {
                case '+':
                case '-':
                case 'X':
                case '÷':
                    return true;
            }
            return false;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            

            string n = ((Button)sender).Text;
            engine.Number(n);

            lblDisplay.Text = engine.Display();
        }

        

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            string n = ((Button)sender).Text;
            engine.BinaryOperator(n);
            lblDisplay.Text = engine.Display();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Back_Click(sender, e);
            lblDisplay.Text = engine.Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            engine.Clear(sender, e);
            lblDisplay.Text = engine.Display();

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result = engine.Process(lblDisplay.Text);
            if (result is "E")
            {
                lblDisplay.Text = "Error";
            } else
            {
                lblDisplay.Text = result;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isNumberPart)
            {
                return;
            }
            string current = lblDisplay.Text;
            if (current is "0")
            {
                lblDisplay.Text = "-";
            } else if (current[current.Length - 1] is '-')
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "")
                {
                    lblDisplay.Text = "0";
                }
            } else
            {
                lblDisplay.Text = current + "-";
            }
            isSpaceAllowed = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Dot(sender, e);
            lblDisplay.Text = engine.Display();
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Space(sender, e);
            lblDisplay.Text = engine.Display();
        }
    }
}
