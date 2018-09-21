using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            Stack<string> stack = new Stack<string>();
            string[] parts = str.Split(' ');
            double number;
            try
            {
                foreach (string part in parts)
                {
                    if (double.TryParse(part, out number))
                    {
                        stack.Push(number.ToString());
                    }
                    else
                    {
                        switch (part)
                        {
                            case "+":
                            case "-":
                            case "X":
                            case "÷":
                            case "%":
                                string first, second;
                                second = stack.Pop();
                                first = stack.Pop();
                                stack.Push(calculate(part, first, second));
                                break;
                            case "1/x":
                            case "√":
                                string n;
                                n = stack.Pop();
                                stack.Push(unaryCalculate(part, n));
                                break;
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                return "E";
            }
            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                return "E";
            }
        }
    }
}

/*
foreach(string part in parts)
        {
            if (double.TryParse(part, out number))
            {
                stack.Push(number.ToString());
            }
            else
            {
                switch (part)
                {
                    case "+":
                    case "-":
                    case "X":
                    case "÷":
                    case "%":
                        string first, second;
                        if (stack.Count >= 2)
                        {
                            second = stack.Pop();
                            first = stack.Pop();
                        }
                        else
                        {
                            return "E";
                        }
                        stack.Push(calculate(part, first, second));
                        break;
                    case "1/x":
                    case "√":
                        string n;
                        if(stack.Count >= 1)
                        {
                            n = stack.Pop();
                        }
                        else
                        {
                            return "E";
                        }
                        stack.Push(unaryCalculate(part, n));
                        break;
                }
            }
        }
        if(stack.Count == 1)
        {
            return stack.Pop();
        }
        else
        {
            return "E";
        }*/
