using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine 
    {
        public string RPNProcess(string str)
        {
            string[] parts = str.Split(' ');
            Stack<string> number = new Stack<string>();
            for(int i = 0;i < str.Length/2 ; i++)
            {
                if(isNumber(parts[i]))
                {
                    number.Push(parts[i]);
                }
                if (isOperator(parts[i]))
                {
                    if(number.Count < 2)
                    {
                        return "E";
                    }else
                    {
                        number.Push(calculate(parts[i], number.Pop(), number.Pop()));
                    }
                }
            }
            return number.Pop();



            //return Process(str);
        }
    }
}
