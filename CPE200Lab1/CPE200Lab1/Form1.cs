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
    public partial class Form1 : Form
    {
        string firstOperand = null;
        string secandOperand = null;
        bool setfirstOperand = false;
        bool setsecandOperand = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            setfirstOperand = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result;
            secandOperand = lblDisplay.Text;
            result = (float.Parse(firstOperand) + float.Parse(secandOperand)).ToString();
            lblDisplay.Text = result;

        }
    }
}
