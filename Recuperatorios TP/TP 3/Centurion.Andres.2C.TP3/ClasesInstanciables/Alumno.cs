using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="id">ID del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="id">ID del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)  : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        #region Sobrecargas
        
        /// <summary>
        /// Sobrecarga del metodo == que verifica que el Alumno tome una clase y que no sea deudor
        /// </summary>
        /// <param name="a">Alumno a verificar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si el Alumno toma esa clase y no es deudor; si no, false</returns>
        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del metodo == que verifica que el Alumno tome una clase y que no sea deudor
        /// </summary>
        /// <param name="a">Alumno a verificar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si el Alumno toma esa clase y no es deudor; si no, false</returns>
        public static bool operator != (Alumno a, Universidad.EClases clase)
        {            
            return !(a == clase);
        }

        /// <summary>
        /// Sobrecarga del metodo ToString que retorna los datos del Alumno
        /// </summary>
        /// <returns>Datos del alumno en formato String</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }        

        /// <summary>
        /// Implementacion del metodo ParticiparEnClase de la clase Universitario que retorna las clases de las que participa el Alumno
        /// </summary>
        /// <returns>Clases que toma el alumno en formato String</returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASES DE " + this.claseQueToma);
        }

        /// <summary>
        /// Sobrecarga del metodo MostrarDatos de la clase Universitario que retorna los datos del Alumno
        /// </summary>
        /// <returns>Datos del alumno en formato String</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);

            return sb.ToString();
        }
        #endregion
        #endregion
    }
}
