using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTestExcepciones
    {
        [TestMethod]
        [ExpectedException (typeof(AlumnoRepetidoException))]
        public void TestMethod1()
        {
            Universidad u = new Universidad();
            Alumno a1 = new Alumno(1, "Federico", "Iriarte", "32765881", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Juan", "Perez", "32765881", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            u += a1;
            u += a2;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestMethod2()
        {
            Universidad u = new Universidad();
            Alumno a1 = new Alumno(2, "Juan", "Perez", "22333444", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);

            u += a1;
            Assert.Fail();
        }
    }
}
