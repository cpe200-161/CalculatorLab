using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CPE200Lab1
{
    class CalculatorController : Controller
    {
        public CalculatorController()
        {
        }
        public override void Calculate(string str)
        {
            foreach (CalculatorModel model in modelList)
            {
                model.calculator(str);
            }
        }
    }
}