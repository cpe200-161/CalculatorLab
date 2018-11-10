using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    //calculatorEngine model;
    public class CalculatorEngine : BasicCalculatorEngine 
    {
        protected double firstOperand;
        protected double secondOperand;

        public void setFirst(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }
        public void setSecond(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }
        /// <summary>
        /// split string to number and operator then calculate
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            try
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }catch(Exception ex)
            {
                return "E";
            }

        }    }
}
