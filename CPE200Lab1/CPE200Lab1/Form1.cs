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
        bool checkset = false;
        bool checkplus = false;
        bool checkminus = false;
        bool checkmulti = false;
        bool checkdivide = false;
        bool checkper = false;

        void check (string x)
        {
            if( x == "+")
            {
                checkplus = true;
                checkminus = false;
                checkmulti = false;
                checkdivide = false;
                checkper = false;
            }
           else if (x == "-")
            {
                checkminus = true;
                checkplus = false;
                checkmulti = false;
                checkdivide = false;
                checkper = false;
            }
            else if (x == "*")
            {
                checkmulti = true;
                checkminus = false;
                checkplus = false;
                checkdivide = false;
                checkper = false;
            }
            else if (x == "/")
            {
                checkdivide = true;
                checkminus = false;
                checkmulti = false;
                checkplus = false;
                checkper = false;
            }
            else if (x == "%")
            {
                checkper = true;
                checkminus = false;
                checkmulti = false;
                checkdivide = false;
                checkplus = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (checkset)
            {
                lblDisplay.Text = "";
                checkset = false;
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }  
        }

         private void btnDot_Click(object sender, EventArgs e)
        {
            if (checkset)
            {
                lblDisplay.Text = "";
                checkset = false;
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }
        }

        private void btnplus_Click(object sender, EventArgs e)
        {
            if (firstSet == null)
            {
                firstSet = lblDisplay.Text;
                checkset = true;
            }
            else
            {
                
                    secondSet = lblDisplay.Text;
                    if (checkplus == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) + float.Parse(secondSet)).ToString();
                    }
                    if (checkminus == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) - float.Parse(secondSet)).ToString();
                    }
                    if (checkmulti == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) * float.Parse(secondSet)).ToString();
                    }
                    if (checkdivide == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) / float.Parse(secondSet)).ToString();
                    }
                    firstSet = lblDisplay.Text;
                    checkset = true;
                
            }
            check("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (firstSet == null)
            {
                firstSet = lblDisplay.Text;
                checkset = true;
            }
            else
            {
                
                    secondSet = lblDisplay.Text;
                    if (checkplus == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) + float.Parse(secondSet)).ToString();
                    }
                    if (checkminus == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) - float.Parse(secondSet)).ToString();
                    }
                    if (checkmulti == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) * float.Parse(secondSet)).ToString();
                    }
                    if (checkdivide == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) / float.Parse(secondSet)).ToString();
                    }
                    firstSet = lblDisplay.Text;
                    checkset = true;
                
            }
            check("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (firstSet == null)
            {
                firstSet = lblDisplay.Text;
                checkset = true;
            }
            else
            {
                
                    secondSet = lblDisplay.Text;
                    if (checkplus == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) + float.Parse(secondSet)).ToString();
                    }
                    if (checkminus == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) - float.Parse(secondSet)).ToString();
                    }
                    if (checkmulti == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) * float.Parse(secondSet)).ToString();
                    }
                    if (checkdivide == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) / float.Parse(secondSet)).ToString();
                    }
                    firstSet = lblDisplay.Text;
                    checkset = true;
                
            }
            check("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (firstSet == null)
            {
                firstSet = lblDisplay.Text;
                checkset = true;
            }
            else
            {
                
                    secondSet = lblDisplay.Text;
                    if (checkplus == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) + float.Parse(secondSet)).ToString();
                    }
                    if (checkminus == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) - float.Parse(secondSet)).ToString();
                    }
                    if (checkmulti == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) * float.Parse(secondSet)).ToString();
                    }
                    if (checkdivide == true)
                    {
                        lblDisplay.Text = (float.Parse(firstSet) / float.Parse(secondSet)).ToString();
                    }
                    firstSet = lblDisplay.Text;
                    checkset = true;
                
            }
            check("/");
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
                percent= (float.Parse(firstSet) + float.Parse(secondSet)).ToString();
                secondSet = percent;

            }
            check("%");
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            firstSet = null;
            secondSet = null;
            checkset = false;
            lblDisplay.Text = "0";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondSet = lblDisplay.Text;
            if (checkplus == true)
            {
                lblDisplay.Text = (float.Parse(firstSet) + float.Parse(secondSet)).ToString();
            }
           if (checkminus == true)
            {
                lblDisplay.Text = (float.Parse(firstSet) - float.Parse(secondSet)).ToString();
            }
           if (checkmulti == true)
            {
                lblDisplay.Text = (float.Parse(firstSet) * float.Parse(secondSet)).ToString();
            }
           if (checkdivide == true)
            {
                lblDisplay.Text = (float.Parse(firstSet) / float.Parse(secondSet)).ToString();
            }
           if (checkper == true)
            {
                lblDisplay.Text = percent;  
            }
        }
    }
}