using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                    return true;
            }
            return false;
        }
        public bool isUnaryOperator(string str)
        {
            switch (str)
            {
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            List<string> partsWithoutSpace = parts.ToList();
            partsWithoutSpace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = partsWithoutSpace.ToArray();

            if (parts.Length == 2)
            {
                if (isNumber(parts[0]) && isUnaryOperator(parts[1]))
                {
                    return unaryCalculate(parts[1], parts[0]);
                }
                else if(isNumber(parts[0]) && parts[1] == "%")
                {
                    return calculate(parts[1], "1", parts[0]);
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
                    return calculate(parts[1], parts[0], parts[2]);
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
                    string re1 = calculate(parts[3], parts[0], parts[2]);
                    return calculate(parts[1], parts[0], re1);
                }
                else if (isNumber(parts[0]) && isUnaryOperator(parts[1]) && isOperator(parts[2]) && isNumber(parts[3]))
                {
                    string re1 = unaryCalculate(parts[1], parts[0]);
                    return calculate(parts[2], re1, parts[3]);
                }
                else if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]) && isUnaryOperator(parts[3]))
                {
                    string re1 = unaryCalculate(parts[3], parts[2], 4);
                    return calculate(parts[1], parts[0], re1);
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
                    string re1 = unaryCalculate(parts[1], parts[0]);
                    string re2 = unaryCalculate(parts[4], parts[3]);
                    return calculate(parts[2], re1, re2);
                }
                else if (isNumber(parts[0]) && isUnaryOperator(parts[1]) && isOperator(parts[2]) && isNumber(parts[3]) && parts[4] == "%")
                {
                    string re1 = unaryCalculate(parts[1], parts[0]);
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
            //else
            //{
            //    return calculate(parts[1], parts[0], parts[2], 4);
            //}

        }
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                       
                    double result;
                    string[] parts;
                    int remainLength;

                    result = Math.Sqrt(Convert.ToDouble(operand));
                    // split between integer part and fractional part
                    parts = result.ToString().Split('.');
                    // if integer part length is already break max output, return error
                    if (parts[0].Length > maxOutputSize)
                    {
                        return "E";
                    }
                    // calculate remaining space for fractional part.
                    remainLength = maxOutputSize - parts[0].Length - 1;
                    // trim the fractional part gracefully. =
                    return result.ToString("G" + remainLength);

                    }
                case "1/x":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("G" + remainLength);
                    }
                    break;
            }
            return "E";
        }

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =

                        return result.ToString("G" + remainLength);
                    }
                    break;
                case "%":
                    double second = Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100;
                    return second.ToString();
                    //your code here
                    //break;
            }
            return "E";
        }
    }
}
