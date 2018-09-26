using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class CalculatorEngine //supper class
    {
        public object secondoperand { get; private set; }
        public string firstoperand { get; private set; }

        public bool isNumber(string str) //protected used by child os subclass
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
                case "1/X":
                case "√":
                    return true;
            }
            return false;
        }

        public virtual string Process(string str)
        {                      //dot operator  split=แยก
            string[] parts = str.Split(' '); //space output = array of string 1_3_+_
            if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]))) //validaling
            {    //numer                  operaetor
                return "E";
            } else
            {
                // return calculate(parts[1], parts[0], parts[2], 4); //part[1] = first operand
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
                       // result.ToString("N" + remainLength);
                        return decimal.Parse(result.ToString()).ToString("G29");
                    }
                case "1/X":
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
                        ///result.ToString("N" + remainLength);
                       
                        return decimal.Parse(result.ToString()).ToString("G29");
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
                        //// result.ToString();//*********
                      //  Console.WriteLine(result.ToString());
                        return decimal.Parse(result.ToString()).ToString("G29");
                    }
                    break;
                case "%"://****
                         //your code here
                    double result;
                    System.Collections.Stack strStack = new Stack();
                    if (operate == "%")
                    {
                        secondoperand = strStack.Pop().ToString();
                        firstoperand = strStack.Pop().ToString();
                        secondOperand = ((Convert.ToDouble(firstoperand)) * (Convert.ToDouble(secondoperand)) / 100).ToString();
                        strStack.Push(firstoperand);
                        strStack.Push(secondoperand);
                    }
                    else
                    {
                        if (isOperator(operate))
                        {
                            secondoperand = strStack.Pop().ToString();
                            firstoperand = strStack.Pop().ToString();
                            strStack.Push(calculate(operate, firstoperand, secondoperand));
                        }
                        break;
                    }
            }
            return "E";
        }

        private object calculate(string operate, string firstoperand, object secondoperand)
        {
            throw new NotImplementedException();
        }
    }
}
