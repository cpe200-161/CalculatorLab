using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string calculatePersent (string operate ,string firstOperand,string secondOperand)
        {
            switch(operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                case "-":

                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                case "X":

                    return (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                case "/":

                    return (100 * Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
            }
            return "E";
        }
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            Stack number = new Stack();
            try
            {
                List<string> withoutspace = parts.ToList<string>();
                withoutspace.RemoveAll(p => string.IsNullOrEmpty(p));
                parts = withoutspace.ToArray();
            }catch(Exception ex)
            {
                return "E";
            }

            for(int i = 0;i < parts.Length ; i++)
            {
                if (isNumber(parts[i]))
                {
                    number.Push(parts[i]);
                }
                if (isOperator(parts[i]))
                {
                    try
                    {
                        
                        switch (parts[i])
                        {
                            case "1/x":
                            case "√":
                                number.Push(unaryCalculate(parts[i] , number.Pop().ToString(),8));
                                break;
                            case "+":
                            case "-":
                            case "X":
                            case "÷":
                                string second = number.Pop().ToString();
                                string first = number.Pop().ToString();
                                number.Push(calculate(parts[i],first , second));
                                break;
                            case "%":
                                if(i == (parts.Length - 1) || number.Count == 1 || isNumber(parts[i+1]))
                                {
                                    number.Push(calculate("%", number.Pop().ToString(), " "));

                                }
                                else
                                if(isOperator(parts[i+1]))
                                {
                                    string secondO = number.Pop().ToString();
                                    string firstO = number.Pop().ToString();
                                    number.Push(calculatePersent(parts[i + 1],firstO,secondO));
                                    i++;
                                }
                                break;

                        }

                    }catch (Exception ex)
                    {
                        return "E";
                    }
                    
                }
            }
            if(number.Count > 1)
                {
                    return "E";
                }
            return number.Pop().ToString();
        }
    }
}
