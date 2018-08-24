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
            engine.resetAll();
            lblDisplay.Text = engine.Display();
        }

        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }
        

        

        //not FIN

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string op = ((Button)sender).Text;
           
            engine.Num_Click(op);
            lblDisplay.Text = engine.Display();
        }

        //not FIN

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string R_Operate = ((Button)sender).Text;
           
            engine.Operator_Click(R_Operate);
            lblDisplay.Text = engine.Display();
        }

        //FIN

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Eq_Click();
            lblDisplay.Text = engine.Display();
        }

        //FIN

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Dot_Click();
            lblDisplay.Text = engine.Display();
        }

        //FIN

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Sing_Click();
            lblDisplay.Text = engine.Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        //FIN
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Back_Click();
            lblDisplay.Text = engine.Display();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }
    }

}


