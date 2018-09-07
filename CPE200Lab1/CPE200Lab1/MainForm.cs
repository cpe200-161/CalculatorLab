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
		

		private CalculatorEngine engine = new CalculatorEngine();

        private void resetAll()
        {
            lblDisplay.Text = engine.Display();
			engine.resetAll();
        }

        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
			string digit = ((Button)sender).Text;
			engine.swit(((Button)sender).Text);
			
			engine.Num();
			lblDisplay.Text = engine.Display();

		}

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }

			string operate = ((Button)sender).Text;

			engine.switop(operate);

			engine.Operlator();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
			engine.Equal();
			lblDisplay.Text = engine.Display();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
			engine.Dot();
			lblDisplay.Text = engine.Display();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
			engine.handleSign();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
			engine.Back();
			lblDisplay.Text = engine.Display();
        }
    }
}
