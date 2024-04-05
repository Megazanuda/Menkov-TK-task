using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var window = new MainWindow();
            Assert.IsTrue(window.InputTry("3", "4", "8"));

            
        }
    }
}
