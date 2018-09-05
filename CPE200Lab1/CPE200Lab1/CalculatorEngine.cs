using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    { 
        public string calculate(string operate, string firstOperand, string secondOperand="", string prev="",int maxOutputSize = 8)
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
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    double x0, z0;
                    string y0;


                    switch (prev)
                    {
                        case "+":
                            x0 = Convert.ToDouble(firstOperand);
                            z0 = Convert.ToDouble(secondOperand);
                            y0 = (x0 + ((x0 * z0 )/ 100)).ToString();
                            return y0;

                        case "-":
                            x0 = Convert.ToDouble(firstOperand);
                            z0 = Convert.ToDouble(secondOperand);
                            y0 = (x0 - ((x0 * z0) / 100)).ToString();
                            return y0;

                        case "X":
                            x0 = Convert.ToDouble(firstOperand);
                            z0 = Convert.ToDouble(secondOperand);
                            y0 = (x0 * ((x0 * z0) / 100)).ToString();
                            return y0;

                        case "÷":
                            x0 = Convert.ToDouble(firstOperand);
                            z0 = Convert.ToDouble(secondOperand);
                            if(z0 != 0)
                            {
                                y0 = (x0 * ((x0 * z0 )/ 100)).ToString();
                            return y0;
                            }
                            return "Error";
                            
                    }
                    
                    break;
                case "√":
                    double x = Math.Sqrt(Convert.ToDouble(firstOperand));
                    string y = x.ToString();
                    
                    if (y.Length > 8)
                    {
                        y = string.Format("{0:F6}", x);
                        x = Convert.ToDouble(y);
                        return x.ToString();
                    }
                    else
                    {
                        return x.ToString();
                    }
                    

                case "1/x":

                    double x1, z1;
                    string[] y1;
                    int lengthRemain;

                    x1 = Convert.ToDouble(firstOperand);
                    if(x1 != 0) {
                        z1 = 1 / x1;
                        y1 = z1.ToString().Split('.');

                        if (y1[0].Length > maxOutputSize)
                        {
                            return "E";
                        }

                        lengthRemain = maxOutputSize - y1[0].Length - 1;
                        return z1.ToString("N" + lengthRemain);
                        
                    }
                    break;
                    

            }
            return "E";
        }
    }
}
