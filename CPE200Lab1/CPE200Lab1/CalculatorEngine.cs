using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : SimpleCal

    {
        /*
        protected bool isNumber(string str)
        {
            double retNum;

            return Double.TryParse(str, out retNum);
        }


        protected bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }

      /*  public string Calculate(string str)
        {
            //Split input string to multiple parts by space
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            //As long as we have more than one part
            while (parts.Count > 1)
            {
                //Check if the first three is ready for calcuation
                if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
                {
                    return "E";
                }
                else
                {
                    //Calculate the first three
                    result = Calculate(parts[1], parts[0], parts[2], 4);
                    //Remove the first three
                    parts.RemoveRange(0, 3);
                    // Put back the result
                    parts.Insert(0, result);
                }
            }
            return parts[0];
        } */

        public string calculate(string operand, string firstoperand,int maxOutputSize = 8)
        {
            switch (operand)
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
                        return result.ToString("N" + remainLength);
                    }
                case "1/x":
                    if (operand != "0")
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
                        return result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }

        public string calculate(string operand, string firstoperand, string secondoperand ,int maxOutputSize=8)
        {
            switch (operand)
            {
                case "+":
                    return (Convert.ToDouble(firstoperand) + Convert.ToDouble(secondoperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstoperand) - Convert.ToDouble(secondoperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstoperand) * Convert.ToDouble(secondoperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondoperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstoperand) / Convert.ToDouble(secondoperand));
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
                        // return result.ToString("N" + remainLength);
                        return decimal.Parse(result.ToString()).ToString("G29");

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
