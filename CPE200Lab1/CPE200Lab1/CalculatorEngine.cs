using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        public string calculate(int first,string operate,string operatebefore, double percent, double resultpercent, string firstOperand, string result, int maxOutputSize = 8)
        {
            double resultnum, firstOperandnum;
            resultnum = Convert.ToDouble(result);
            firstOperandnum = Convert.ToDouble(firstOperand);
            switch (operate)
            {
                case "+":
                    return (resultnum + firstOperandnum).ToString();
                case "-":
                    if (first == 0)
                        return (firstOperandnum).ToString();
                    else
                        return (resultnum - firstOperandnum).ToString();
                case "X":
                    if (first == 0)
                        return (firstOperandnum).ToString();
                    else
                        return (resultnum * firstOperandnum).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (firstOperandnum != 0)
                    {
                        if (first == 0)
                        {
                            return (firstOperandnum).ToString();
                        }
                        if (firstOperand != "0")
                        {
                            string resultdivide = (resultnum / firstOperandnum).ToString();
                            for (int i = resultdivide.Length; resultdivide.Length >= 8; i++)
                            {
                                resultdivide = resultdivide.Substring(0, resultdivide.Length - 1);
                            }
                            char rightd = resultdivide[resultdivide.Length - 1];
                            double tempd = Char.GetNumericValue(rightd);
                            double rightMostd = Convert.ToDouble(tempd);
                            if (rightMostd > 5)
                            {
                                rightMostd++;
                                string rightMostS = rightMostd.ToString();
                                return resultdivide + rightMostS;
                            }
                            return resultdivide;
                        }
                    }
                    break;
                case "%":
                   if (operatebefore == "+")
                        return (resultpercent + resultnum).ToString();
                   if (operatebefore == "-")
                        return (resultpercent - resultnum).ToString();
                   if (operatebefore == "X")
                        return (resultpercent * resultnum).ToString();
                   if (operatebefore == "/")
                        return (resultpercent / resultnum).ToString();
                break;
                case "√":
                    if (first == 0)
                    {
                        string fOroot = (Math.Sqrt(firstOperandnum)).ToString();
                        for (int i = fOroot.Length; fOroot.Length > 8; i++) {
                            fOroot = fOroot.Substring(0, fOroot.Length - 1);
                        }
                        return fOroot;
                    }
                    else
                    {
                        string resultroot = (Math.Sqrt(resultnum)).ToString();
                        for (int i = resultroot.Length; resultroot.Length < 8; i++)
                        {
                            resultroot = resultroot.Substring(0, resultroot.Length - 1);
                        }
                        return resultroot;
                    }
            }
            return "E";
        }
        public string calculatepercent(string operate, double percent, double resultpercent, string result, int maxOutputSize = 8)
        {
            return (resultpercent *(percent/100.00)).ToString();
        }
    }
}
