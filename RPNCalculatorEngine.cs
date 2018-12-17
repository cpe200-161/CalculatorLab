using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : SimpleCalculatorEngine
    {
        public  string Process(string str)
        {
            if (str == "" || str == null)
            {
                return "E";
            }

            Stack<string> myStack = new Stack<string>();
            string[] parts = str.Split(' ');
            string result;
            string mun1, mun2;

            if ((parts.Length == 1 || parts.Length == 2) && parts[0] != "0")
            {
                return "E";
            }

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }
                
                else if (isOperator(parts[i]))
                {
                    try
                        
                    {
                        mun2 = myStack.Pop();
                        mun1 = myStack.Pop();
                        result = calculate(parts[i], mun1, mun2, 4);
                    }
                    catch(Exception)
                    {
                        return "E";
                    }
                    
                    myStack.Push(result);
                    
                    
                    }
                
                    else if (parts[i]=="++")
                    {
                        return "E";
                    }
             
                }
            
            if(myStack.Count() == 1)
            {
                result = myStack.Pop();
                return result;
            }
            else
            {
                return "E";
            }
            
        }
    }
    
}
