using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        private bool isOperator(string str)
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

        public string Process(string str)
        {
            // your code here
            string[] one_ope = str.Split(' ');
            if (one_ope.Length < 2) return "E";
            Stack<string> operation = new Stack<string>();
            int i = 0;
            while (i < one_ope.Length) {
            }
           
            
            
            return "E";
        }
    }
}
