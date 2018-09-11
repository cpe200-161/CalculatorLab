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
        
        private    CalculatorEngine engine;

        public ExtendForm ()
        {
            InitializeComponent();
            engine = Engine ();
        }

        protected virtual CalculatorEngine Engine()
        {
            return new CalculatorEngine();
        }


        private  string  Display()
        {
            lblDisplay.Text = engine.Display();
            return lblDisplay.Text;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
         
            string data = ((Button)sender).Text;
            engine.handleNumber(data);
            lblDisplay.Text = engine.Display();

        }
        
        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string data = ((Button)sender).Text;
            engine.handleBinary(data);
            lblDisplay.Text = engine.Display();
        }

        
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.handleBack();
            lblDisplay.Text = engine.Display();
        }

       
        private void btnClear_Click(object sender, EventArgs e)
        {
            engine.handleClear();
            lblDisplay.Text = engine.Display();
        }
       
        private void btnEqual_Click(object sender, EventArgs e)
        {
            engine.handleEqual();
            lblDisplay.Text = engine.Display();
        }
       
        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.handleSign();
            lblDisplay.Text = engine.Display();
        }

        
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.handleDot();
            lblDisplay.Text = engine.Display();
        }
       
       
        private void btnSpace_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            engine.handleSpace();
            lblDisplay.Text = engine.Display();
        }
    }
}
