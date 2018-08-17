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

        float firstNum = 0f;
        float seccondNum = 0f;
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
            if (!getNewNumber)
            {
                return;
            }

            float lblnum = float.Parse(lblDisplay.Text);
            
            Button btn = (Button)sender;
            string sign = btn.Text;
            operationRightNow = sign;

            if (firstNum == 0)
            {
                firstNum = lblnum;

            }
            else
            {
                seccondNum = lblnum;
                firstNum += seccondNum;

                
            }

            gettingAnotherInput = true;
            
            lblDisplay.Text = firstNum.ToString();

            getNewNumber = false;

            //Debugging
            Console.WriteLine("operator: " + operationRightNow);
            Console.WriteLine("firstnum: " + firstNum);
            Console.WriteLine("seccond: " + seccondNum);


        }

        
    }
}
