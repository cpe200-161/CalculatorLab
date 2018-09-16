using System;
using System.Collections;
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
            string one,two,sum;
            Stack myStack = new Stack();
            string[] parts = str.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }
                else if (isOperator(parts[i]) && myStack.Count >= 2)
                {
                    two = myStack.Pop().ToString();
                    one = myStack.Pop().ToString();
                    sum = calculate(parts[i], one, two);
                    myStack.Push(sum);
                }
                else
                {
                    return "E";
                }
            }
            if (myStack.Count==1)
            {   
                return myStack.Pop().ToString();
            }
            else
            {
               return "E";
            }
          
        }
    }
}
