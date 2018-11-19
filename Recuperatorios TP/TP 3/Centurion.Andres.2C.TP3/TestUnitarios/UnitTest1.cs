using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using ClasesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {   
        /// <summary>
        /// Testea que se lance la excepcion NacionalidadInvalidaException cuando se agregan Alumnos con DNI fuera de los rangos esperados por su nacionalidad
        /// </summary>
        [TestMethod]
        public void TestNacionalidadInvalidaException()
        {
            Universidad u = new Universidad();

            Alumno a1 = new Alumno(1, "Pablo", "Trapero", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(2, "Akira", "Kurosawa", "12234456", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            
            try
            {
                u += a1;
                u += a2;
            }            

            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }            
        }

        /// <summary>
        /// Testea que se lance la exepcion SinProfesorException cuando se agrega una clase sin profesores disponibles para darla
        /// </summary>
        [TestMethod]
        public void TestSinProfesorException()
        {
            Universidad u = new Universidad();

            try
            {
                u += Universidad.EClases.SPD; // No hay profesores cargados, debe lanzar SinProfesorException
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }

        /// <summary>
        /// Testea que el valor de los DNI se cargue de forma correcta
        /// </summary>
        [TestMethod]
        public void TestLegajoValido()
        {
            Alumno a = new Alumno(1, "Pablo", "Trapero", "12.345.678", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Profesor p = new Profesor(1, "Akira", "Kurosawa", "22.234.456", Persona.ENacionalidad.Argentino);

            Assert.IsTrue(a.Dni == 12345678);
            Assert.IsTrue(p.Dni == 22234456);
        }

        [TestMethod]
        public void TestUniversidadConAlumnos()
        {
            Universidad u = new Universidad();

            Assert.IsNotNull(u.Alumnos);
        }
    }
}
