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
            string value;
            string value2;
            string oper;
            string[] strArray = str.Split(' ');
            if (strArray.Length == 1) { return "E"; }
           // if(strArray)
            // your code here
            Stack fristob = new Stack();


            foreach(string save in strArray)
            {
                if (isNumber(save))
                {
                    fristob.Push(save);
                }
                else if (isOperator(save))
                {
                    if (fristob.Count > 1)
                    {
                        value = fristob.Pop().ToString();
                        value2 = fristob.Pop().ToString();
                    }
                    else
                    {
                        return "E";
                    }
                    Console.WriteLine(value);
                    Console.WriteLine(value2);
                    fristob.Push(calculate(save, value2, value, 8));

                }
                
            }
            if (fristob.Count == 1)
            {
                return Convert.ToDecimal(fristob.Peek()).ToString("G29");
            }
            else
            {

                return "E";

            }
        }
    }
}
