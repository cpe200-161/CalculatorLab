using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{

    public class RPNCalculatorEngine : CalculatorEngine
    {
        string stnum, secnum, resultback,result,oper;                       // declare string 

        public override string Process(string str)
        {

            if(str == "" || str == null || str =="+1")
            {
                return "E";
            }
            Stack<string> cct = new Stack<string>();            // your code here
            string[] parts = str.Split(' ');

            for (int i = 0; i < parts.Length; i++)        
            {
                
                if (isNumber(parts[i]))                     // only number
                {
                    cct.Push(parts[i]);
                }
                if (isOperator(parts[i]))                  // if sign
                {
                    if (cct.Count > 1)
                    {
                        secnum = cct.Pop();                    // set second number
                        stnum = cct.Pop();                      //ser first number
                        resultback = Calculate(parts[i], stnum, secnum, 4);     // calculating
                        cct.Push(resultback);                   // save answer
                    }
                    else
                    {
                        return "E";                       
                    }
                }
                else if(parts[i] == "++")
                {
                    break;
                }
                
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if(cct.Count >1 || cct.Count == 0)
            {
                return "E";
            }
            else
            {
                result = cct.Pop();
                return result;
            }
            
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
 