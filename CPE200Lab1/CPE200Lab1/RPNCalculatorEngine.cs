using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
<<<<<<<<< Temporary merge branch 1
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public override string Process(string str)
        {
            Stack<string> operend = new Stack<string>();
            string[] parts = str.Split(' ');
            string Re_salt = "0";
            for (int i = 0; i < parts.Length; i++)
            {
                
                    if (isNumber(parts[i]))
                    {
                    operend.Push(parts[i]);
                    }
                else
                if (isOperator(parts[i]))
                {
                    string popkorn1;
                    string popkorn2;

                    if (operend.Count() > 1)
                    {
                        popkorn2 = operend.Pop();
                        popkorn1 = operend.Pop();
                        
                    }
                    else
                    {
                        return "E";
                    }
                    Re_salt = calculate(parts[i], popkorn1, popkorn2, 4);
                    operend.Push(Re_salt);
                }
                
            }
            if(parts.Length<=1)
                return "E";
            operend.Pop();
            if (operend.Count() != 0)
                return "E";
            return Re_salt;
        }
    }
    
}

