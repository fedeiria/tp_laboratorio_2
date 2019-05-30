using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTestNull
    {
        [TestMethod]
        public void TestMethod1()
        {
            Universidad u = new Universidad();

            Assert.IsNotNull(u);
        }
    }
}
