using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="legajo">Legajo del Universitario</param>
        /// <param name="nombre">Nombre del Universitario</param>
        /// <param name="apellido">Apellido del Universitario</param>
        /// <param name="dni">DNI del Universitario</param>
        /// <param name="nacionalidad">Nacionalidad del Universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos

        #region Sobrecargas
                
        /// <summary>
        /// Sobrecarga del metodo Equals que comprueba si dos Universitarios son iguales
        /// </summary>
        /// <param name="obj">Universitario a comparar</param>
        /// <returns>True si son iguales, False si no</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (!ReferenceEquals(obj, null) && obj is Universitario)
            {
                Universitario objeto = (Universitario)obj;
                if (objeto.legajo == this.legajo && objeto.Dni == this.Dni)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del metodo == para comparar dos Universitarios
        /// </summary>
        /// <param name="pg1">Primer Universitario a comparar</param>
        /// <param name="pg2">Segundo Univeristario a comparar</param>
        /// <returns>True si son iguales, false si no</returns>
        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if(pg1.Equals(pg2))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del metodo == para comparar dos Universitarios
        /// </summary>
        /// <param name="pg1">Primer Universitario a comparar</param>
        /// <param name="pg2">Segundo Univeristario a comparar</param>
        /// <returns>True si son iguales, false si no</returns>
        public static bool operator != (Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Retorna los datos del Univeristario
        /// </summary>
        /// <returns>Datos del Universitario en formato String</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this.legajo);            

            return sb.ToString();
        }
        #endregion
    }
}
