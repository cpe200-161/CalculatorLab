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

        //fin
        private bool isOperator(char ch)
        {
            return engine.isOperator(ch.ToString());
        }

        
        // fin
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }

            string m = ((Button)sender).Text;
            engine.Btnum(m);

            lblDisplay.Text = engine.Display();
            

        }

        
        //fin
        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            
            string n = ((Button)sender).Text;
            engine.BtBinaryOper_Click(n);
            lblDisplay.Text = engine.Display();
             
            
        }

        

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.BtBack_Click();
            lblDisplay.Text = engine.Display();

        }

        
        //fin
        private void btnClear_Click(object sender, EventArgs e)
        {
            engine.BtClear_Click();
            lblDisplay.Text = engine.Display();

        }

        

        private void btnEqual_Click(object sender, EventArgs e)
        {
            
            engine.BtEq_click();
            lblDisplay.Text = engine.Display();
        }



        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.BtSign__Click();
            lblDisplay.Text = engine.Display();
        }

        

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.BtDot_Click();
            lblDisplay.Text = engine.Display();
        }

        

        protected virtual void btnSpace_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            engine.BtSpace_Click();
            lblDisplay.Text = engine.Display();

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}
