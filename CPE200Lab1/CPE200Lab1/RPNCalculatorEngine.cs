using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{

    public class RPNCalculatorEngine : CalculatorEngine
    {
        string stnum, secnum, resultback;                       // declare string 
        public string Process(string str)
        {
            Stack<string> cct = new Stack<string>();            // your code here
            string[] parts = str.Split(' ');

            for (int i = 0; i < parts.Length - 1; i++)        
            {
                if (isNumber(parts[i]))                     // only number
                {
                    cct.Push(parts[i]);
                }
                if (isOperator(parts[i]))                  // if sign
                {

                    secnum = cct.Pop();                    // set second number
                    stnum = cct.Pop();                      //ser first number
                    resultback = Calculate(parts[i], stnum, secnum, 4);     // calculating
                    cct.Push(resultback);                   // save answer
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            result = rpnStack.Pop();
            return result;
        }
    }
    /*
    public class RPNCalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            return "E";
        }
    
    }
    */
}
 