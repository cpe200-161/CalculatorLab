using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    /// <summary>
    /// Provide method for calculate string of number.
    /// </summary>
    public class CalculatorEngine : TheCalculatorEngine
    {
        /// <summary>
        /// Calculate with normal style.
        /// </summary>
        /// <param name="str">
        /// The string of normal style.
        /// </param>
        /// <returns>
        /// The string of result.
        /// </returns>
        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }

        }
    }
}
