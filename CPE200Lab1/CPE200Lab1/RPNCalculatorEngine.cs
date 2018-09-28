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
        /// <summary>
        /// process pop number to calculate 2 number which input or 1 number for loot and 1/x
        /// </summary>
        /// <param name="str">str is string  input to process</param>
        /// 
        /// <returns>result of equations</returns>
        public string Process(string str)
        {
            string value;
            string value2;
            string oper;
            string[] strArray = str.Split(' ');
            if (strArray.Length == 1) { return "E"; }
            // if(strArray)
            // your code here
            Stack<string> fristob = new Stack<string>();

            foreach (string save in strArray)
            {
                if (isNumber(save))
                {
                    fristob.Push(save);
                }
                else if (isOperator(save))
                {
                    if (save == "1/x" || save == "√")
                    {

                        value = fristob.Pop();

                        fristob.Push(unaryCalculate(save, value));
                    }
                    else if (save == "%")
                    {
                        value2 = fristob.Pop().ToString();
                        value = fristob.Peek().ToString();

                        fristob.Push(calculate(save, value, value2, 8));
                    }
                    else
                    {
                        try
                        {
                            value = fristob.Pop().ToString();
                            value2 = fristob.Pop().ToString();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            return "E";
                        }
                        // if (save == "-" || save == "÷") ;
                        fristob.Push(calculate(save, value2, value, 8));
                    }

                    //
                }

            }
            if (fristob.Count == 1)
            {
                return fristob.Pop().ToString();
            }
            else
            {
                return "E";
            }

        }
    }
}
