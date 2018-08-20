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
        float? FirstNumber;
        bool BtnOperator_Clicked = false;
        bool BtnEqual_Clicked = false;
        string Operator;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if(BtnOperator_Clicked == true)
            {
                lblDisplay.Text = "";
                BtnOperator_Clicked = false;
            }
            if(BtnEqual_Clicked == true)
            {
                lblDisplay.Text = "";
                BtnEqual_Clicked = false;
            }

            if(lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
        }

        private void BtnOperator_Click(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            FirstNumber = float.Parse(lblDisplay.Text);
            BtnOperator_Clicked = true;
            Operator = btn.Name;
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            float SecondNumber = float.Parse(lblDisplay.Text);
            float? Result = null;
            if(Operator == "btnPlus")
            {
                Result = FirstNumber + SecondNumber;
            }
            if(Operator == "btnMinus")
            {
                Result = FirstNumber - SecondNumber;
            }
            if(Operator == "btnMultiply")
            {
                Result = FirstNumber * SecondNumber;
            }
            if(Operator == "btnDivide")
            {
                Result = FirstNumber / SecondNumber;
            }
            if(Result != null)
            {
                lblDisplay.Text = Result.ToString();
            }
            BtnEqual_Clicked = true;
        }

        private void BtnPercent_Click(object sender,EventArgs e)
        {
            if(Operator == "btnPlus" || Operator == "btnMinus")
            {
                lblDisplay.Text = (FirstNumber * float.Parse(lblDisplay.Text) / 100).ToString();
            }
            else
            {
                lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100).ToString();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Operator = null;
            FirstNumber = null;
            lblDisplay.Text = "0";
            BtnOperator_Clicked = false;
            BtnEqual_Clicked = false;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
        }

        private void BtnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text) * -1).ToString();
        }
    }
}
