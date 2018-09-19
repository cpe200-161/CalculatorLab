using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPE200Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1.Tests
{
    [TestClass()]
    public class RPNCalculatorEngineTests
    {
        [TestMethod()]
        public void Process_Basic_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            Assert.AreEqual("2", r.RPN_Process("1 1 +"));
            Assert.AreEqual("1", r.RPN_Process("3 2 -"));
            Assert.AreEqual("6", r.RPN_Process("3 2 X"));
            Assert.AreEqual("2", r.RPN_Process("4 2 ÷"));
            Assert.AreEqual("0", r.RPN_Process("1 -1 +"));
            Assert.AreEqual("5", r.RPN_Process("3 -2 -"));
            Assert.AreEqual("-1", r.RPN_Process("2 3 -"));
            Assert.AreEqual("-6", r.RPN_Process("3 -2 X"));
            Assert.AreEqual("-2", r.RPN_Process("-4 2 ÷"));
        }

        [TestMethod()]
        public void Process_Complex_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            Assert.AreEqual("8", r.RPN_Process("1 3 + 2 X"));
            Assert.AreEqual("5", r.RPN_Process("1 3 2 + X"));
            Assert.AreEqual("-5", r.RPN_Process("1 2 3 4 + - X"));
        }

        [TestMethod()]
        public void Process_Error_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            Assert.AreEqual("E", r.RPN_Process("1"));
            Assert.AreEqual("E", r.RPN_Process("1 +"));
            Assert.AreEqual("E", r.RPN_Process("1 + 1"));
            Assert.AreEqual("E", r.RPN_Process("1 1 1 +"));
            Assert.AreEqual("E", r.RPN_Process("+"));
            Assert.AreEqual("E", r.RPN_Process("+ 1"));
            Assert.AreEqual("E", r.RPN_Process("+ 1 1"));
            Assert.AreEqual("E", r.RPN_Process("1 1 1 + + +"));
        }
    }
}