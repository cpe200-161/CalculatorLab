using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            Console.WriteLine("I am here");
            string firstop, secondop;
            string[] strArray = str.Split(' ');
            if(strArray.Length < 3)
            {
                return "E";
            }
            Stack rpnstack = new Stack();


            foreach (string s in strArray)
            {
                Console.WriteLine(s);
                if (isNumber(s))
                {
                     rpnstack.Push(s);
                     
                }
                else if (isOperator(s))
                {
                    if (rpnstack.Count > 1)
                    {
                        secondop  = rpnstack.Pop().ToString();
                        firstop = rpnstack.Pop().ToString();
                        rpnstack.Push(calculate(s, firstop, secondop));
                    }
                    else
                    {
                        return "E";
                    }
                    
                }
            }
            if (rpnstack.Count == 1)
            {
                    return decimal.Parse(rpnstack.Peek().ToString()).ToString("G29");
               
                
            }
            else
            {
                return "E";
            }
            
        }
    }
}
