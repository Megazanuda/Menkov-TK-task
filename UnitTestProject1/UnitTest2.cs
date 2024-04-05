using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var window = new MainWindow();
            Assert.IsFalse(window.InputTry("50", "50", "50"));
            Assert.IsFalse(window.InputTry("-1", "-1", "-1"));
            Assert.IsFalse(window.InputTry("50", "1", "1"));
            Assert.IsFalse(window.InputTry("1", "50", "1"));
            Assert.IsFalse(window.InputTry("1", "1", "50"));

        }
    }
}
