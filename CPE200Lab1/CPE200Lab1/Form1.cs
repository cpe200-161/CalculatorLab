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
        string operate = "",num1="",num2="";
        float temp;
        bool cK_show = false,ck_preset = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            operate = "";
            num1 = "";
            num2 = "";
            lblDisplay.Text = 0 + "";
            cK_show = false;
            ck_preset = false;

            btn0.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btnBack.Enabled = true;
            btnClear.Enabled = true;
            btnDivide.Enabled = true;
            btnDot.Enabled = true;
            btnEqual.Enabled = true;
            btnMinus.Enabled = true;
            btnMultiply.Enabled = true;
            btnPercent.Enabled = true;
            btnPlus.Enabled = true;
            btnSign.Enabled = true;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if(float.Parse(lblDisplay.Text)>0)
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
            else if(float.Parse(lblDisplay.Text) < 0)
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (cK_show == false)
            {
                if (lblDisplay.Text.Length == 1)
                {
                    lblDisplay.Text = "0";
                }
                else if (lblDisplay.Text.Length > 1)
                {
                    lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
                }
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" || cK_show == true)
                {
                    lblDisplay.Text = btn.Text;
                }
                else
                {
                    lblDisplay.Text += btn.Text;
                }
                cK_show = false;
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.IndexOf(".") <= 0)
            {
                lblDisplay.Text += ".";
            }
        }

        private void btnOpe_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            fun_get_num();
            if (ck_preset==true)
            {
                num1 = num2;
                num2 = "";
                ck_preset = false;
            }

            if(operate!="" && num1 != "" && num2 != "" && cK_show == false)
            {
                fun_operate(float.Parse(num1), float.Parse(num2));
                temp = float.Parse(num2);
                num2 = "";
                cK_show = true;
            }
            if (operate != btn.Text) { num2 = ""; }
            operate = btn.Text; 

            if (cK_show == false) { lblDisplay.Text = "0"; }
            //MessageBox.Show(num1 + operate + num2);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            fun_get_num();
            if (num2 != "")
            {
                fun_operate(float.Parse(num1),float.Parse(num2));
                //MessageBox.Show(num1 + operate + num2);
                cK_show = true;
            }
            else if(num2 =="")
            {
                fun_operate(float.Parse(num1),temp);
                //MessageBox.Show(num1 + operate + temp);
            }
            
        }

        private void fun_operate(float n1, float n2)
        {
            if (operate == "+") { num1 = (n1 + n2).ToString(); }
            else if (operate == "-") { num1 = (n1 - n2).ToString(); }
            else if (operate == "X") { num1 =(n1 * n2).ToString(); }
            else if (operate == "÷") { num1 = (n1 / n2).ToString(); }
            show_text();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            fun_get_num();
            if (num2 == "")
            {
                lblDisplay.Text = "0";
                num1 = "";
            }
            else if (num2 != "")
            {
                string temp_2 = num1;
                num1 =  ((double.Parse(num1) / 100) * double.Parse(num2)).ToString();
                temp = float.Parse(num2);
                show_text();
                num1 = temp_2;
                num2 = "";
                cK_show = true;
                ck_preset = true;
            }
        }

        private void show_text()
        {
            lblDisplay.Text = num1;

            if (num1 == "NaN" || num1 == "∞")
            {
                num1 = "0";
                btn0.Enabled = false;
                btn1.Enabled = false;
                btn2.Enabled = false;
                btn3.Enabled = false;
                btn4.Enabled = false;
                btn5.Enabled = false;
                btn6.Enabled = false;
                btn7.Enabled = false;
                btn8.Enabled = false;
                btn9.Enabled = false;
                btnBack.Enabled = false;
                btnClear.Enabled = true;
                btnDivide.Enabled = false;
                btnDot.Enabled = false;
                btnEqual.Enabled = false;
                btnMinus.Enabled = false;
                btnMultiply.Enabled = false;
                btnPercent.Enabled = false;
                btnPlus.Enabled = false;
                btnSign.Enabled = false;
            }
        }

        private void fun_get_num()
        {
            if (num1 == "")
            {
                num1 = lblDisplay.Text;
            }
            else if (num2 == "")
            {
                num2 = lblDisplay.Text;
            }
        }
    }
}