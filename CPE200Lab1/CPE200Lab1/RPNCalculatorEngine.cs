using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        public string calculate(string str)
        {
            Stack<string> numbers = new Stack<string>();
            string[] parts = str.Split(' ');
            if (parts.Length == 1)
            {
                return "E";
            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    numbers.Push(parts[i]);
                }
                else if (thisisOperator(parts[i]))
                {
                    string st;
                    st = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(calculate(parts[i],st,8));
                }
                else if (parts[i]== "%")
                {
                    string st, nd;
                    if (numbers.Count < 2)
                    {
                        return "E";
                    }
                    nd = numbers.Peek();
                    numbers.Pop();
                    st = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(thismodCalculator(st, nd, 8));

                }
                else if (isOperator(parts[i]))
                {
                    if (numbers.Count < 2)
                    {
                        return "E";
                    }
                    string st, nd;
                    nd = numbers.Peek();
                    numbers.Pop();
                    st = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(calculate(parts[i], st, nd, 8));

                }

            }
            if (numbers.Count == 1)
            {
                return numbers.Peek();
            }
            else
            {
                return "E";
            }
            // your code here

        }
    }
}
