using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        string result;
        string secondNum;
        string firstNum;

        /// <summary>
        /// input equation for calculate
        /// </summary>
        /// <param name="str"> equation for calculate </param>
        /// <returns> result if is not error case and error if error case </returns>

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
                                Set.Push(unaryCalculate(parts[i], firstNum));
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
                        else
                        {
                                secondNum = Set.Pop();
                                firstNum = Set.Pop();
                                Set.Push(calculate(parts[i], firstNum, secondNum));
                        }   
                    }
                    catch (Exception e)
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
