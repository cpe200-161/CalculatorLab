﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        //public  object result;
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private string display;

        public string Display()
        {
            return display;
        }

        public void resetAll()
        {
            display = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }

        private bool isOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case 'X':
                case '÷':
                    return true;
            }
            return false;
        }

        public void handleNumber(string inputNumber)
        {
            if (display is "Error")
            {
                return;
            }
            if (display is "0")
            {
                display = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            display += inputNumber;
            isSpaceAllowed = true;
        }

        public void handleBinaryOperator(string inputBinaryOperator)
        {
            if (display is "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            string current = display;
            if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2]))
            {
                display += " " + inputBinaryOperator + " ";
                isSpaceAllowed = false;
            }
        }

        public void handleBack()
        {
            if (display is "Error")
            {
                return;
            }
            // check if the last one is operator
            string current = display;
            if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
            {
                display = current.Substring(0, current.Length - 3);
            }
            else
            {
                display = current.Substring(0, current.Length - 1);
            }
            if (display is "")
            {
                display = "0";
            }
        }

        public void handleEqual()
        {
            string result = Process(display);
            if (result is "E")
            {
                display = "Error";
            }
            else
            {
                display = result;
                isSpaceAllowed = true;
                isContainDot = false;
                isNumberPart = true;
            }
        }
        public void handleSign()
        {
            if (display is "Error")
            {
                return;
            }
            if (isNumberPart)
            {
                return;
            }
            string current = display;
            if (current is "0")
            {
                display = "-";
            }
            else if (current[current.Length - 1] is '-')
            {
                display = current.Substring(0, current.Length - 1);
                if (display is "")
                {
                    display = "0";
                }
            }
            else
            {
                display = current + "-";
            }
            isSpaceAllowed = false;
        }

        public void handleDot()
        {
            if (display is "Error")
            {
                return;
            }
            if (!isContainDot)
            {
                isContainDot = true;
                display += ".";
                isSpaceAllowed = false;
            }
        }

        public void handleSpace()
        {
            if (display is "Error")
            {
                return;
            }
            if (isSpaceAllowed)
            {
                display += " ";
                isSpaceAllowed = false;
            }
        }

        public override string Process(string str)
        {
            // your code here
            if(str == null || str == "")
            {
                return "E";
            }
            else
            {

            string[] parts = str.Split(' ');

            Stack<string> operands = new Stack<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    operands.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (operands.Count < 2)
                    {
                        return "E";
                    }
                    string op2 = operands.Pop();
                    string op1 = operands.Pop();
                    string result = calculate(parts[i], op1, op2, 4);
                    if (result is "E")
                    {
                        return result;
                      }
                    operands.Push(result);
                }
                else
                    {
                        string NumberOrOperator = parts[i];
                        for(int j = 0;j<NumberOrOperator.Length;j++)
                        {
                            if(isOperator(NumberOrOperator[j].ToString()) && NumberOrOperator[j] != '-')
                            {
                                return "E";
                            }
                        }
                }
            }
                //FIXME, what if there is more than one, or zero, items in the stack? 
                if (operands.Count != 1)
                {
                    return "E";
                }
                else if (operands.Count == 1)
                {
                    string number = operands.Pop();
                    string NumberReturn = number;

                    for (int i = 0; i < number.Length; i++)
                    {
                        if (isOperator(number[i].ToString()) && number[0] != '-')
                            return "E";
                    }

                    string[] Checktxt = number.Split('.');
                    string Decimals;
                    int Decimalsint;
                    if (Checktxt.Length > 1 && isNumber(Checktxt[1]) && Checktxt[1].Length > 4)
                    {
                        Decimals = Checktxt[1].Substring(0, 5);
                        if (Int32.Parse(Decimals[4].ToString()) > 5)
                        {
                            Decimalsint = Int32.Parse(Checktxt[1].Substring(0, 4));
                            Decimalsint++;
                            Decimals = Decimalsint.ToString();
                        }
                        else
                        {
                            Decimals = Checktxt[1].Substring(0, 4);
                        }
                        NumberReturn = Checktxt[0] + "." + Decimals;
                    }
                    operands.Push(NumberReturn);
                }
                return operands.Pop();
            }
           
            }
        }



        /* public override string Display()
         {
             return "doi tomorrow";
         }*/

        /* public override void handleSpace()
         {
             base.handleSpace();
             isNumberPart = false;
         }
             //end old code
             return "E";
         }*/

    }
    

