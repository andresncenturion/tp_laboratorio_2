using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades

        /// <summary>
        /// Lee o escribe el atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Lee o escribe el atributo clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Lee o escribe el atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto, inicializa la lista de alumnos del atributo alumnos
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos
        #region Sobrecargas

        /// <summary>
        /// Verifica si el Alumno participa de la jornada
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si participa, False si no</returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            bool retorno = false;

            if(j.Alumnos.Contains(a))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Verifica si el Alumno participa de la jornada
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si no participa, False si participa</returns>
        public static bool operator != (Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un Alumno a la Jornada si el mismo no participa de ella.
        /// </summary>
        /// <param name="jornada">Jornada a consultar</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la Jornada con el Alumno agregado o no</returns>
        public static Jornada operator + (Jornada jornada, Alumno a)
        {
            if (jornada != a)
            {
                jornada.alumnos.Add(a);
            }

            return jornada;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString que retorna los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE: " + this.clase);
            sb.AppendLine("PROFESOR: " + this.instructor);
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno a in this.alumnos)
            {
                sb.AppendLine("" + a.ToString());
            }
            
            return sb.ToString();
        }

        #endregion

        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>True si se guardo exitosamente, False si hubo un error</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = true;    
            Texto t = new Texto();

            if(t.Guardar("Jornada.txt", jornada.ToString()) == false)
            {
                throw new ArchivosException("Error al guardar archivo");
            }

            return retorno;
        }

        /// <summary>
        /// Lee los datos de un archivo de texto y los retorna como String
        /// </summary>
        /// <returns>Retorna los datos leidos del archivo de texto en formato String</returns>
        public static string Leer()
        {
            string retorno;
            Texto t = new Texto();            

            if(t.Leer("Jornada.txt", out retorno) == false)
            {
                throw new ArchivosException("Error al leer el archivo");
            }

            return retorno;
        }
        #endregion
    }
}
