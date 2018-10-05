using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine:CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> sTack = new Stack<string>();
            string[] parts = str.ToString().Split(' ');
            string firstOp, secondOp;
            string result;
            int numCount = 0, operCount = 0;
            foreach(string part in parts)
            {
                if (isNumber(part))
                {
                    sTack.Push(part);
                }
                if (isOperator(part))
                {
                    secondOp = sTack.Pop();
                    firstOp = sTack.Pop();
                    result = calculate(part, firstOp, secondOp);
                    sTack.Push(result);
                }
            }

            return sTack.Pop();
        }
    }
}
