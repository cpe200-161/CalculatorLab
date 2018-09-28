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

            String[] txt = str.Split(' ');
            String a1, a2;
            Stack<string> x = new Stack<string>();
            for (int i = 0; i < txt.Length; i++)
            {
                if (isNumber(txt[i]))
                {
                    x.Push(txt[i]);
                }
                else if (isOperator(txt[i]))
                {
                    string sum;
                    a1 = x.Pop();
                    a2 = x.Pop();
                    sum = calculate(txt[i], a2, a1);
                    x.Push(sum);
                }
         
            }
            return x.Peek();
            
            
        }
    }
    
}
