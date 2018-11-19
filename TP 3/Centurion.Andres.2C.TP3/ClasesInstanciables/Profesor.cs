using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Constructor de clase que inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="id">ID del Profesor</param>
        /// <param name="nombre">Nombre del Profesor</param>
        /// <param name="apellido">Apellido del Profesor</param>
        /// <param name="dni">DNI del Profesor</param>
        /// <param name="nacionalidad">Nacionalidad del Profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        #region Sobrecargas

        /// <summary>
        /// Retorna los datos del Profesor
        /// </summary>
        /// <returns>Datos del profesor en formato String</returns>
        protected override string MostrarDatos()
        {            
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.ToString());
            sb.AppendLine(this.ParticiparEnClase()); // Metodo que retorna las clases de las que participa el profesor en formato String

            return sb.ToString();
        }

        /// <summary>
        /// Retorna las clases de las que participa el profesor
        /// </summary>
        /// <returns>Clases de las que participa el profesor en formato String</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            if (!object.ReferenceEquals(this.clasesDelDia, null))
            {
                foreach (Universidad.EClases clase in this.clasesDelDia)
                {
                    sb.AppendLine("" + clase);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del metodo ToString que retorna los datos del Profesor
        /// </summary>
        /// <returns>Datos del profesor en formato ToString</returns>
        public override string ToString()
        {
            return this.MostrarDatos(); // Metodo que retorna los datos del profesor
        }

        /// <summary>
        /// Verifica si un Profesor participa de una clase
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si participa, False si no</returns>
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            if(i.clasesDelDia.Contains(clase))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Verifica si un Profesor no participa de una clase
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si no participa, False si participa</returns>
        public static bool operator != (Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }                        
        #endregion

        /// <summary>
        /// Selecciona 2 clases al azar de las clases posibles y las encola en el atributo clasesDelDia
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }
        #endregion
    }
}
