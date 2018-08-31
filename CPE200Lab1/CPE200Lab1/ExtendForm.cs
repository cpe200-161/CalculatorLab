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
            engine = new CalculatorEngine();
        }


        private void btnNumber_Click(object sender, EventArgs e)
        {
	
			//lblDisplay.Text += ((Button)sender).Text;
			string num = ((Button)sender).Text;
			//string num = lblDisplay.Text;
			engine.amount_click(num);
			lblDisplay.Text = engine.screen();
			//amount
        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
			String bi = ((Button)sender).Text;
			engine.two_operator(bi);
			lblDisplay.Text = engine.screen();
		}

        private void btnBack_Click(object sender, EventArgs e)
        {
			engine.back();
			lblDisplay.Text = engine.screen();
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
			engine.clean();
			lblDisplay.Text = engine.screen();
			//clean
		}

        private void btnEqual_Click(object sender, EventArgs e)
        {
			engine.balance();
			lblDisplay.Text = engine.screen();
		}

        private void btnSign_Click(object sender, EventArgs e)
        {
			engine.sign();
			lblDisplay.Text = engine.screen();
		}

        private void btnDot_Click(object sender, EventArgs e)
        {
			engine.Dot();
			lblDisplay.Text = engine.screen();
		}

        private void btnSpace_Click(object sender, EventArgs e)
        {
			engine.space();
			lblDisplay.Text = engine.screen();
		}

		private void ExtendForm_Load(object sender, EventArgs e)
		{

		}

		private void lblDisplay_Click(object sender, EventArgs e)
		{

		}
	}
}
