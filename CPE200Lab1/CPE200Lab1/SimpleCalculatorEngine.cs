using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class SimpleCalculatorEngine : CalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;

        private double setFirstOperand;
        private double setSecondOperand;

        public double SetFirstOperand
        {
            get => setFirstOperand; set => setFirstOperand = value;
        }

        public double SetSecondOperand {
            get => setSecondOperand; set => setSecondOperand = value;
        }

        public string calculate(string oper)
        {
            return oper;
        }

    }
}
