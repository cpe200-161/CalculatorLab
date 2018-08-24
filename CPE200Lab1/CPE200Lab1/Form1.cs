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
        double Num_first = 0;
        double Num_second = 0;
        int SOL = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public void Calculate()
        {
            switch (SOL)
            {
                case 1:
                    Num_second = double.Parse(lblDisplay.Text);
                    Num_first = Num_second + Num_first;
                    lblDisplay.Text = string.Format("{0:G}", Num_first);
                    break;
                case 2:
                    Num_second = double.Parse(lblDisplay.Text);
                    Num_first = Num_second - Num_first;
                    lblDisplay.Text = string.Format("{0:G}", Num_first);
                    break;
                case 3:
                    Num_second = double.Parse(lblDisplay.Text);
                    Num_first = Num_second * Num_first;
                    lblDisplay.Text = string.Format("{0:G}", Num_first);
                    break;
                case 4:
                    Num_second = double.Parse(lblDisplay.Text);
                    Num_first = Num_second / Num_first;
                    lblDisplay.Text = string.Format("{0:G}", Num_first);
                    break;
                default:
                    lblDisplay.Text = lblDisplay.Text;
                    break;
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == string.Format("{0:G}", Num_first))
            {
                lblDisplay.Text = "";
            }
            if(lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Num_first = 0;
            Num_second = 0;
            SOL = 0;
            lblDisplay.Text = "0";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Num_first = double.Parse(lblDisplay.Text);
            Calculate();
            SOL = 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Num_first = double.Parse(lblDisplay.Text);
            Calculate();
            SOL = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (Num_first == 0)
            {
                Num_first = 1;
            }
            Num_first = double.Parse(lblDisplay.Text);
            Calculate();
            SOL = 3;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (Num_first == 0)
            {
                Num_first = 1;
            }
            Num_first = double.Parse(lblDisplay.Text);
            Calculate();
            SOL = 4;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch(SOL){
                case 1:
                    Num_second = double.Parse(lblDisplay.Text);
                    Num_first = Num_second + Num_first;
                    lblDisplay.Text = string.Format("{0:G}", Num_first);
                    break;
                case 2:
                    Num_second = double.Parse(lblDisplay.Text);
                    Num_first = Num_second - Num_first;
                    lblDisplay.Text = string.Format("{0:G}", Num_first);
                    break;
                case 3:
                    Num_second = double.Parse(lblDisplay.Text);
                    Num_first = Num_second*Num_first;
                    lblDisplay.Text = string.Format("{0:G}", Num_first);
                    break;
                case 4:
                    Num_second = double.Parse(lblDisplay.Text);
                    Num_first = Num_second / Num_first;
                    lblDisplay.Text = string.Format("{0:G}", Num_first);
                    break;
                default:
                    lblDisplay.Text = lblDisplay.Text;
                    break;
            }
        }

        
    }
}
