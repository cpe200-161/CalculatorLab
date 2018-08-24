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
        private string firstOperand = null;
        private string secondOperand = null;
        private string result;
        bool first_operand = false;
        bool second_operand = false;
        bool plus_click = false;
        bool minus_click = false;
        bool multiply_click = false;
        bool divide_click = false;
        
        double FO = 0;
        double SO = 0;

        


        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (first_operand == true && second_operand == false)
            {
                lblDisplay.Text = "";
                second_operand = true;
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
            

        }

        private void Plus_calculate()
        {
            secondOperand = lblDisplay.Text;
            FO = Convert.ToDouble(firstOperand);
            SO = Convert.ToDouble(secondOperand);
            result = (FO + SO).ToString();
            second_operand = false;

        }
        
        private void Minus_calculate()
        {

            secondOperand = lblDisplay.Text;
            FO = Convert.ToDouble(firstOperand);
            SO = Convert.ToDouble(secondOperand);
            result = (FO - SO).ToString();
            second_operand = false;
        }

        private void Multiply_calculate()
        {
            secondOperand = lblDisplay.Text;
            FO = Convert.ToDouble(firstOperand);
            SO = Convert.ToDouble(secondOperand);
            result = (FO * SO).ToString();
            second_operand = false;
        }

        private void Divide_calculate()
        {
            secondOperand = lblDisplay.Text;
            FO = Convert.ToDouble(firstOperand);
            SO = Convert.ToDouble(secondOperand);
            result = (FO / SO).ToString();
            second_operand = false;
        }

        private void Percent_calculate()
        {
            secondOperand = lblDisplay.Text;
            FO = Convert.ToDouble(firstOperand);
            SO = Convert.ToDouble(secondOperand);
            if (lblDisplay.Text != "" || multiply_click == true || divide_click == true)
             {
                lblDisplay.Text =  (SO * 0.01).ToString();
             }
             else if(plus_click == true || minus_click == true)
             {
                lblDisplay.Text = (FO * (SO * 0.01)) .ToString();
             }
            second_operand = false;
            secondOperand = lblDisplay.Text;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            first_operand = false;
            second_operand = false;
            plus_click = false;
            minus_click = false;
            multiply_click = false;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {   
            firstOperand = lblDisplay.Text;
            first_operand = true;
            plus_click = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (plus_click)
            {
                Plus_calculate();
                plus_click = false;
            }
            if (minus_click)
            {
                Minus_calculate();
                minus_click = false;
            }
            if (multiply_click)
            {
                Multiply_calculate();
                multiply_click = false;
            }
            if (divide_click)
            {
                Divide_calculate();
                divide_click = false;
            }
            

            lblDisplay.Text = result;
            
            firstOperand = lblDisplay.Text;



        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            first_operand = true;
            minus_click = true;

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            first_operand = true;
            multiply_click = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text += ".";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            first_operand = true;
            divide_click = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            if (lblDisplay.Text.Length == 0)
            {
                lblDisplay.Text = "";
            }

        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            
            first_operand = true;
            
            Percent_calculate();


        }
    }
}
