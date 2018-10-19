using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatoreEngine
    {
        string result;
        string secondNum;
        string firstNum;
        public string Process(string str)
        {

            string[] parts = str.Split(' ');
            Stack<string> Set = new Stack<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    Set.Push(parts[i]);
                }
                if (isOperator(parts[i]))
                {
                    try
                    {
                        if (parts[i] == "1/x" || parts[i] == "√")
                        {
                            firstNum = Set.Pop();
                            Set.Push(calculate(parts[i], firstNum));
                        }
                        else if (parts[i] == "%" && Set.Count > 1)
                        {
                            secondNum = Set.Pop();
                            firstNum = Set.Peek();
                            Set.Push(calculate(parts[i], firstNum, secondNum));
                        }
                        else if (parts[i] == "%")
                        {
                            firstNum = Set.Pop();
                            Set.Push(calculate(parts[i], firstNum, 1.ToString()));
                        }
                        else if (Set.Count < 1)
                        {
                            return "E";
                        }
                        else
                        {
                            secondNum = Set.Pop();
                            firstNum = Set.Pop();
                            Set.Push(calculate(parts[i], firstNum, secondNum));
                        }
                    }
                    catch(Exception e)
                    {
                        return "E";
                    }
                    
                }

            }

            result = Set.Peek();
            if (Set.Count != 1)
            {
                return "E";
            }
            return result;

        }
    }
}
