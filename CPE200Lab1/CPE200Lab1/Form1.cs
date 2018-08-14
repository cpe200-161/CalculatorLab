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
        string SecondOperand = null;
        private string firstOperand;
        bool setFirstOperand = false;
        bool isStartSecondOperand = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0") { lblDisplay.Text = ""; }
            if(setFirstOperand ==true && isStartSecondOperand == false)
            {
                lblDisplay.Text = "";
                isStartSecondOperand = true;
            }
            if(lblDisplay.Text.Length < 8)
            lblDisplay.Text += btn.Text ;
            
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            setFirstOperand = true;
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result;
            SecondOperand = lblDisplay.Text;
            result = (float.Parse(firstOperand) + float.Parse(SecondOperand)).ToString();
            lblDisplay.Text = result;
        }

    }
}
