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
            
            string firstOp, seconfOp;
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
                       

                        seconfOp = rpnStack.Pop().ToString();
                        if (s == "√" || s == "1/x")
                        {
                            rpnStack.Push(unaryCalculate(s,seconfOp));
                        }
                        else
                        {


                            if (s == "%")
                            {
                                firstOp = rpnStack.Peek().ToString();
                            }
                            else
                            {
                                firstOp = rpnStack.Pop().ToString();
                            }
                            rpnStack.Push(calculate(s, firstOp, seconfOp));
                        }
                            /* if (str.l<3)
                        {
                             calculate(s, firstOp, seconfOp);
                        }*/
                         
                             
                  
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
                Console.WriteLine("test");
                return "E";
            }
        }
    }
}
