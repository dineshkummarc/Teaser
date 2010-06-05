using System;
using Gallio.SimpleLibrary;
using MbUnit.Framework;
using WatiN.Core;

namespace Gallio.SimpleLibrary.Test
{
    public class FibonacciTest
    {
        [Test]
        public void Fibonacci_of_number_greater_than_one()
        {
            int result = Fibonacci.Calculate(6);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void SearchForWatiNOnGoogle()
        { 
            using (var browser = new IE("http://www.google.com"))
            {
                browser.TextField(Find.ByName("q")).TypeText("WatiN");
                browser.Button(Find.ByName("btnG")).Click();

                Assert.IsTrue(browser.ContainsText("WatiN"));
            }
        }

    }
}