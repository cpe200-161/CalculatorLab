using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            string[] parts = str.Split(' ');
            Stack myStack = new Stack();


            foreach(var p in parts)
            {
                Console.WriteLine(p);
            }

            return "E";
        }
    }
}
