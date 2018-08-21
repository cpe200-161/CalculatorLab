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
        string firstSet = null;
        string secondSet = null;
        string percent = null;
        bool checkSet = false;
        bool checkPlus = false;
        bool checkMinus = false;
        bool checkMultiply = false;
        bool checkDivide = false;
        bool checkPercent = false;
        bool checkEqual = false;
        bool checkNumber = false;


        void checkall ( )
        {
            if (checkNumber)
            {
                if (checkPlus)
                {
                    lblDisplay.Text = (float.Parse(firstSet) + float.Parse(secondSet)).ToString();
                }
                else if (checkMinus)
                {
                    lblDisplay.Text = (float.Parse(firstSet) - float.Parse(secondSet)).ToString();
                }
                else if (checkMultiply)
                {
                    lblDisplay.Text = (float.Parse(firstSet) * float.Parse(secondSet)).ToString();
                }
                else if (checkDivide)
                {
                    lblDisplay.Text = (float.Parse(firstSet) / float.Parse(secondSet)).ToString();
                }
                else if (checkPercent)
                {
                    lblDisplay.Text = percent;
                }
                firstSet = lblDisplay.Text;
            }
        }

        void check (string x)
        {
            if( x == "+")
            {
                checkPlus = true;
                checkMinus = false;
                checkMultiply = false;
                checkDivide = false;
                checkPercent = false;
            }
           else if (x == "-")
            {
                checkMinus = true;
                checkPlus = false;
                checkMultiply = false;
                checkDivide = false;
                checkPercent = false;
            }
            else if (x == "*")
            {
                checkMultiply = true;
                checkMinus = false;
                checkPlus = false;
                checkDivide = false;
                checkPercent = false;
            }
            else if (x == "/")
            {
                checkDivide = true;
                checkMinus = false;
                checkMultiply = false;
                checkPlus = false;
                checkPercent = false;
            }
            else if (x == "%")
            {
                checkPercent = true;
                checkMinus = false;
                checkMultiply = false;
                checkDivide = false;
                checkPlus = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(checkEqual)
            {
                lblDisplay.Text = "0";
                firstSet = null;
                secondSet = null;
                checkEqual = false;
            }
            if (checkSet)
            {
                lblDisplay.Text = "";
                checkSet = false;
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
            checkNumber = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (checkSet)
            {
                lblDisplay.Text = "";
                checkSet = false;
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "0";
            }

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            firstSet = null;
            secondSet = null;
            checkSet = false;
            lblDisplay.Text = "0";
        }

        private void btnplus_Click(object sender, EventArgs e)
        {
            if (firstSet == null)
            {
                firstSet = lblDisplay.Text;
                checkSet = true;
            }
            else
            {
                secondSet = lblDisplay.Text;
                checkall();
                firstSet = lblDisplay.Text;
                checkSet = true;
            }
            check("+");
            checkNumber = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (firstSet == null)
            {
                firstSet = lblDisplay.Text;
                checkSet = true;
            }
            else
            {
                secondSet = lblDisplay.Text;
                checkall();
                firstSet = lblDisplay.Text;
                checkSet = true;
            }
            check("-");
            checkNumber = false;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (firstSet == null)
            {
                firstSet = lblDisplay.Text;
                checkSet = true;
            }
            else
            {
                secondSet = lblDisplay.Text;
                checkall();
                firstSet = lblDisplay.Text;
                checkSet = true;
            }
            check("*");
            checkNumber = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (firstSet == null)
            {
                firstSet = lblDisplay.Text;
                checkSet = true;
            }
            else
            {
                secondSet = lblDisplay.Text;
                checkall();
                firstSet = lblDisplay.Text;
                checkSet = true;
            }
            check("/");
            checkNumber = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            
            if (firstSet == null)
            {
                percent = (float.Parse(lblDisplay.Text) / 100).ToString();
                firstSet = percent;
            }
            else
            {
                secondSet = (float.Parse(lblDisplay.Text) * float.Parse(firstSet) / 100).ToString();
                
                if (checkPlus)
                {
                    percent = (float.Parse(firstSet) + float.Parse(secondSet)).ToString();
                }
                if (checkMinus)
                {
                    percent = (float.Parse(firstSet) - float.Parse(secondSet)).ToString();
                }
                if (checkMultiply)
                {
                    percent = (float.Parse(firstSet) * (float.Parse(lblDisplay.Text) / 100)).ToString();
                }
                if (checkDivide)
                {
                    percent = (float.Parse(firstSet) / (float.Parse(lblDisplay.Text) / 100)).ToString();
                }
                secondSet = percent;
            }
            check("%");
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (firstSet == null)
            {
                firstSet = lblDisplay.Text;
                checkSet = true;
            }
            else
            {
                secondSet = lblDisplay.Text;
                checkall();
                firstSet = lblDisplay.Text;
                checkSet = true;
            }
            checkEqual = true;
            checkNumber = false;
        }
    }
}