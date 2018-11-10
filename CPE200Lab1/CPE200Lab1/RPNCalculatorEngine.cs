using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//model
namespace CPE200Lab1
{
    /// <summary>
    /// class ลูกของ CalculatorEngine จะใช้คำนวนแบบ เครื่องหมายอยู่ขางหลัง
    /// </summary>
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {


        /// <summary>
        /// แยกออกมาจาก calculate เพราะ มี่ input เหมือนกันแต่คำนวณต่างกัน
        /// </summary>
        /// <param name="operate"></param>
        /// <param name="firstOperand"></param>
        /// <param name="secondOperand"></param>
        /// <returns></returns>
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
        /// <summary>
        /// คำนวณ input แบบ RPN
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
                    // catch exception if number can't push or pop
                    try
                    {
                        
                        switch (parts[i])
                        {
                            case "1/x":
                            case "√":
                                number.Push(calculate(parts[i] , number.Pop().ToString() , 8));
                                break;
                            case "+":
                            case "-":
                            case "X":
                            case "÷":
                                string second = number.Pop().ToString();
                                string first = number.Pop().ToString();
                                number.Push(calculate(parts[i] , first , second));
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
