using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            if (str[str.Length - 1] == ' ') str=str.Substring(0,str.Length-1);
            Stack<string> NumStack=new Stack<string>();
            string[] parts = str.ToString().Split(' ');
            int i = 0;
            while (i<parts.Length)
            {
                string firstOperand="", secondOperand="";
                if (isOperator(parts[i]))
                {
                    if (NumStack.Count >= 2)
                    {
                        try
                        {
                            if (isNumber(NumStack.Peek()))
                            {
                                secondOperand = NumStack.Pop();
                                if (isNumber(NumStack.Peek()))
                                {
                                    firstOperand = NumStack.Pop();
                                    string result = calculate(parts[i], firstOperand, secondOperand);
                                    NumStack.Push(result);
                                }
                            }
                        }
                        catch(Exception)
                        {
                            return "E";
                        }
                    }
                    else
                    {
                        return "E";
                    }
                }
                else if(isNumber(parts[i]))
                {
                    NumStack.Push(parts[i]);
                }
                i++;
            }
            if ((NumStack.Count == 1)&&(parts.Length>2))return NumStack.Peek();
            else return "E";
        }
    }
}
