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
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private CalculatorEngine engine;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
        }

        private bool isOperator(char ch)        //OK
        {
            return engine.isOperator2(ch.ToString());
        }

        private void btnNumber_Click(object sender, EventArgs e) //OK
        {
            String Butt = ((Button)sender).Text;
            engine.btnNumber_Click2(Butt);
            lblDisplay.Text = engine.Display();
        }

        private void btnBinaryOperator_Click(object sender, EventArgs e) //OK
        {
            String Butt2 = ((Button)sender).Text;
            engine.btnBinaryOperator_Click2(Butt2);
            lblDisplay.Text = engine.Display();
        }

        private void btnBack_Click(object sender, EventArgs e) //OK
        {
            engine.btnBack_Click2();
            lblDisplay.Text = engine.Display();
        }

        private void btnClear_Click(object sender, EventArgs e) //OK
        {
            engine.btnClear_Click2();
            lblDisplay.Text = engine.Display();
        }

        private void btnEqual_Click(object sender, EventArgs e) //OK
        {
            string result = engine.Process(lblDisplay.Text);
            engine.btnEqual_Click2(result);
            lblDisplay.Text = engine.Display();
        }


        private void btnSign_Click(object sender, EventArgs e) //OK
        {
            engine.btnSign_Click2();
            lblDisplay.Text = engine.Display();
        }

        private void btnDot_Click(object sender, EventArgs e) //OK
        {
            engine.btnDot_Click2();
            lblDisplay.Text = engine.Display();
        }

        private void btnSpace_Click(object sender, EventArgs e) //OK
        {
            engine.btnSpace_Click2();
            lblDisplay.Text = engine.Display();
        }
    }
}
