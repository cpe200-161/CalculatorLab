using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine 
    {

        public string Process(string str)
        {
            Console.WriteLine(" ");
            string firstOp, seccondOp;        
            string[] strArray = str.Split(' ');
            string[] parts = str.Split(' ');
            if (strArray.Length == 1)  return "E";
            Stack rpnStack = new Stack();

            foreach (string s in strArray)
            {
                Console.WriteLine(s);
                if (isNumber(s))
                {
                    rpnStack.Push(s);
                }
                else if (isOperator(s))
                {
                    if(rpnStack.Count > 1)
                    {
                        seccondOp = rpnStack.Pop().ToString();
                        firstOp = rpnStack.Pop().ToString();
                        rpnStack.Push(calculate(s, firstOp, seccondOp));
                    }
                    else
                    {
                        return "E";
                    }
                }                         
            }
            if (rpnStack.Count==1)
            {
                return decimal.Parse(rpnStack.Peek().ToString()).ToString("G29");
            }
           else
            {
                return "E";
            }                 
           
        }

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
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
                            //return result.ToString("N" + remainLength);
                            return result.ToString("G29");
                        }
                        break;
                    case "%":
                        return (((Convert.ToDouble(secondOperand)) / 100) * Convert.ToDouble(firstOperand)).ToString();
                }
                return "E";
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
                        //return result.ToString("N" + remainLength);
                        return result.ToString("G29");
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
                        // return result.ToString("N" + remainLength);
                        return result.ToString("G29");
                    }
                    break;
            }
            return "E";
        }
    }
   
}
