using System;
using System.Collections;
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
            Stack RPNcalc = new Stack();

            string first, second, result;
            string[] parts = str.Split(' ');           

            List<string> partsWithoutSpace = parts.ToList();
            partsWithoutSpace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = partsWithoutSpace.ToArray();


                foreach (string element in parts)
                {
                    if (isNumber(element))
                    {
                        RPNcalc.Push(element);
                    }
                    //else if (isUnaryOperator(element) || (isOperator(element) && RPNcalc.Count >= 2))
                    else if (isUnaryOperator(element) || isOperator(element))
                    {
                    try
                    {
                        if (element == "%")
                        {
                            second = RPNcalc.Pop().ToString();
                            first = RPNcalc.Peek().ToString();
                            result = calculate(element, first, second);
                            RPNcalc.Push(result);
                        }
                        else if (element == "√" || element == "1/x")
                        {
                            second = RPNcalc.Pop().ToString();
                            result = unaryCalculate(element, second);
                            RPNcalc.Push(result);
                        }
                        else
                        {
                            second = RPNcalc.Pop().ToString();
                            first = RPNcalc.Pop().ToString();
                            result = calculate(element, first, second);
                            RPNcalc.Push(result);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("An error occurred : " + ex.ToString());
                        return "E";
                    }
                }
                    //else
                    //{
                    //    return "E";
                    //}
                }
            if (RPNcalc.Count == 1)
            {
                return RPNcalc.Pop().ToString();
            }
            else
            {
                return "E";
            }

        }
    }
}
