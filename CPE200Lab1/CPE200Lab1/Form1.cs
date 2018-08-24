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
        string lastestOperaton = "";
        bool getNewNumber = false;
        

       
        public Form1()
        {
            InitializeComponent();
        }

        private void btnXClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if ((btn.Text != "." && lblDisplay.Text == "0")|| !getNewNumber)
            {
                lblDisplay.Text = "";
                
                getNewNumber = true;
                

            }

            if (lblDisplay.Text.Length < 8)
            {

                if (btn.Text == "." && lblDisplay.Text.IndexOf(".") != -1)
                {
                    return;
                }

                lblDisplay.Text += btn.Text;
            }

            

        }

        private void btnCalculationClick(object sender, EventArgs e)
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

                    if (lastestOperaton == "=")
                    {
                        lastestOperaton = btn.Text;
                    }

                    float result = CalculationProcess(num1, num2, lastestOperaton);
                    firstNum = result.ToString();

                }

                getNewNumber = false;
                
            }


            lastestOperaton = btn.Text;
            lblDisplay.Text = firstNum;
            
            


        }

        private void anotherButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String specialOperation = btn.Text;

            switch (specialOperation)
            {
                case "%":
                    float num1 = (firstNum == "") ? 0 : float.Parse(firstNum);
                    float currentNum = float.Parse(lblDisplay.Text);
                    currentNum = (currentNum / 100) * num1;
                    lblDisplay.Text = currentNum.ToString();
                    break;
                case "<":
                    if (lblDisplay.Text.Length > 1 && lblDisplay.Text != "max")
                    {
                        lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
                    }
                    else
                    {
                        lblDisplay.Text = "0";
                    }
                    break;
                case "C":
                    firstNum = "";
                    seccondNum = "";
                    lastestOperaton = "";
                    getNewNumber = false;
                    lblDisplay.Text = "0";
                    
                    break;
                case "±":
                    if (!lblDisplay.Text.StartsWith("-") && lblDisplay.Text != "0")
                    {
                        lblDisplay.Text = "-" + lblDisplay.Text;
                    }
                    else
                    {
                        lblDisplay.Text = lblDisplay.Text.Substring(1);
                    }

                    getNewNumber = true;
                    break;
                default:
                    Console.WriteLine("Unknown operation");
                    break;
            }

            
            

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
