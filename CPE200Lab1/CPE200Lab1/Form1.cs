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
        string fp = null;
        string Op = "";
        float setFp = 0;
        float setSp = 0;
        bool openSp = false;
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
            Op = a.Text;
            fp = lblDisplay.Text;
            setFp = float.Parse(fp);
            openSp = true;
            if(Op == "±")
            {
                lblDisplay.Text = "";
                lblDisplay.Text = (setFp * (-1)).ToString();
            }
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            setSp = float.Parse(lblDisplay.Text);
            switch (Op)
            {
                case "+":
                    lblDisplay.Text = "";
                    lblDisplay.Text = (setFp + setSp).ToString();
                break;

                case "-":
                    lblDisplay.Text = "";
                    lblDisplay.Text = (setFp - setSp).ToString();
                break;

                case "X":
                    lblDisplay.Text = "";
                    lblDisplay.Text = (setFp * setSp).ToString();
                break;

                case "÷":
                    lblDisplay.Text = "";
                    lblDisplay.Text = (setFp / setSp).ToString();
                break;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            fp = null;
            setFp = 0;
            setSp = 0;
            Op = "";
            openSp = false;
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
                    lblDisplay.Text = lblDisplay.Text.Remove(clear1 - 1);
                else
                    lblDisplay.Text = "0";
            }
        }
        private void btnPerCent_Click(object sender, EventArgs e)
        {
            float perC = 0;
            perC = float.Parse(lblDisplay.Text);
            lblDisplay.Text = ((setFp * perC) / 100).ToString();
        }
    }
}
