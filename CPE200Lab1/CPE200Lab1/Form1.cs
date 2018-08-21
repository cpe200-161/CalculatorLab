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
        string firstOp = null;
        string secondOp = null;
        string total = null;
        bool checkFirst = false;
        bool plus = false;
        bool minus = false;
        bool multiply = false;
        bool divide = false;
        bool eqCheck = false;
        bool percent = false;
        bool number = false;
    
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            firstOp = null;
            secondOp = null;
            plus = false;
            minus = false;
            multiply = false;
            divide = false;
            eqCheck = false;
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn  = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            else if (checkFirst)
            {
                lblDisplay.Text = "";
                checkFirst = false;
            }
            if (eqCheck)
            {
                lblDisplay.Text = "";
                firstOp = null;
                secondOp = null;
                eqCheck = false;
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
               
            }
             number = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "0";
            }
            else if (checkFirst)
            {
                lblDisplay.Text = "";
                checkFirst = false;
            }
            if (eqCheck)
            {
                firstOp = null;
                secondOp = null;
                eqCheck = false;
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += ".";
            }
            number = true;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Calculator();
            minus = false;
            divide = false;
            plus = true;
            multiply = false;
            eqCheck = false;
            percent = false;

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Calculator();
            minus = true;
            divide = false;
            plus = false;
            multiply = false;
            eqCheck = false;
            percent = false;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            Calculator();
            multiply = true;
            divide = false;
            plus = false;
            minus = false;
            eqCheck = false;
            percent = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Calculator();
            divide = true;
            plus = false;
            minus = false;
            multiply = false;
            eqCheck = false;
            percent = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Calculate();
            firstOp = total;
            lblDisplay.Text = total;
            eqCheck = true;
            divide = false;
            multiply = false;
            plus = false;
            minus = false;
            percent = false;
            number = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (firstOp==null)
            {
                firstOp = lblDisplay.Text;
                total = (float.Parse(firstOp) / 100).ToString();
                firstOp = total;
            }
            else
            {
                secondOp = lblDisplay.Text;
                if (plus)
                {
                    total = ((float.Parse(firstOp) + (float.Parse(secondOp) * (float.Parse(firstOp) / 100.0)))).ToString();
                }else if (minus)
                {
                    total = ((float.Parse(firstOp) - (float.Parse(secondOp) * (float.Parse(firstOp) / 100.0)))).ToString();
                }else if (multiply)
                {
                    total = ((float.Parse(firstOp) * (float.Parse(secondOp) * (float.Parse(firstOp) / 100.0)))).ToString();
                }else if (divide)
                {
                    total = ((float.Parse(firstOp) / (float.Parse(secondOp) * (float.Parse(firstOp) / 100.0)))).ToString();
                }
            }
            firstOp = total;
            percent = true;
            minus = false;
            plus = false;
            multiply = false;
            divide = false;
            number = false;
        }

        private void Calculator()
                {
                    if (firstOp == null)
                    {
                        firstOp = lblDisplay.Text;
                    }
                    else if (number)
                    {
                        if (eqCheck == false)
                        {
                            Calculate;
                            firstOp = total;
                            lblDisplay.Text = firstOp;
                        }
                        else
                        {
                            lblDisplay.Text = firstOp;
                        }
                    }
                    number = false;
                    checkFirst = true;
                }

        private void Calculate()
                {
                    if (percent == false)
                    {
                        secondOp = lblDisplay.Text;
                    }
                    if (plus)
                    {
                        total = (float.Parse(firstOp) + float.Parse(secondOp)).ToString();
                    }
                    else if (minus)
                    {
                        total = (float.Parse(firstOp) - float.Parse(secondOp)).ToString();
                    }
                    else if (multiply)
                    {
                        total = (float.Parse(firstOp) * float.Parse(secondOp)).ToString();
                    }
                    else if (divide)
                    {
                        total = (float.Parse(firstOp) / float.Parse(secondOp)).ToString();
                    }
                }
    }
}
