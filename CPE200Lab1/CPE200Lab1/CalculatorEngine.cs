using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : TheCalculatorEngine
    {

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if (parts.Length >= 4)
            {
                if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]) && isModOpreator(parts[3]))
                {
                    return modCalculate(parts[1], parts[0], parts[2], 4);
                }
            }
            if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]))
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }
            else if (isNumber(parts[0]) && thisisOperator(parts[1]))
            {
                return calculate(parts[1], parts[0], 4);
            }

            else
            {
                return "E";
            }
        }



    }
}