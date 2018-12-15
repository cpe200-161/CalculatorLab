using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class SimpleCalculatorEngine : CalculatorEngine
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

        public string calculate(string operate)
        {
            switch (operate)
            {
                case "+":
                    return (firstOperand + secondOperand).ToString();
                case "-":
                    return (firstOperand - secondOperand).ToString();
                case "X":
                    return (firstOperand * secondOperand).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != 0)
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = firstOperand / secondOperand;
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        /*if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }*/
                        // calculate remaining space for fractional part.
                        remainLength = 4;
                        // trim the fractional part gracefully. =
                        try
                        {
                            if (remainLength < parts[1].Count()) return result.ToString("N" + remainLength);
                            else return result.ToString();
                        }
                        catch (IndexOutOfRangeException)
                        {
                            return result.ToString();
                        }
                    }
                    break;
            }
            return "E";
        }
    }
}
