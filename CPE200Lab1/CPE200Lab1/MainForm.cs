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
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        CalculatorEngine engine = new CalculatorEngine();

        private void resetAll()
        {
            engine.resetAll2();
            lblDisplay.Text = engine.Display();
        }

        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e) // OK
        {
           string digit = ((Button)sender).Text;
           engine.btnNumber_Click2(digit);
           lblDisplay.Text = engine.Display();
        }

        private void btnOperator_Click(object sender, EventArgs e) //OK
        {
            string oper = ((Button)sender).Text;
            engine.btnOperator_Click2(oper);
            lblDisplay.Text = engine.Display();
        }

        private void btnEqual_Click(object sender, EventArgs e) //OK
        {
            engine.btnEqual_Click2();
            lblDisplay.Text = engine.Display();
        }

        private void btnDot_Click(object sender, EventArgs e) //OK
        {
            engine.btnDot_Click2();
            lblDisplay.Text = engine.Display();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            engine.btnSign_Click2();
            lblDisplay.Text = engine.Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            engine.resetAll2();
            lblDisplay.Text = engine.Display();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            engine.btnBack_Click2();
            lblDisplay.Text = engine.Display();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
