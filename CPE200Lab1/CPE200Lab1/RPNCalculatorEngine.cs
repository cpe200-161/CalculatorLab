using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine 
        //isNumber is unncton in Calulatorengine
    {
        public override string Process(string str)
        {
            //string testString = "4 8 -";
            //Console.WriteLine("Aun Yong");
            string Firstoperand, Secondoperand;
            string[] strArr = str.Split(' ');


                System.Collections.Stack rpnStack = new Stack();
                foreach (string s in strArr)
                {
                    Console.WriteLine(s);
                    if (isNumber(s))
                    {

                        rpnStack.Push(s); //adding somthing to stack

                        /*if (isNumber(s))
                        {
                            rpnStack.Push(s);
                        }*/
                        if (isOperator(s))
                        {

                        }
                        if (s == "√" || s == "1/X")
                        {
                            Firstoperand = rpnStack.Pop().ToString();
                            rpnStack.Push(Firstoperand);
                            rpnStack.Push(unaryCalculate(s, Firstoperand));
                            Console.WriteLine(rpnStack.Count);
                        }
                    /*if (s == "%")
                     {
                         Secondoperand = rpnStack.Pop().ToString();
                         Firstoperand = rpnStack.Pop().ToString();
                         Secondoperand = ((Convert.ToDouble(Firstoperand)) * (Convert.ToDouble(Secondoperand)) / 100).ToString();
                         rpnStack.Push(Firstoperand);
                         rpnStack.Push(Secondoperand);
                     }
                     else
                     {
                         if (isOperator(s))
                         {
                             Secondoperand = rpnStack.Pop().ToString();
                             Firstoperand = rpnStack.Pop().ToString();
                             rpnStack.Push(calculate(s, Firstoperand, Secondoperand));
                         }
                     }**/

                    }/*s != "%"*/
                    if (isOperator(s)) //stack first in , last out
                    {
                        if (rpnStack.Count > 1)
                        {
                            Secondoperand = rpnStack.Pop().ToString();
                            Firstoperand = rpnStack.Pop().ToString();
                            rpnStack.Push(calculate(s, Firstoperand, Secondoperand));
                        }
                        else
                        {
                            return "E";
                        }
                    }
                }
          /*
                foreach (string s in strArr)
                {

                    if (isNumber(s))
                    {
                        rpnStack.Push(s);
                    }
                    if (isOperator(s))
                    {

                    }
                    if (s == "√" || s == "1/X")
                    {
                        Firstoperand = rpnStack.Pop().ToString();
                        rpnStack.Push(Firstoperand);
                        rpnStack.Push(unaryCalculate(s, Firstoperand));
                        Console.WriteLine(rpnStack.Count);
                    }
                }
         */   
                        
            if (rpnStack.Count == 1 && strArr.Length >= 3)
            {
                return decimal.Parse(rpnStack.Peek().ToString()).ToString("G29");
            }
            else
            {
                return "E";
            }
                        
        }
    }
}
