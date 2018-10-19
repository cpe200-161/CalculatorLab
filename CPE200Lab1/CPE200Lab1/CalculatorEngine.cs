using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : BasicCalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;

        public void setFirstOperand(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }
        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }

        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            List<string> partsWithoutSpace = parts.ToList();
            partsWithoutSpace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = partsWithoutSpace.ToArray();

            if (parts.Length == 2)
            {
                if (isNumber(parts[0]) && isUnaryOperator(parts[1]))
                {
                    setFirstOperand(parts[0]);
                    return calculate(parts[1], firstOperand.ToString());
                }
                else if(isNumber(parts[0]) && parts[1] == "%")
                {
                    setFirstOperand(parts[0]);
                    return calculate(parts[1], "1", firstOperand.ToString());
                }
                else
                {
                    return "E";
                }
            }
            else if (parts.Length == 3)
            {
                if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]))
                {
                    setFirstOperand(parts[0]);
                    setSecondOperand(parts[2]);
                    return calculate(parts[1], firstOperand.ToString(), secondOperand.ToString());
                }
                else 
                {
                    return "E";
                }
            }
            else if (parts.Length == 4)
            {
                if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]) && parts[3] == "%")
                {
                    setFirstOperand(parts[0]);
                    setSecondOperand(parts[2]);
                    string re1 = calculate(parts[3], firstOperand.ToString(), secondOperand.ToString());
                    return calculate(parts[1], firstOperand.ToString(), re1);
                }
                else if (isNumber(parts[0]) && isUnaryOperator(parts[1]) && isOperator(parts[2]) && isNumber(parts[3]))
                {
                    setFirstOperand(parts[0]);
                    setSecondOperand(parts[3]);
                    string re1 = calculate(parts[1], firstOperand.ToString());
                    return calculate(parts[2], re1, secondOperand.ToString());
                }
                else if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]) && isUnaryOperator(parts[3]))
                {
                    setFirstOperand(parts[0]);
                    setSecondOperand(parts[2]);
                    string re1 = calculate(parts[3], secondOperand.ToString(), 4);
                    return calculate(parts[1], firstOperand.ToString(), re1);
                }
                else
                {
                    return "E";
                }
            }
            else if (parts.Length == 5)
            {
                if (isNumber(parts[0]) && isUnaryOperator(parts[1]) && isOperator(parts[2]) && isNumber(parts[3]) && isUnaryOperator(parts[4]))
                {
                    string re1 = calculate(parts[1], parts[0]);
                    string re2 = calculate(parts[4], parts[3]);
                    return calculate(parts[2], re1, re2);
                }
                else if (isNumber(parts[0]) && isUnaryOperator(parts[1]) && isOperator(parts[2]) && isNumber(parts[3]) && parts[4] == "%")
                {
                    string re1 = calculate(parts[1], parts[0]);
                    string re2 = calculate(parts[4], re1, parts[3]);
                    return calculate(parts[2], re1, re2);
                }
                else
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
}
