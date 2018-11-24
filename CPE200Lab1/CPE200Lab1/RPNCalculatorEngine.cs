using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        string firstOperand, number;
        public string RPNProcess(string str)
        {
            int i = 0;
            double summaryresult = 0;
            Stack<string> CalculatorStack = new Stack<string>();
            string[] parts = str.Split(' ');
            int size = parts.Length;
            if (size == 1)
            {
                return "E";
            }
            while (i < size)
            {
                number = parts[i];
                if (!isOperator(number))
                {
                    CalculatorStack.Push(number);
                }
                else
                {
                    string operand = number;
                    switch (operand)
                    {
                        case "+":
                            if (CalculatorStack.Count == 0) return "E";
                            firstOperand = CalculatorStack.Pop();
                            if (CalculatorStack.Count == 0) return "E";
                            summaryresult = Double.Parse(CalculatorStack.Pop()) + Double.Parse(firstOperand);
                            break;
                        case "-":
                            if (CalculatorStack.Count == 0) return "E";
                            firstOperand = CalculatorStack.Pop();
                            if (CalculatorStack.Count == 0) return "E";
                            summaryresult = Double.Parse(CalculatorStack.Pop()) - Double.Parse(firstOperand);
                            break;
                        case "X":
                            if (CalculatorStack.Count == 0) return "E";
                            firstOperand = CalculatorStack.Pop();
                            if (CalculatorStack.Count == 0) return "E";
                            summaryresult = Double.Parse(CalculatorStack.Pop()) * Double.Parse(firstOperand);
                            break;
                        case "÷":
                            if (CalculatorStack.Count == 0) return "E";
                            firstOperand = CalculatorStack.Pop();
                            if (CalculatorStack.Count == 0) return "E";
                            summaryresult = Double.Parse(CalculatorStack.Pop()) / Double.Parse(firstOperand);
                            break;
                        case "√":
                            if (CalculatorStack.Count == 0) return "E";
                            firstOperand = CalculatorStack.Pop();
                            summaryresult = Math.Sqrt(Double.Parse(firstOperand));
                            break;
                        case "1/x":
                            if (CalculatorStack.Count == 0) return "E";
                            firstOperand = CalculatorStack.Pop();
                            summaryresult = 1.0 / (Double.Parse(firstOperand));
                            break;
                        case "%":
                            if (CalculatorStack.Count == 0) return "E";
                            firstOperand = CalculatorStack.Pop();
                            string percent = CalculatorStack.Pop();
                            summaryresult = (Double.Parse(percent) * (Double.Parse(firstOperand))) / 100.0;
                            CalculatorStack.Push((percent).ToString());
                            break;
                    }
                    CalculatorStack.Push((summaryresult).ToString());
                }
                i++;
            }
            if (CalculatorStack.Count > 1)
            {
                return "E";
            }

            return CalculatorStack.Peek();

        }
    }
}