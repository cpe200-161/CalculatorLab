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
            bool beforeopereter=false,checkmem=false,checkoper=false;
            foreach (string number in parts)
            {
                if (isOperator(number))
                {
                    string first, second;
                    if (Stacknumber.Count < 2 && checkoper == false)
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
                    checkoper = true;
                    beforeopereter = true;
                    Stacknumber.Push(unaryCalculate(number, first));
                }
                else if (number== "1/x")
                {
                    string first;
                    first = Stacknumber.Pop();
                    checkoper = true;
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
                        checkmem = true;
                        break;
                    case "MR":
                        checkmem = true;
                        return memory;
                        break;
                    case "MS":
                        memory = Stacknumber.Pop();
                        Stacknumber.Push(memory);
                        checkmem = true;
                        break;
                    case "M+":
                        String kebmem;
                        checkmem = true;
                        kebmem = (Convert.ToDouble(Stacknumber.Pop()) + Convert.ToDouble(memory)).ToString();
                        
                        memory = kebmem;
                        break;
                    case "M-":
                        String kebmeme;
                        checkmem = true;
                        kebmeme = (Convert.ToDouble(memory) - Convert.ToDouble(Stacknumber.Pop())).ToString();
                        
                        memory = kebmeme;
                        break;
                }

            }

           
            if (Stacknumber.Count > 1 || beforeopereter == false)
            {
                return "E";
            }
            
            if(checkmem == true)
            {
                return "";
            }
            else
            {
                return Stacknumber.Pop();
            }
            
        }
    }
}
