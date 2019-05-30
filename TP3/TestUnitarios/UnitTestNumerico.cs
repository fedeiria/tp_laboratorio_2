using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTestNumerico
    {
        [TestMethod]
        public void TestMethod1()
        {
            Alumno a1 = new Alumno(1, "Federico", "Iriarte", "32765881", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsInstanceOfType(a1.DNI, typeof(Int32));
        }
    }
}
