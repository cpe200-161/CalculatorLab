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
        float setFp = 0;
        float setSp = 0;
        int perCent = 0;
        string oper = "";
        int spot = 0;
        bool openSp = false;
        string firstOperand = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" && openSp != true)
                {
                    lblDisplay.Text = "";
                }
                lblDisplay.Text = lblDisplay.Text + b.Text;

                if (openSp == true)
                {
                    lblDisplay.Text = "";
                    lblDisplay.Text = lblDisplay.Text + b.Text;
                    openSp = false;
                }
            }
        }
        private void btnOp_Click(object sender, EventArgs e)
        {
            Button a = (Button)sender;
            oper = a.Text;
            firstOperand = lblDisplay.Text;
            setFp = float.Parse(firstOperand);
            openSp = true;
            spot = 0;
            if (oper == "±")
            {
                lblDisplay.Text = "";
                lblDisplay.Text = (setFp * (-1)).ToString();
            }
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            setSp = float.Parse(lblDisplay.Text);
            switch (oper)
            {
                case "+":
                    lblDisplay.Text = "";
                    lblDisplay.Text = (setFp + setSp).ToString();
                    perCent = 0;
                    break;

                case "-":
                    lblDisplay.Text = "";
                    lblDisplay.Text = (setFp - setSp).ToString();
                    perCent = 0;
                    break;

                case "X":
                    lblDisplay.Text = "";
                    lblDisplay.Text = (setFp * setSp).ToString();
                    perCent = 0;
                    break;

                case "÷":
                    lblDisplay.Text = "";
                    lblDisplay.Text = (setFp / setSp).ToString();
                    perCent = 0;
                    break;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            spot = 0;
            setFp = 0;
            setSp = 0;
            oper = "";
            openSp = false;
            firstOperand = null;
            lblDisplay.Text = "0";
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            int clear1 = lblDisplay.Text.Length;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "0";
            }
            else
            {
                if (clear1 != 1)
                {
                    lblDisplay.Text = lblDisplay.Text.Remove(clear1 - 1);
                }
                else
                {
                    lblDisplay.Text = "0";
                }
            }
        }
        private void btnPerCent_Click(object sender, EventArgs e)
        {
            if (perCent == 0)
            {
                float perC = 0;
                perC = float.Parse(lblDisplay.Text);
                lblDisplay.Text = ((setFp * perC) / 100).ToString();
            }
            perCent++;
        }

        private void btnspot_Click(object sender, EventArgs e)
        {
            if(spot < 1)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
                spot++;
            }
        }
    }
}
