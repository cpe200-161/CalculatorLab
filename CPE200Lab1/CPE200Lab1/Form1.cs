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
        double N1 = 0;
        double N2 = 0;
        double Forwhat;
        bool haveN1= false;
        bool finishyet = false;
        bool havedot = false;
        double N3;
        string Operator ="";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if(haveN1 == true)
            {
                lblDisplay.Text = "";
                haveN1 = false;
            }
            if(lblDisplay.Text == "0" || finishyet == true)
            {
                lblDisplay.Text = "";
                finishyet = false;
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(Operator != "0")
            {
                N2 = Convert.ToDouble(lblDisplay.Text);
                if (Operator == "+")
                {
                    lblDisplay.Text = Convert.ToString(N1 + N2);
                }
                if (Operator == "-")
                {
                    lblDisplay.Text = Convert.ToString(N1 - N2);
                }
                if (Operator == "X")
                {
                    lblDisplay.Text = Convert.ToString(N1 * N2);
                }
                if (Operator == "÷")
                {
                    lblDisplay.Text = Convert.ToString(N1 / N2);
                }
            }
            N1 = double.Parse(lblDisplay.Text);
            haveN1 = true;
            havedot = false;
            Operator = (btn.Text);

        }
       

        private void btnEqual_Click(object sender, EventArgs e)
        {
            N2 = Convert.ToDouble(lblDisplay.Text);
            if(Operator == "+")
            {
                lblDisplay.Text = Convert.ToString(N1 + N2);
            }
            if (Operator == "-")
            {
                lblDisplay.Text = Convert.ToString(N1 - N2);
            }
            if (Operator == "X")
            {
                lblDisplay.Text = Convert.ToString(N1 * N2);
            }
            if (Operator == "÷")
            {
                lblDisplay.Text = Convert.ToString(N1 / N2);
            }
            finishyet = true;
            havedot = false;
            Operator = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            N1 = 0;
            N2 = 0;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(havedot != true)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
                havedot = true;
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            
            if (Operator == "+" || Operator =="-")
            {
                N2 = Convert.ToDouble(lblDisplay.Text);
                Forwhat = (N1 * N2) / 100;
                lblDisplay.Text = Convert.ToString(Forwhat);
                finishyet = true;
                N1 = 0;
                N2 = 0;
                Operator = "";
                
            }
            else Forwhat = Convert.ToDouble(lblDisplay.Text) / 100;
                 lblDisplay.Text = Convert.ToString(Forwhat);
        }
    }
}
