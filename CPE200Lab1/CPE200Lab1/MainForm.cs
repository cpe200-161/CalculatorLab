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
        private calculatorengine engine = new calculatorengine();
        private void resetAll()
        {
           engine.resetAll();
            lblDisplay.Text =engine.Display();         
        }

        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            
            
            string digit = ((Button)sender).Text;
            engine.numBer_click(digit);
            lblDisplay.Text = engine.Display();

        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            
           string selectedOperator = ((Button)sender).Text;
            engine.opare(selectedOperator);
            lblDisplay.Text = engine.Display();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error") { return;}
            engine.Equals();
            lblDisplay.Text = engine.Display();

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
          
           engine. handleSign();
            lblDisplay.Text = engine.Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
            //lblDisplay.Text = "0";
        }

       private void btnBack_Click(object sender, EventArgs e)
        {            
           engine.back_click();
            lblDisplay.Text = engine.Display();
        }
       
        private void btndot_Click(object sender, EventArgs e)
        {          
            engine.Dot_Click();
            lblDisplay.Text = engine.Display();
        }
    }
}
