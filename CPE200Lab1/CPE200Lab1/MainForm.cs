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

        private string operate;
        private CalculatorEngine engine= new CalculatorEngine();

        private void resetAll()
        {
            engine.reset_all();
            lblDisplay.Text = engine.display;

        }

        
               

        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            
            
            string digit = ((Button)sender).Text;
            engine.handleDigit(digit);
            lblDisplay.Text = engine.display;
        }

       

        private void btnOperator_Click(object sender, EventArgs e)
        {


            operate = ((Button)sender).Text;
            engine.handleOperetor(operate);
            lblDisplay.Text = engine.display;
        }


        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.equal();
            lblDisplay.Text = engine.display;
        }

        

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
           
                engine.dot();
                lblDisplay.Text = engine.display;
        }

        

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }

            engine.sign();
            lblDisplay.Text = engine.display;
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
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            engine.backSpace();
            lblDisplay.Text = engine.display;
        }

       
    }
}
