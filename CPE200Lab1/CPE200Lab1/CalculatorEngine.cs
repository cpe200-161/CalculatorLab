using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            var _first = Convert.ToDouble(firstOperand);
            var _second = Convert.ToDouble(secondOperand);

            switch (operate)
            {
                case "+":
                    return (_first + _second).ToString();
                case "-":
                    return (_first - _second).ToString();
                case "X":
                    return (_first * _second).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (_first / _second);
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
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    //your code here
                    return (_first + ((_second * _first) / 100)).ToString();
                case "1/x":
                    if (secondOperand != "0")
                    {
                        return (1 / _first).ToString().Substring(0,8);
                    }
                    break;
                case "√":
                    return Math.Sqrt(_second).ToString().Substring(0,8);
            }
            return "E";
        }

    }
}
