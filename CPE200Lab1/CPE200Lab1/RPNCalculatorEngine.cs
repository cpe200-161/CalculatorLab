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
                    try
                    {
                        string firstOperand, secondOperand;
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        rpnStack.Push(calculate(part, firstOperand, secondOperand));
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                }
                if (isUnaryOperator(part))
                {
                    try
                    {
                        string operand;
                        operand = rpnStack.Pop();
                        rpnStack.Push(unaryCalculate(part, operand));
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                }
            }
            if (rpnStack.Count > 1) return "E";
            return rpnStack.Pop();
        }
    }
}

