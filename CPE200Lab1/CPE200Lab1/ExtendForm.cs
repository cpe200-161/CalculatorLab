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
        
        private CalculatorEngine engine;

        public ExtendForm()
        {
            InitializeComponent();
            engine = Engine();
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

            string digit = ((Button)sender).Text;
            engine.number_click(digit);
            lblDisplay.Text = engine.Display();

        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {

            string x = ((Button)sender).Text;
            engine.binaryopare(x);
            lblDisplay.Text = engine.Display();

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            engine.backclick();
            lblDisplay.Text = engine.Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            engine.botclear();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            engine.equal();
            lblDisplay.Text = engine.Display();
            
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error") { return; }
            engine.handsigh();
            lblDisplay.Text = engine.Display();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            engine.dot_click();
            lblDisplay.Text = engine.Display();
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {  
            engine.handspace();
            lblDisplay.Text = engine.Display();

        }
    }
}
