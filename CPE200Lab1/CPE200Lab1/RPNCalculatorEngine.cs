﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        private bool isUnary(string str)
        {
            switch (str)
            {
                case "1/x":
                case "√":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            // your code 
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
                    try
                    {
                        string secondOperands = operands.Pop();
                        operands.Push(calculate(parts[i], operands.Pop(), secondOperands));
                    }
                    catch (Exception e)
                    {
                        return "E";
                    }
                }
                else if(parts[i] == "%")
                {
                    if(parts[i+1] == "+" || parts[i+1] == "-")
                    {
                        operands.Push(calculate(parts[i], operands.Pop(), operands.Peek()));
                    }
                    else
                    {
                        operands.Push(calculate(parts[i], operands.Pop(), null));
                    }
                }
                else if (isUnary(parts[i]))
                {
                    operands.Push(unaryCalculate(parts[i], operands.Pop()));
                }
            }
            if(operands.Count == 1)
            {
                return operands.Pop();
            }
            return "E";
        }
    }
}