using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        private CalculatorEngine engine;
        Stack<string> RPN = new Stack<string>();
        public string firstOperand;
        public string secondOperand;
        public string result;


        /// <summary> Determine wheter str is not operator </summary>
        /// <param name="str"> input </param>
        /// <returns> type of operator which is integer </returns>
        
        private int isNotOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return 5;
                case "%":
                    return 2;
                case "√":
                    return 3;
                case "1/X":
                    return 4;

            }
            return 1;
        }
        
        /// <summary> get input from RPN calculator,push number to stack and separate operator then sent to calculate in CalculatorEngine  </summary>
        /// <param name="str"> input </param>
        /// <returns> result </returns>
       
        public new string Process(string str)
        {
            engine = new CalculatorEngine();
            string[] element = str.Split(' ');
            if (element.Length <= 1) return "E";
            for (int i = 0; i < element.Length; i++)
            {
                if (isNotOperator(element[i]) == 1)
                {
                    RPN.Push(element[i]);
                }
                else if (isNotOperator(element[i]) == 3)
                {
                    firstOperand = RPN.Pop();
                    result = engine.unaryCalculate(element[i], firstOperand);
                    RPN.Push(result);
                }
                else if (isNotOperator(element[i]) == 4)
                {
                    if (RPN.Peek() != 0.ToString())
                    {
                        firstOperand = 1.ToString();
                        secondOperand = RPN.Pop();
                        result = engine.calculate("÷", firstOperand, secondOperand);
                        RPN.Push(result);
                    }

                }
                else if (isNotOperator(element[i]) == 2)
                {
                    if (element[i + 1] == "+" || element[i + 1] == "-")
                    {
                        secondOperand = RPN.Pop();
                        firstOperand = RPN.Peek();
                        secondOperand = (float.Parse(firstOperand) * float.Parse(secondOperand) / 100).ToString();

                    }
                    else if (element[i + 1] == "X" || element[i + 1] == "÷")
                            {
                        secondOperand = RPN.Pop();

                        secondOperand = (float.Parse(secondOperand) / 100).ToString();
                    }
                    RPN.Push(secondOperand);
                }

                else
                {
                    if (RPN.Count > 1)
                    {
                        secondOperand = RPN.Pop();
                        firstOperand = RPN.Pop();
                        result = engine.calculate(element[i], firstOperand, secondOperand);
                        RPN.Push(result);
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
