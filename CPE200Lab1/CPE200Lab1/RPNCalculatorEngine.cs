using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalaulatorEngine
    {
        public new string Process(string str)
        {
            // your code here
            Stack<string> RPN = new Stack<string>();
            string[] parts = str.Split(' ');
            string num1, num2, ans;
            List<string> withoutspace = parts.ToList<string>();
            withoutspace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = withoutspace.ToArray();

            for (int i=0;i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    RPN.Push(parts[i]);
                }
                else if(isOperator(parts[i]) && RPN.Count >= 2)
                {
                    num2 = RPN.Pop();
                    num1 = RPN.Pop();
                    ans = calculate(parts[i], num1, num2);
                    RPN.Push(ans);
                }
                else
                {
                    return "E";
                }
            }
            if(RPN.Count == 1)
            {
                return RPN.Pop();
            }
            else
            {
                return "E";
            }

            //return "E";
        }
    }
}
