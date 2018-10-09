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

        protected bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            } else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }

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
                        string strResult;

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
                        strResult = result.ToString();
                        if (strResult.Contains("."))
                        {
                            strResult = strResult.TrimEnd('0');
                            if (strResult.EndsWith("."))
                            {
                                strResult = strResult.TrimEnd('.');
                            }
                        }
                        return strResult;
                    }
                case "1/x":
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                        string strResult="";
                        try
                        {
                            result = Convert.ToDouble(calculate("÷", "1", operand));
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
                            for(int i=0 ; i < maxOutputSize-parts[0].Length-1 ; i++)
                            {
                                strResult += "#";
                            }
                            return result.ToString("0." + strResult);
                        }
                        catch (Exception)
                        {
                            return "E";
                        }
                        break;
                    }   
            }
           return "";
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
                   
                        double result;
                        string[] parts;
                        int remainLength;
                        string strResult="";
                    try
                    { 
                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        if(secondOperand == "0")
                        {
                            throw new Exception();
                        }
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
                        for (int i = 0; i < maxOutputSize - parts[0].Length-1; i++)
                        {
                            strResult += "#";
                        }
                        return result.ToString("0."+strResult);
                    }
                    catch(Exception)
                    {
                        return "E";
                    }
                    break;
                case "%":
                    //your code here
                    break;
            }
            return "E";
        }
    }
}
