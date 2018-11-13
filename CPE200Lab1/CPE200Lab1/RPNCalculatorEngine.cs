using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public TheCalculatorEngine engine;
        Stack<string> RPN = new Stack<string>();
        public string firstOperand;
        public string secondOperand;
        public string result;



        private int isNotOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return 2;
                case "%":
                    return 3;
                case "√":
                    return 4;
                case "1/X":
                    return 5;

            }
            return 1;
        }

        public new string Calculate(string str)
        {
             engine = new TheCalculatorEngine();
             string[] element = str.Split(' ');
            if (element.Length <= 1)
            {
                return "E";
            }
            for (int i = 0; i < element.Length; i++)
            {
                if (isNotOperator(element[i]) == 1)
                {
                    RPN.Push(element[i]);
                }

                else if (isNotOperator(element[i]) == 4)
                {
                    try
                    {
                        firstOperand = RPN.Pop();
                        result = engine.Calculate(element[i], firstOperand);
                        RPN.Push(result);
                    }
                    catch
                    {
                        return "E";
                    }
                }
                else if (isNotOperator(element[i]) == 3)
                {
                    try
                    {
                        if (element.Length == 2)
                        {
                            secondOperand = RPN.Pop();
                            secondOperand = (float.Parse(secondOperand) * 0.01).ToString();
                        }
                        else if (element[i + 1] == "+" || element[i + 1] == "-")
                        {
                            secondOperand = RPN.Pop();
                            firstOperand = RPN.Peek();
                            secondOperand = (float.Parse(firstOperand) * float.Parse(secondOperand) * 0.01).ToString();

                        }
                        else if (element[i + 1] == "X" || element[i + 1] == "÷")
                        {
                            secondOperand = RPN.Pop();
                            secondOperand = (float.Parse(secondOperand) * 0.01).ToString();
                        }
                        RPN.Push(secondOperand);
                    }
                    catch
                    {
                      return "E";
                    }
                }
                else
                {

                    if (RPN.Count > 1)
                    {
                        try
                        {
                            secondOperand = RPN.Pop();
                            firstOperand = RPN.Pop();

                            if (isNotOperator(element[i]) == 5) //1/X
                            {
                                element[i] = "÷";
                                firstOperand = 1.ToString();

                            }
                            result = engine.Calculate(element[i], firstOperand, secondOperand);
                            RPN.Push(result);
                        }
                        catch
                        {
                            return "E";
                        }
                    }
                    else
                    {
                        return "E";
                    }

                }
            }
            if (RPN.Count == 1)
            {
                result = RPN.Pop().ToString();
                return result;
            }
            else
            {
                return "E";
            }
        }
    }
}