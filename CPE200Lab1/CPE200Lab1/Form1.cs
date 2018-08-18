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
        double FirstNumber;
        string Operation;
        double SecondNumber;
        double Result;
        int push;

        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click_1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                if (Operation == "+" || Operation == "-" || Operation == "*" || Operation == "/" || Operation == "%")
                {
                    if(push == 1)
                    {
                        lblDisplay.Text = "";
                        push = 2;
                    }
                    
                    


                }
                lblDisplay.Text = lblDisplay.Text + btn.Text;



            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (Operation == "%")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = ((FirstNumber * SecondNumber) / 100);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "*")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber * SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "/")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                if (SecondNumber == 0)
                {
                    lblDisplay.Text = "Cannot divide by zero";

                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    if (Result >= 1 || Result <= -1) // "Gn" มันจะนับตั้งแต่เลขที่มีค่า  
                    {
                        lblDisplay.Text = Result.ToString("G8");//ถ้ามากว่า 1 หรือ น้อยกว่า 1 ให้แสดงเลข 8 ตัว
                    }
                    else
                    {
                        lblDisplay.Text = Result.ToString("G7");//แสดงเลข 7 ตัว เพราะ มี 0.xxxx 
                    }

                    FirstNumber = Result;
                }
            }
            if (Operation == "-")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber - SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "+")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber + SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            else
            {
                FirstNumber = Convert.ToDouble(lblDisplay.Text);
            }
            push = 1;
            Operation = "+";

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (Operation == "%")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = ((FirstNumber * SecondNumber) / 100);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            SecondNumber = Convert.ToDouble(lblDisplay.Text);
            if (Operation == "+")
            {
                Result = (FirstNumber + SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "-")
            {
                Result = (FirstNumber - SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "*")
            {
                Result = (FirstNumber * SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "/")
            {
                if (SecondNumber == 0)
                {
                    lblDisplay.Text = "Cannot divide by zero";

                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    if (Result >= 1 || Result <= -1) // "Gn" มันจะนับตั้งแต่เลขที่มีค่า  
                    {
                        lblDisplay.Text = Result.ToString("G8");//ถ้ามากว่า 1 หรือ น้อยกว่า 1 ให้แสดงเลข 8 ตัว
                    }
                    else
                    {
                        lblDisplay.Text = Result.ToString("G7");//แสดงเลข 7 ตัว เพราะ มี 0.xxxx 
                    }

                    FirstNumber = Result;
                }
            }
            push = 1;
            Operation = "";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (Operation == "%")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = ((FirstNumber * SecondNumber) / 100);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "*")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber * SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "/")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                if (SecondNumber == 0)
                {
                    lblDisplay.Text = "Cannot divide by zero";

                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    if (Result >= 1 || Result <= -1) // "Gn" มันจะนับตั้งแต่เลขที่มีค่า  
                    {
                        lblDisplay.Text = Result.ToString("G8");//ถ้ามากว่า 1 หรือ น้อยกว่า 1 ให้แสดงเลข 8 ตัว
                    }
                    else
                    {
                        lblDisplay.Text = Result.ToString("G7");//แสดงเลข 7 ตัว เพราะ มี 0.xxxx 
                    }

                    FirstNumber = Result;
                }
            }
            
            if (Operation == "+")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber + SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "-")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber - SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            else
            {
                FirstNumber = Convert.ToDouble(lblDisplay.Text);
            }
            push = 1;
            Operation = "-";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (Operation == "%")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = ((FirstNumber * SecondNumber) / 100);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "/")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                if (SecondNumber == 0)
                {
                    lblDisplay.Text = "Cannot divide by zero";

                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    if (Result >= 1 || Result <= -1) // "Gn" มันจะนับตั้งแต่เลขที่มีค่า  
                    {
                        lblDisplay.Text = Result.ToString("G8");//ถ้ามากว่า 1 หรือ น้อยกว่า 1 ให้แสดงเลข 8 ตัว
                    }
                    else
                    {
                        lblDisplay.Text = Result.ToString("G7");//แสดงเลข 7 ตัว เพราะ มี 0.xxxx 
                    }

                    FirstNumber = Result;
                }
            }
            if (Operation == "-")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber - SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "+")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber + SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "*")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber * SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            else
            {
                FirstNumber = Convert.ToDouble(lblDisplay.Text);
            }
            push = 1;
            Operation = "*";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (Operation == "%")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = ((FirstNumber * SecondNumber) / 100);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "*")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber * SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
           
            if (Operation == "-")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber - SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "+")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber + SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "/")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                if (SecondNumber == 0)
                {
                    lblDisplay.Text = "Cannot divide by zero";

                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    if (Result >= 1 || Result <= -1) // "Gn" มันจะนับตั้งแต่เลขที่มีค่า  
                    {
                        lblDisplay.Text = Result.ToString("G8");//ถ้ามากว่า 1 หรือ น้อยกว่า 1 ให้แสดงเลข 8 ตัว
                    }
                    else
                    {
                        lblDisplay.Text = Result.ToString("G7");//แสดงเลข 7 ตัว เพราะ มี 0.xxxx 
                    }

                    FirstNumber = Result;
                }
            }
            else
            {
                FirstNumber = Convert.ToDouble(lblDisplay.Text);
            }
            push = 1;
            Operation = "/";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FirstNumber = 0;
            lblDisplay.Text = "0";
            Operation = "";
            push = 1;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (Operation == "*")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber * SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }

            if (Operation == "-")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber - SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "+")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = (FirstNumber + SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "/")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                if (SecondNumber == 0)
                {
                    lblDisplay.Text = "Cannot divide by zero";

                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    if (Result >= 1 || Result <= -1) // "Gn" มันจะนับตั้งแต่เลขที่มีค่า  
                    {
                        lblDisplay.Text = Result.ToString("G8");//ถ้ามากว่า 1 หรือ น้อยกว่า 1 ให้แสดงเลข 8 ตัว
                    }
                    else
                    {
                        lblDisplay.Text = Result.ToString("G7");//แสดงเลข 7 ตัว เพราะ มี 0.xxxx 
                    }

                    FirstNumber = Result;
                }
            }
            if (Operation == "%")
            {
                SecondNumber = Convert.ToDouble(lblDisplay.Text);
                Result = ((FirstNumber * SecondNumber) / 100);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            else
            {
                FirstNumber = Convert.ToDouble(lblDisplay.Text);
            }
            push = 1;
            Operation = "%";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

