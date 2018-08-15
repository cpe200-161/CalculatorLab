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
        public Form1()
        {
            InitializeComponent();
        }

        //add Eq
        float eq1, eq2, resultshow, resultstore;
        Boolean Dotflage = true, operatorflage = true, plusflage = false, minusflage = false, multiplyflage = false, divideflage = false;

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text)/ 10).ToString();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblDisplay.Text = (-1 * float.Parse(lblDisplay.Text)).ToString();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            //this %
            resultstore = (eq1 * eq2) / 100;
            eq2 = resultstore;
        }

        private void btnoperator_Click(object sender, EventArgs e)
        {
            eq1 = float.Parse(lblDisplay.Text);
            lblDisplay.Text = "";
            Button btn = (Button)sender;

            if (operatorflage)
            {
                if (btn.Text == "+")
                {   
                    plusflage = true;
                } else if (btn.Text == "-")
                {
                    minusflage = true;
                } else if (btn.Text == "X")
                {
                    multiplyflage = true;
                } else if (btn.Text == "÷")
                {
                    divideflage = true;
                }

                operatorflage = false;
            }
            
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            //this =
            eq2 = float.Parse(lblDisplay.Text);
            lblDisplay.Text = "";
            if (plusflage)
            {
                resultshow = eq1 + eq2;
            }else if (minusflage)
            {
                resultshow = eq1 - eq2;
            }else if (multiplyflage)
            {
                resultshow = eq1 * eq2;
            }else if (divideflage)
            {
                resultshow = eq1 / eq2;
            }

            eq1 = resultshow;
            lblDisplay.Text = resultshow.ToString();
            Dotflage = operatorflage = true;
            plusflage = minusflage = multiplyflage = divideflage = false;

        }

        private void bntDot_Click(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            if (Dotflage)
            {
                lblDisplay.Text += btn.Text;
                Dotflage = false;
            }
        }

        private void btnnum_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            eq1 = eq2 = resultshow = resultstore = 0;
            Dotflage = operatorflage = true;
            plusflage = minusflage = multiplyflage = divideflage = false;
        }
    }
}
