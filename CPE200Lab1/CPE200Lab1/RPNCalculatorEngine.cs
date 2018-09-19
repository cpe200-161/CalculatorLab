using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine 
    {
        public override string Process(string str)
        {
            //string testString = "4 8 -";
            
            string firstOp, seconfOp,operate="";
            string[] StrArr = str.Split(' ');
            
            Stack rpnStack = new Stack();
            foreach (String s in StrArr)
            {
                Console.Write(s);
                Console.WriteLine(isOperator(s));
                if (isNumber(s))
                {
                    rpnStack.Push(s);
                    
                }
                else if (isOperator(s))
                {
                    //if (rpnStack.Count >= 2)
                    //{
                    try
                    {
                        if (s == "%")
                        {
                            opera te = s;
                        }
                        else
                        {

                            seconfOp = rpnStack.Pop().ToString();
                            firstOp = rpnStack.Pop().ToString();
                            if (operate == "%")
                            {
                                rpnStack.Push(calculate(operate, firstOp, seconfOp, s));
                                operate = "";
                            }
                            else
                            {

                                rpnStack.Push(calculate(s, firstOp, seconfOp));
                            }



                        }
                       
                        //}
                    } catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace.ToString());
                        return "E";
                    }
                    
                   
           
                    //else
                    //{
                    //    return "E";
                    //}
                }
                
               
                
            }
            if (rpnStack.Count ==1 && StrArr.Length >=3 )
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
