using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : TheCalculatorEngine
    {
        public bool isNumber(string str)
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
                    return true;
            }
            return false;
        }
        public bool thisisOperator(string str)
        {
            switch (str)
            {
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }

        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            if (parts.Length >= 4)
            {
                if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]) && isOperator(parts[3]))
                {
                    return ModCalculate(parts[1], parts[0], parts[2], 4);
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
