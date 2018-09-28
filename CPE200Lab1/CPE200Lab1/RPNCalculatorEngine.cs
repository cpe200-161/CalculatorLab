using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public override string Process(string str)
        {
            // your code here
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;

            foreach (string i in parts)
            {
                if (isNumber(i))
                {
                    rpnStack.Push(i);
                }
                else if (isOperator(i))
                {
                    
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(i, firstOperand, secondOperand, 4);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
            }
            if (rpnStack.Count == 1)
            {
                result = rpnStack.Pop();
                return result;
            }else
                return "E";
        }
    }
}
