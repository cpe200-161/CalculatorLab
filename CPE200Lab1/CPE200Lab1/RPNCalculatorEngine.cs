using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RpnCalculatorEngine:CalculatorEngine
    {
        public string Process(string str)
        {
            string[] strArray = str.Split(' ');
            if (str.Length < 3) return "E";
            Stack rpnStack = new Stack();
             string firstOp, secOp;

            foreach (string s in strArray)
            {
                if (isNumber(s))
                {
                    rpnStack.Push(s);
                }

                else if (isOperator(s))
                {
                    
                    if (s == "1/x" || s == "√")
                    {
                        string cal;
                        
                        cal = rpnStack.Pop().ToString();
                        
                        return unaryCalculate(s,cal).ToString();

                    }

                    if (rpnStack.Count > 1)
                    {
                        if (s == "%")
                        {
                            secOp = rpnStack.Pop().ToString();
                            firstOp = rpnStack.Peek().ToString();
                           return (calculate(s,firstOp,secOp));
                        }
                        else
                        {
                        secOp = rpnStack.Pop().ToString();
                        firstOp = rpnStack.Pop().ToString();
                        }
                    }
                    else
                    {
                        return "E";
                    }
                   rpnStack.Push(calculate(s, firstOp, secOp));
                }
                
            }


            if (rpnStack.Count == 1)
            {
                return rpnStack.Peek().ToString();
            }
     
            else
            {
                return "E";
            }
            
        }
        }
    }

