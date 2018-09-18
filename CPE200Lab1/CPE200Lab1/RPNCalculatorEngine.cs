using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            Stack<string> rpnStack = new Stack<string>();
            string[] parts = str.ToString().Split(' ');

            foreach (string part in parts)
            {
                if (isNumber(part))
                {
                    rpnStack.Push(part);
                }
                if (isOperator(part))
                {
                    string firstOperand, secondOperand;
                    if (rpnStack.Count < 2) return "E";
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    rpnStack.Push(calculate(part, firstOperand, secondOperand));
                }
                if (isUnaryOperator(part))
                {
                    string operand;
                    if (rpnStack.Count < 1) return "E";
                    operand = rpnStack.Pop();
                    rpnStack.Push(unaryCalculate(part, operand));
                }
            }
            if (rpnStack.Count > 1) return "E";
            return rpnStack.Pop();
        }
        }
    }

