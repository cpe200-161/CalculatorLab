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
        public string RPN_Process(string str)
        {
            Console.WriteLine("CAT");
            string firstOp, secondOp;
            //  string testString = "4 8 - ";
            string[] strArray = str.Split(' ');
            if(strArray.Length < 3)
                return "E";
            Stack rpnstack = new Stack();

            foreach (string s in strArray)
            {
                Console.WriteLine(rpnstack.Count == 1);

                if (isNumber(s))
                {
                    rpnstack.Push(s);

                }
                else if (isOperator(s))
                {
                    if (rpnstack.Count >= 2)
                    {
                        firstOp = rpnstack.Pop().ToString();
                        secondOp = rpnstack.Pop().ToString();
                        rpnstack.Push(calculate(s, secondOp, firstOp));
                    }
                    else
                    {
                        return "E";
                    }
                }
               
            }
            if (rpnstack.Count == 1)
                {
                   // Console.WriteLine("cat");
                  return Decimal.Parse(rpnstack.Peek().ToString()).ToString("G29");
                
                } 
                else
                {
                    return "E";
                }

        }
        }
    }