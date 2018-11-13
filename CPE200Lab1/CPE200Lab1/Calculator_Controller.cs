using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class Calculator_Controller : Controller
    {
        public Calculator_Controller() { }
        public override void Calculate(string str)
        {
            foreach (CalculatorModel m in mList)
            {
                m.calculator(str);
            }
        }
    }
}