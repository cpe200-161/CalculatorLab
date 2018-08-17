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
        string operationRightNow = "=";
        bool getNewNumber = false;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            if (!getNewNumber)
            {
                lblDisplay.Text = "";
                
                getNewNumber = true;

            }

            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text += btn.Text;
            }

            

        }

        private void btnCalculation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (getNewNumber)
            {
                if (firstNum == "")
                {
                    firstNum = lblDisplay.Text;

                }
                else
                {
                    seccondNum = lblDisplay.Text;

                    float num1 = float.Parse(firstNum);
                    float num2 = float.Parse(seccondNum);

                    if (operationRightNow == "=")
                    {
                        operationRightNow = btn.Text;
                    }

                    float result = CalculationProcess(num1, num2, operationRightNow);
                    firstNum = result.ToString();

                }

                getNewNumber = false;
                
            }


            operationRightNow = btn.Text;
            lblDisplay.Text = firstNum;


        }

        private float CalculationProcess(float num1, float num2, string operation)
        {
            float result = 0;
            switch (operation)
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
                case "=":
                    result = num2;
                    break;
                default:
                    Console.WriteLine("Unknown sign");
                    break;

            }

            return result;
        }

       
    }
}
