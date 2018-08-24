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

		private void resetAll()
		{
			engine.resetAll();
			lblDisplay.Text = engine.Display();
		}

		private CalculatorEngine engine = new CalculatorEngine();

        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
           			string digit = ((Button)sender).Text;
			        engine.figure = digit;
			        engine.amount();
			        lblDisplay.Text = engine.Display();

		}//discuit

        private void btnOperator_Click(object sender, EventArgs e)//discult
        {
			string operate = ((Button)sender).Text;
			engine.actor(operate);
			lblDisplay.Text = engine.Display();

		}

        private void btnEqual_Click(object sender, EventArgs e)
        {
			engine.balance();
			lblDisplay.Text = engine.Display();
		}

        private void btnDot_Click(object sender, EventArgs e)
        {
			engine.point();
			lblDisplay.Text = engine.Display();
		}

        private void btnSign_Click(object sender, EventArgs e)
        {
			engine.mark();
			lblDisplay.Text = engine.Display();
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
			engine.removeLastDigit();

			lblDisplay.Text = engine.Display();
		}
    }
}
