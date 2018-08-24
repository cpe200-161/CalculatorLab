using System;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string num1;
        string num2 = "";
        float num3;

        int stage = 1;
        int stat = 0;
        int Plus = 0;
        int Minus = 0;
        int Multiply = 0;
        int Divide = 0;
        int d = 0;
        int operater = 1;
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";

            }
            if (stage == 2)
            {
                lblDisplay.Text = "";
                d = 0;
                stage = 1;
                stat = 0;
            }

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
                operater = 1;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            lblDisplay.Text = "0";
            num2 = "0";
            num1 = "0";
            stage = 1;
            stat = 0;
            Plus = 0;
            Minus = 0;
            Multiply = 0;
            Divide = 0;
            d = 0;


        }


        private void btnPlus_Click(object sender, EventArgs e)
        {

            if (operater == 1)
            {
                if (Plus == 1)
                {

                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) + float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Plus = 0;

                }
                else if (Minus == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) - float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Minus = 0;
                }
                else if (Multiply == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) * float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Multiply = 0;
                }
                else if (Divide == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) / float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Divide = 0;
                }

                num1 = lblDisplay.Text;
                Plus = 1;
                operater = 0;
            }
            stage = 2;





        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (operater == 1)
            {
                if (Plus == 1)
                {

                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) + float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Plus = 0;

                }
                else if (Minus == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) - float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Minus = 0;
                }
                else if (Multiply == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) * float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Multiply = 0;
                }
                else if (Divide == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) / float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Divide = 0;
                }


                num1 = lblDisplay.Text;
                stage = 2;
                operater = 0;
                Minus = 1;


            }
        }


        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (operater == 1)
            {
                if (Plus == 1)
                {

                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) + float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Plus = 0;

                }
                else if (Minus == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) - float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Minus = 0;
                }
                else if (Multiply == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) * float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Multiply = 0;
                }
                else if (Divide == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) / float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Divide = 0;
                }


                num1 = lblDisplay.Text;
                stage = 2;
                operater = 0;
                Multiply = 1;


            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (operater == 1)
            {
                if (Plus == 1)
                {

                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) + float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Plus = 0;

                }
                else if (Minus == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) - float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Minus = 0;
                }
                else if (Multiply == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) * float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Multiply = 0;
                }
                else if (Divide == 1)
                {
                    if (stat == 0) num2 = lblDisplay.Text;
                    num3 = float.Parse(num1) / float.Parse(num2);
                    num1 = Convert.ToString(num3);
                    lblDisplay.Text = num1;
                    stage = 0;
                    stat = 1;
                    Divide = 0;
                }


                num1 = lblDisplay.Text;
                stage = 2;
                operater = 0;
                Divide = 1;


            }
        }


        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (Plus == 1)
            {

                if (stat == 0) num2 = lblDisplay.Text;
                num3 = float.Parse(num1) + float.Parse(num2);
                num1 = Convert.ToString(num3);
                lblDisplay.Text = num1;
                stage = 1;
                stat = 1;
                //Plus = 0;

            }
            else if (Minus == 1)
            {
                if (stat == 0) num2 = lblDisplay.Text;
                num3 = float.Parse(num1) - float.Parse(num2);
                num1 = Convert.ToString(num3);
                lblDisplay.Text = num1;
                stage = 1;
                stat = 1;
                //Minus = 0;
            }
            else if (Multiply == 1)
            {
                if (stat == 0) num2 = lblDisplay.Text;
                num3 = float.Parse(num1) * float.Parse(num2);
                num1 = Convert.ToString(num3);
                lblDisplay.Text = num1;
                stage = 1;
                stat = 1;
                //Multiply = 0;
            }
            else if (Divide == 1)
            {
                if (stat == 0) num2 = lblDisplay.Text;
                num3 = float.Parse(num1) / float.Parse(num2);
                num1 = Convert.ToString(num3);
                lblDisplay.Text = num1;
                stage = 1;
                stat = 1;
                //Divide = 0;
            }

        }

        private void btnDot_Click(object sender, EventArgs e)
        {

            if (d == 0)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
                d = 1;
            }

        }

        private void btnPercent_Click(object sender, EventArgs e)
        {

            if (Plus == 1)
            {

                if (stat == 0) num2 = lblDisplay.Text;
                num2 = Convert.ToString(float.Parse(num1) * float.Parse(num2) / 100);
                lblDisplay.Text = num2;
                stage = 1;
                stat = 1;

            }
            else if (Minus == 1)
            {
                if (stat == 0) num2 = lblDisplay.Text;
                num2 = Convert.ToString(float.Parse(num1) * float.Parse(num2) / 100);
                lblDisplay.Text = num2;
                stage = 1;
                stat = 1;
            }
            else if (Multiply == 1)
            {
                if (stat == 0) num2 = lblDisplay.Text;
                num2 = Convert.ToString(float.Parse(num2) / 100);
                lblDisplay.Text = num2;
                stage = 1;
                stat = 1;
            }
            else if (Divide == 1)
            {
                if (stat == 0) num2 = lblDisplay.Text;
                num2 = Convert.ToString(float.Parse(num2) / 100);
                lblDisplay.Text = num2;
                stage = 1;
                stat = 1;
            }

            if (num2 == "")
            {
                num1 = lblDisplay.Text;
                lblDisplay.Text = Convert.ToString(float.Parse(num1) / 100);
            }
        }


    }
}
