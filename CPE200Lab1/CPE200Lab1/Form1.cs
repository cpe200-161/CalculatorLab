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
        private string numOperand = null;
        private float total = 0;
        private float Num = 0;
        private char status;
        private char percent;
        bool flag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                if (btn.Text == ".")
                {
                    if (!lblDisplay.Text.Contains("."))
                        lblDisplay.Text = lblDisplay.Text + btn.Text;
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + btn.Text;
                }    
            }  
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            numOperand = lblDisplay.Text;
            Num = float.Parse(numOperand);
            lblDisplay.Text = "";
            total = Num + total;
            status = '1';
            percent = '1';
            flag = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (status)
            {
                case '1':
                    total = Num + float.Parse(lblDisplay.Text);
                    lblDisplay.Text = "" + total ;
                    break;

                case '2':
                    total = Num - float.Parse(lblDisplay.Text);
                    lblDisplay.Text = "" + total;
                    break;

                case '3':
                    total = Num * float.Parse(lblDisplay.Text);
                    lblDisplay.Text = "" + total;
                    break;

                case '4':
                    total = Num / float.Parse(lblDisplay.Text);
                    lblDisplay.Text = "" + total;
                    break;

                case '5':
                    lblDisplay.Text = "" + total;
                    break;
            }
            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            numOperand = lblDisplay.Text;
            Num = float.Parse(numOperand);
            lblDisplay.Text = "";
            total = Num - total;
            status = '2';
            percent = '2';
            flag = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            numOperand = lblDisplay.Text;
            Num = float.Parse(numOperand);
            lblDisplay.Text = "";
            total = Num;
            status = '3';
            percent = '3';
            flag = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            numOperand = lblDisplay.Text;
            Num = float.Parse(numOperand);
            lblDisplay.Text = "";
            total = Num;
            status = '4';
            percent = '4';
            flag = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            numOperand = lblDisplay.Text;
            Num = float.Parse(numOperand);
            if (flag == true)
            {
                switch (percent)
                {

                    case '1':
                        total = total + ((total * Num) / 100);
                        break;

                    case '2':
                        total = total - ((total * Num) / 100);
                        break;

                    case '3':
                        total = (total * Num) / 100;
                        break;

                    case '4':
                        total = (total * (100 / Num)) ;
                        break;       
                }
            }
            else
            {
                total = Num /100;
            }
            
            status = '5';
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            total = 0;
            Num = 0;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            numOperand = lblDisplay.Text;
            Num = float.Parse(numOperand) * -1 ;
            string text = Convert.ToString(Num);
            lblDisplay.Text = text;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
            }
            if (lblDisplay.Text == "")
            {
                lblDisplay.Text = "0";
            }
        }
    }
}
