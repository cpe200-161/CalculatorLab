using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine 
    {
        String memory;
        public string Process(string str)
        {
            Stack<string> Stacknumber = new Stack<string>();
            string[] parts = str.Split(' ');
            bool beforeopereter=false,checkmemory=false,checkoperate=false;
            foreach (string number in parts)
            {
                if (isOperator(number))
                {
                    string first, second;
                    if (Stacknumber.Count < 2 && checkoperate == false)
                    {
                        return "E";
                    }
                    first = Stacknumber.Pop();
                    second = Stacknumber.Pop();
                    Stacknumber.Push(calculate(number, second, first));
                    beforeopereter = true;
                }
                else if(isNumber(number)) 
                {
                    Stacknumber.Push(number);
                }
                else if(number == "√")
                {
                    string first;
                    first = Stacknumber.Pop();
                    checkoperate = true;
                    beforeopereter = true;
                    Stacknumber.Push(unaryCalculate(number, first));
                }
                else if (number== "1/x")
                {
                    string first;
                    first = Stacknumber.Pop();
                    checkoperate = true;
                    beforeopereter = true;
                    Stacknumber.Push(unaryCalculate(number,first));
                }
                else if (number == "%")
                {
                    beforeopereter = true;
                    string first, second;
                    first = Stacknumber.Pop();
                    second = Stacknumber.Pop();
                    Stacknumber.Push(calculate(number, second, first));
                }
                
                switch (number)
                {
                    case "MC":
                        memory = "";
                        beforeopereter = true;
                        checkmemory = true;
                        break;
                    case "MR":
                        checkmemory = true;
                        return memory;
                        break;
                    case "MS":
                        memory = Stacknumber.Pop();
                        Stacknumber.Push(memory);
                        checkmemory = true;
                        break;
                    case "M+":
                        String kebmem;
                        checkmemory = true;
                        kebmem = (Convert.ToDouble(Stacknumber.Pop()) + Convert.ToDouble(memory)).ToString();
                        beforeopereter = true;
                        memory = kebmem;
                        break;
                    case "M-":
                        String kebmeme;
                        checkmemory = true;
                        kebmeme = (Convert.ToDouble(memory) - Convert.ToDouble(Stacknumber.Pop())).ToString();
                        beforeopereter = true;
                        memory = kebmeme;
                        break;
                }

            }
            if (Stacknumber.Count > 1 || beforeopereter == false)
            {
                return "E";
            }
            
            if(checkmemory == true)
            {
                return "0";
            }
            else
            {
                return Stacknumber.Pop();
            }
            
        }
    }
}
