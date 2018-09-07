using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private string display = "0";



        public override void BtSpace_Click()
        {
            base.BtSpace_Click();
            isSpaceAllowed = false;
            
        }
    }
}
