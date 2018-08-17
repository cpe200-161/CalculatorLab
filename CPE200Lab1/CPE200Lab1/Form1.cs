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

        string firstNum = "";
        string seccondNum = "";
        string operationRightNow = "";
        bool gettingAnotherInput = true;
        bool getNewNumber = true;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            if (gettingAnotherInput)
            {
                lblDisplay.Text = "";
                gettingAnotherInput = false;
                getNewNumber = true;

            }

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }

            

        }

        private void btnCalculation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (operationRightNow == "")
            {
                operationRightNow = btn.Text;
            }
            

            if (!getNewNumber)
            {
                return;
            }

            if (firstNum == "")
            {
                firstNum = lblDisplay.Text;

            }
            else
            {
                seccondNum = lblDisplay.Text;

                float num1 = float.Parse(firstNum);
                float num2 = float.Parse(seccondNum);
                float result = 0;
                switch (operationRightNow)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "X":
                        result = num1 * num2;
                        break;
                    case "÷":
                        result = num1 / num2;
                        break;
                    default:
                        Console.WriteLine("Unknown sign");
                        break;

                }

                firstNum = result.ToString();

            }

            gettingAnotherInput = true;
            getNewNumber = false;

            lblDisplay.Text = firstNum.ToString();

            operationRightNow = btn.Text;


        }

    }
}
