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
        private string[] value;
        public double m, n;
        private int size ;
        private bool IsEmtry = false;
      


        public override void BtSpace_Click()
        {
            base.BtSpace_Click();
            isSpaceAllowed = false;
            
        }

        public void BtEq()
        {
            Stack<string> s = new Stack<string>(value.Length);
            if (IsEmtry)
            {
                return;
            }
            if()


        }
    }
}
