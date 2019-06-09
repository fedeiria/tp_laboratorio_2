using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest2
    {
        /// <summary>
        /// Verifica que no se puedan cargar dos paquetes con el mismo trackingID.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestMethod1()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Matheu 645", "000-000-0001");
            Paquete p2 = new Paquete("Matheu 645", "000-000-0001");

            correo += p1;
            correo += p2;
            Assert.Fail();
        }
    }
}
