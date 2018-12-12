using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : NewCalculatorEngine
    {
        protected bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        protected bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }

       public string calculate(string str)
        {
            //Split input string to multiple parts by space
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            //As long as we have more than one part
            while(parts.Count > 1)
            {
                //Check if the first three is ready for calcuation
                if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
                {
                    return "E";
                }
                
                else
                {
                    //Calculate the first three
                    result = calculate(parts[1], parts[0], parts[2], 4);
                    //Remove the first three
                    parts.RemoveRange(0, 3);
                    // Put back the result
                    parts.Insert(0, result);

                }
            }

                return parts[0];
        }
       