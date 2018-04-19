using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalcManager;


namespace StringCalcTest
{
    [TestFixture]
    class MyStringCalcTest
    {
        [TestCase(0,"")]
        [TestCase(5, "5")]
        [TestCase(4, "1,3")]
        [TestCase(12, "1,4,5,2")]
        [TestCase(6, "1\n2,3")]
        [TestCase(3, "//;\n1;2")]
        [TestCase(2, "//;\n1001;2")]
        [TestCase(6, "//***\n1***2***3")]
        [TestCase(6, "//*%\n1*2%3")]
        [TestCase(6, "//*%%\n1*2%%%%3")]
        public void Add_Numbers_ReturnSum(int expected, string numbers)
        {
            Assert.AreEqual(expected, StringCalc.Add(numbers));
        }

        [Test]
        public void Add_NegativesNumbers_ThrowError()
        {
            var numbers = "1\n-2,-3";
            var exeption= Assert.Throws<Exception>(()=> StringCalc.Add(numbers));
            Assert.AreEqual("negatives not allowed:-2 -3", exeption.Message);

        }


    }
}
