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
        String operation = "hi";
        float num1, num2, result, percentNum;
        String strNum1 = "";
        String strNum2 = "";
        String previousString = "";
        String strPercent = "";
        bool checkPercent, canCalPercent, isMPsignOnNum1, isMPsignOnNum2;
        public Form1()
        {
            InitializeComponent();
        }

        public void ConditionBtn(object sender, EventArgs e)
        {
            bool CheckDobleOperation = false;

            Button btn = (Button)sender;
            System.Console.WriteLine(btn.Text);
            if ((previousString == "+" || previousString == "-" || previousString == "X" || previousString == "÷" || previousString == "="
               ) && (btn.Text == "+" || btn.Text == "-" || btn.Text == "X" || btn.Text == "÷" || btn.Text == "="
               )   )
            {
                //lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
                CheckDobleOperation = true;
            }

            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }

            if (lblDisplay.Text.Length <= 8)
            {


                System.Console.WriteLine(CheckDobleOperation);
                if (btn.Text == "<")
                {
                    if (lblDisplay.Text.Length >= 1)
                    {
                        lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
                        
                    }
                    else
                    {
                        lblDisplay.Text = "0";
                    }
                }
                else
                {
                    if ((operation == "+" || operation == "-" || operation == "X" || operation == "÷" || operation == "%" || canCalPercent == true) && CheckDobleOperation == false )
                    {

                        if (btn.Text == "=")
                        {
                            ConvertToFloat();
                            Operation(num1, num2, operation);
                            strNum1 = result.ToString("");
                            strNum2 = "";
                            operation = "";
                            System.Console.WriteLine(num1 + " " + num2);



                        }
                        else if (btn.Text == "%")
                        {
                            ConvertToFloat();

                            if (checkPercent)
                            {
                                result = num1 * percentNum / 100;
                                lblDisplay.Text = result.ToString("");
                                operation = "";

                            }
                            else
                            {
                                
                                num2 = num1 * num2 / 100;
                                strPercent = num2.ToString("");
                                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - strNum2.Length) + strPercent;
                                percentNum = num2;
                                strNum2 = strPercent;
                                checkPercent = true;


                            }
                        }
                        else if (btn.Text == "+" || btn.Text == "-" || btn.Text == "X" || btn.Text == "÷" || btn.Text == "%")
                        {
                            ConvertToFloat();
                            Operation(num1, num2, operation);
                            lblDisplay.Text = lblDisplay.Text + btn.Text;
                            strNum1 = result.ToString("");
                            strNum2 = "";
                            operation = btn.Text;
                        }


                        else
                        {

                            strNum2 = strNum2 + btn.Text;
                            lblDisplay.Text = lblDisplay.Text + btn.Text;


                        }
                            


                    }
                    else if(CheckDobleOperation == false)
                    {
                        if (btn.Text == "+" || btn.Text == "-" || btn.Text == "X" || btn.Text == "÷")
                        {
                            operation = btn.Text;
                            lblDisplay.Text = lblDisplay.Text + btn.Text;


                        }
                        else if (btn.Text == "%")
                        {
                            if(result != 0)
                            {
                                result = result * percentNum / 100;
                                lblDisplay.Text = result.ToString("");
                                operation = "";
                            }
                            else
                            {
                                lblDisplay.Text = "0";
                            }
                        }
                        else
                        {
                            
                            strNum1 = strNum1 + btn.Text;
                            if(strNum1 == "+" || strNum1 == "-" || strNum1 == "X" || strNum1 == "÷" || strNum1 == "%" || strNum1 == "=")
                            {
                                strNum1 = strNum1.Remove(strNum1.Length - 1);

                            }
                            else
                            {
                                lblDisplay.Text = lblDisplay.Text + btn.Text;
                            }
                        }
                    }
                }
                




                //if (btn.Text == "=")
                //{
                //    //System.Console.WriteLine(operation);

                //    //Operation(num1, num2, operation);

                //    //stringNum = lblDisplay.Text.Split('+', '-', 'X', '÷', '=');

                //    //isMinus(stringNum);
                //    ////num1 = float.Parse(stringNum[0]);
                //    ////lblDisplay.Text = stringNum.Length.ToString();
                //    ////var charsToRemove = new string[] { "=" };
                //    ////foreach (var c in charsToRemove)
                //    ////{
                //    ////    stringNum[1] = stringNum[1].Replace(c, string.Empty);
                //    ////}

                //    ////num2 = float.Parse(stringNum[1]);

                //    //Operation(num1, num2, operation);

                //    //lblDisplay.Text = result.ToString("");

                //    ////lblDisplay.Text = operation;
                //    ////lblDisplay.Text = stringNum[1];
                //    ////lblDisplay.Text = stringNum[0];
                //}

            }
            previousString = btn.Text;

        }

        public void Operation(float num1, float num2, string operation)
        {
            if(operation == "+")
            {
                result = num1 + num2;
              
            }
            else if(operation == "-")
            {
                result = num1 - num2;
            }
            else if(operation == "X")
            {
                result = num1 * num2;
            }
            else if(operation == "÷")
            {
                result = num1 / num2;
            }
            

            lblDisplay.Text = result.ToString("");


        }

        public void resetButton(object sender, EventArgs e)
        {

            num1 = 0;
            num2 = 0;
            operation = "";
            result = 0;
            lblDisplay.Text = "0";
            strNum1 = "";
            strNum2 = "";
            checkPercent = false;
            percentNum = 0;
            previousString = "";
            strPercent = "";
            canCalPercent = false;
            isMPsignOnNum1 = false;
            isMPsignOnNum2 = false;
            //String operation = "hi";
            //float num1, num2, result, percentNum;
            //String strNum1 = "";
            //String strNum2 = "";
            //String previousString = "";
            //String strPercent = "";
            //bool checkPercent, canCalPercent, isMPsignOnNum1, isMPsignOnNum2;

        }

        public void MPsignButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string oldNum;

            if (btn.Text == "±")
            {
                if (strNum1 != "" && strNum2 != "")
                {
                    System.Console.WriteLine("on1");

                    oldNum = strNum2;
                    num2 = float.Parse(strNum2);
                    num2 = num2 * -1;
                    strNum2 = num2.ToString("");
                    lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - oldNum.Length) + strNum2;
                    isMPsignOnNum2 = true;


                }
                else if (strNum1 != "")
                {
                    System.Console.WriteLine("on2");

                    oldNum = strNum1;
                    num1 = float.Parse(strNum1);
                    num1 = num1 * -1;
                    strNum1 = num1.ToString("");
                    lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - oldNum.Length) + strNum1;
                    isMPsignOnNum1 = true;
                }
                
            }
        }

        public void ConvertToFloat()
        {
            if(isMPsignOnNum1)
            {
                num2 = float.Parse(strNum2);
            }
            else if(isMPsignOnNum2)
            {
                num1 = float.Parse(strNum1);
            }
            else
            {
                System.Console.WriteLine("on3");
                num1 = float.Parse(strNum1);
                num2 = float.Parse(strNum2);
            }
        }
        //public void isMinus(String[] stringNum)
        //{
        //    if(stringNum.Length == 4)
        //    {
        //        num1 = float.Parse(stringNum[1]) * -1;
        //        num2 = float.Parse(stringNum[2]);
        //    }
        //    else
        //    {
        //        num1 = float.Parse(stringNum[0]);
        //        num2 = float.Parse(stringNum[1]);
        //    }
        //}

        //public void cal(float num1, float num2, String operation)
        //{
        //    ////String[] stringNum;

        //    //stringNum = lblDisplay.Text.Split('+', '-', 'X', '÷', '=');

        //    //isMinus(stringNum);

        //    //Operation(num1, num2, operation);

        //    lblDisplay.Text = result.ToString("");



        //}

    }
}
