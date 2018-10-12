using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        string stnum , secnum,  resultback;
        public override string Process(string str)
        {
            Stack<string> cct = new Stack<string>();
            string[] parts = str.Split(' ');
     
            for(int i=0;i< parts.Length-1; i++)
            {
                if (isNumber(parts[i]))
                {
                    cct.Push(parts[i]);
                }
                if (isOperator2(parts[i]))
                {                   
                    
                    secnum = cct.Pop();
                    stnum = cct.Pop();
                    resultback = calculate(parts[i], stnum, secnum, 4);
                    cct.Push(resultback);
                }
            }

            if (!(isNumber(parts[0]) && isOperator2(parts[1]) && isNumber(parts[2])))
            {
                 return cct.Peek();             
         
            } else
            {
                return "E";

            }
            
        }
     


    }
}
