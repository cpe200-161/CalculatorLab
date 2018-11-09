calculateCalcuationFourTest()
        {
            Assert.AreEqual("-1", engine.calculate("1 2 - "));
            Assert.AreEqual("-1", engine.calculate("-1 1 X "));
            Assert.AreEqual("-1", engine.calculate("1 -1 X "));
            Assert.AreEqual("-1", engine.calculate("1 -1 ÷"));
            Assert.AreEqual("-1", engine.calculate("-1 1 ÷"));
        }

        [TestMethod()]
        public void BasicCalcuationFiveTest()
        {
            Assert.AreEqual("0.5", engine.calculate("1 2 ÷"));
            Assert.AreEqual("0.3333", engine.calculate("1 3 ÷"));
            Assert.AreEqual("0.25", engine.calculate("1 4 ÷"));
            Assert.AreEqual("0.1667", engine.calculate("1 6 ÷"));
            Assert.AreEqual("0.125", engine.calculate("1 8 ÷"));
        }

        [TestMethod()]
        public void ComplexCalcuationTest()
        {
            Assert.AreEqual("3", engine.calculate("1 1 1 + + "));
            Assert.AreEqual("-1", engine.calculate("1 1 1 + - "));
            Assert.AreEqual("1", engine.calculate("1 1 1 - + "));
            Assert.AreEqual("1", engine.calculate("1 1 1 - - "));
            Assert.AreEqual("6", engine.calculate("2 2 2 X + "));
            Assert.AreEqual("8", engine.calculate("2 2 2 + X "));
            Assert.AreEqual("0.5", engine.calculate("2 2 2 + ÷"));
            Assert.AreEqual("3", engine.calculate("2 2 2 ÷ +"));
        }

        [TestMethod()]
        public void DividedByZeroTest()
        {
            Assert.AreEqual("E", engine.calculate("0 0 ÷ "));
            Assert.AreEqual("E", engine.calculate("1 0 ÷ "));
            Assert.AreEqual("E", engine.calculate("1 2 2 - ÷ "));
        }

        [TestMethod()]
        public void InvalideFormatTest()
        {
            Assert.AreEqual("E", engine.calculate("+"));
            Assert.AreEqual("E", engine.calculate("1+"));
            Assert.AreEqual("E", engine.calculate("+1"));
            Assert.AreEqual("E", engine.calculate("1 +"));
            Assert.AreEqual("E", engine.calculate("+ 1"));
            Assert.AreEqual("E", engine.calculate("1 1"));
            Assert.AreEqual("E", engine.calculate("+ 1 1"));
            Assert.AreEqual("E", engine.calculate("1 1 ++"));
            Assert.AreEqual("E", engine.calculate("1 1 + +"));
            Assert.AreEqual("E", engine.calculate("1 1 ++ +"));
            Assert.AreEqual("E", engine.calculate("1 1 + + +"));
            Assert.AreEqual("E", engine.calculate("1 1 1 + "));
            Assert.AreEqual("E", engine.calculate("1 1 1 + "));
        }
    }
}