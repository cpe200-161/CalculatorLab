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
        protected CalculatorEngine engine;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            Display();
        }
        
        private void Display()
        {
            lblDisplay.Text = engine.Display();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Num_click(((Button)sender).Text);
            Display();
        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Binary(((Button)sender).Text);
            Display();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            // check if the last one is operator
            engine.Back();
            Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            engine.Clear();
            Display();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            //if()
            engine.Equal();
            Display();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Sign();
            Display();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Dot();
            Display();
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Space();
            Display();
        }
    }
}
