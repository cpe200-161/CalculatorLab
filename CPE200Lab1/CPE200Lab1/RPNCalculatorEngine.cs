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
            Stack<string> numStack = new Stack<string>();
            string first, secound;
            string[] parts = str.Split(' ');
            Console.WriteLine(parts);

            for(int i = 0; i < parts.Length; i++)
            {
                if (isOperator(parts[i]))
                {
                    if (numStack.Count < 2) return "E";
                }
                if (isNumber(parts[i]))
                {
                    numStack.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    first = (string)numStack.Pop();
                    secound = (string)numStack.Pop();
                    numStack.Push(calculate(parts[i], secound, first, 4));
                }

            }
            if (numStack.Count == 1) {
                return (string)numStack.Pop();
            }
            return "E";
        }
    }
}
