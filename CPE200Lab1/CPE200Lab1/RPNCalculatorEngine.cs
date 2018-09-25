using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine 
    {
        String memory;
        public string Process(string str)
        {
            Stack<string> myStack = new Stack<string>();
            string[] parts = str.Split(' ');
            bool beforeopereter=false,checkmemory=false,checkoperate=false;
            foreach (string number in parts)
            {
                if (isOperator(number))
                {
                    string first, second;
                    if (myStack.Count < 2 && checkoperate == false)
                    {
                        return "E";
                    }
                    first = myStack.Pop();
                    second = myStack.Pop();
                    myStack.Push(calculate(number, second, first));
                    beforeopereter = true;
                }
                else if(isNumber(number)) 
                {
                    myStack.Push(number);
                }
                else if(number == "√")
                {
                    string first;
                    first = myStack.Pop();
                    checkoperate = true;
                    beforeopereter = true;
                    myStack.Push(calculate(number, first));
                }
                else if (number== "1/x")
                {
                    string first;
                    first = myStack.Pop();
                    checkoperate = true;
                    beforeopereter = true;
                    myStack.Push(calculate(number,first));
                }
                else if (number == "%")
                {
                    beforeopereter = true;
                    string first, second;
                    first = myStack.Pop();
                    second = myStack.Pop();
                    //Stacknumber.Push(second);
                    myStack.Push(calculate(number, second, first));
                }
                
                switch (number)
                {
                    case "MC":
                        memory = "0";
                        beforeopereter = true;
                        checkmemory = true;
                        break;
                    case "MR":
                        checkmemory = true;
                        return memory;
                        break;
                    case "MS":
                        beforeopereter = true;
                        memory = myStack.Pop();
                        myStack.Push(memory);
                        checkmemory = true;
                        break;
                    case "M+":
                        String kebmemory1;
                        checkmemory = true;
                        kebmemory1 = (Convert.ToDouble(myStack.Pop()) + Convert.ToDouble(memory)).ToString();
                        beforeopereter = true;
                        memory = kebmemory1;
                        break;
                    case "M-":
                        String kebmemory2;
                        checkmemory = true;
                        kebmemory2 = (Convert.ToDouble(memory) - Convert.ToDouble(myStack.Pop())).ToString();
                        beforeopereter = true;
                        memory = kebmemory2;
                        break;
                }

            }
            if (myStack.Count > 1 || beforeopereter == false)
            {
                return "E";
            }
            
            if(checkmemory == true)
            {
                return "0";
            }
            else
            {
                return myStack.Pop();
            }
            
        }
    }
}
