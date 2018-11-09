using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CPE200Lab1
{
    class CalculatorModel : Model
    {
        protected CalculatorEngine Engine;
        protected RPNCalculatorEngine RPNEngine;
        private string display;
        public CalculatorModel()
        {
            Engine = new CalculatorEngine();
            RPNEngine = new RPNCalculatorEngine();
        }
        public string Display()
        {
            return display;
        }
        public void Calculator(string str)
        {
            string result = Engine.Calculate(str);
            if (result is "E")
            {
                result = RPNEngine.Calculate(str);
                if (result is "E")
                {
                    display = "Error";
                }
                else
                {
                    display = result;
                }
            }
            else
            {
                display = result;
            }
            NotifyAll();
        }
        public bool isNumber(string num)
        {
            return Engine.isNumber(num);
        }
        public string Calculate(string operate, string operand)
        {
            return Engine.Calculate(operate, operand);
        }
        public string Calculate(string operate, string firstOperand, string secondOperand)
        {
            return Calculate(operate, firstOperand, secondOperand);
        }
    }
}