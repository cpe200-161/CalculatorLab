using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        protected Stack<string> myStack = new Stack<string>();
        public string calculate(string oper)
        {
            //your code here
            string[] parts = oper.Split(' ');
            for(int i=0; i<parts.Length; i++)
            {
                if (isNumber(parts[i]) == true)
                {
                    myStack.Push(parts[i]);
                }
                else if (isOperator(parts[i]) == true)
                {
                    if (myStack.Count < 2)
                    {
                        return "E";
                    }
                    else
                    {
                        string secondOperand = myStack.Pop();
                        string firstOperand = myStack.Pop();
                        string result = calculate(parts[i], firstOperand, secondOperand);
                        myStack.Push(result);
                    }
                }
            }
            if(myStack.Count == 1)
            {
                return myStack.Pop();
            }
            else
            {
                return "E";
            }
            
        }

        public string ProcessUnary(string operate, string str)
        {
            string[] parts = str.Split(' ');
            int i = parts.Length - 1;
            parts[i] = calculate(operate, parts[i]);
            string AllString = parts[0];
            for(int j = 1; j < parts.Length; j++)
            {
                AllString += " " + parts[j];
            }
            return AllString;
        }

        public string ProcessMemory(string operate, string str, string M_Number)
        {
            double memoryNumber = Convert.ToDouble(M_Number);
            string[] parts = str.Split(' ');
            int i = parts.Length - 1;
            switch (operate)
            {
                case "MR":
                    break;
                case "MC":
                    memoryNumber = 0;
                    break;
                case "MS":
                    memoryNumber = Convert.ToDouble(parts[i]);
                    break;
                case "M+":
                    memoryNumber = memoryNumber + Convert.ToDouble(parts[i]);
                    break;
                case "M-":
                    memoryNumber = memoryNumber - Convert.ToDouble(parts[i]);
                    break;
            }
            return memoryNumber.ToString();
        }

        public string ProcessPercent(string str)
        {
            string[] parts = str.Split(' ');
            int i = parts.Length - 1;
            if(parts.Length >= 2 && isNumber(parts[i]) && isNumber(parts[i-1]))
            {
                parts[i] = ((Convert.ToDouble(parts[i]) / 100) * Convert.ToDouble(parts[i - 1])).ToString();
                string AllString = parts[0];
                for (int j = 1; j < parts.Length; j++)
                {
                    AllString += " " + parts[j];
                }
                return AllString;
            }
            else
            {
                return "E";
            }
            
        }
    }
}
