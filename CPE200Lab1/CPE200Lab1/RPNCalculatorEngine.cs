using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        
        private bool symbol(string str)
        {
            switch (str)
            {
                case "1/x":
                case "√":
                    return true;
            }
            return false;
        }
        
        public new string calculate(string str)
        {
            // your code here
            Stack<string> RPN = new Stack<string>();
            string[] parts = str.Split(' ');
            string num1, num2, ans;
            List<string> withoutspace = parts.ToList<string>();
            withoutspace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = withoutspace.ToArray();

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    RPN.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    try
                    {
                        num2 = RPN.Pop();
                        num1 = RPN.Pop();
                        RPN.Push(calculate(parts[i], num1, num2));

                    }
                    catch(Exception ex)
                    {
                        return "E";
                    }
                    
                }
                else if (parts[i] == "%")
                {
                    num2 = RPN.Pop();
                    num1 = RPN.Peek();
                    RPN.Push(calculate(parts[i], num1, num2));

                }
                else if (symbol(parts[i]))
                {
                    RPN.Push(calculator(parts[i], RPN.Pop()));
                }
                    
                
                
            }
            if(RPN.Count == 1)
            {
                return RPN.Pop();
            }
            else
            {
                return "E";
            }

            
            
        }
    }
}
