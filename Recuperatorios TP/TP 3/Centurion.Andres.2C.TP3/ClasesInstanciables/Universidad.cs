using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
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
        /// Lee o escribe el atributo profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Lee o escribe el atributo jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Indexador de la lista de Jornadas
        /// </summary>
        /// <param name="i">Indice de la Joranda</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                Jornada j = null;

                if (i >= 0 && i < this.Jornadas.Count)
                {
                    j = this.Jornadas[i];
                }

                return j;
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }

        #endregion

        #region Constructores
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        #region Sobrecargas                         

        /// <summary>
        /// Sobrecarga del metodo == que verifica si un Alumno esta inscripto en una Universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>True si el Alumno esta inscripto, False si no</returns>
        public static bool operator == (Universidad g, Alumno a)
        {
            bool retorno = false;

            if(g.Alumnos.Contains(a))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del metodo == que verifica si un Alumno esta inscripto en una Universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>True si el alumno no esta insripto, False si esta inscripto</returns>
        public static bool operator != (Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga del metodo == que verifica si un Profesor esta dando clases en una Universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a buscar</param>
        /// <returns>True si el Profesor esta dando clases en esa Universidad, False si no</returns>
        public static bool operator == (Universidad g, Profesor i)
        {
            bool retorno = false;

            if(g.Instructores.Contains(i))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del metodo == que verifica si un Profesor esta dando clases en una Universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a buscar</param>
        /// <returns>True si el Profesor no esta dando clases en esa Universidad, False si esta dando clases</returns>
        public static bool operator != (Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga del metodo == que retorna el primer Profesor que se encuentre en una Universidad capaz de dar la clase recibida por parametro. Si no encuentra uno, lanza una excepcion.
        /// </summary>
        /// <param name="u">Universidad a buscar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>El primer profesor capaz de dar la clase en la Univeridad recibidas por parametros</returns>
        public static Profesor operator == (Universidad u, EClases clase)
        {            
            foreach (Profesor p in u.Instructores)
            {
                if (p == clase)
                {
                    return p;
                }
            }

            throw new SinProfesorException();            
        }

        /// <summary>
        /// Sobrecarga del metodo == que retorna el primer Profesor que se encuentre en una Universidad que no pueda dar la clase recibida por parametro
        /// </summary>
        /// <param name="u">Universidad a buscar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>El primer profesor que no sea capaz de dar la clase en la Univeridad recibidas por parametros</returns>
        public static Profesor operator != (Universidad u, EClases clase)
        {            
            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                {
                    return p;                    
                }                
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Sobrecarga del metodo + que agrega una clase a una Universidad, generando una nueva Jornada indicando un Profesor que pueda dar la  materia y una lista de Alumnos que la cursen
        /// </summary>
        /// <param name="g">Universidad en la que se agregara la Jornada</param>
        /// <param name="clase">Tipo de clase que se creara</param>
        /// <returns>Retorna una objeto del tipo Universidad con una clase, Profesor y lista de alumnos</returns>
        public static Universidad operator + (Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);

            foreach(Alumno a in g.alumnos)
            {
                if(a == clase)
                {
                    j.Alumnos.Add(a);
                }                
            }
            g.Jornadas.Add(j);

            return g;
        }

        /// <summary>
        /// Sobrecarga del metodo + que agrega un Alumno a una Universidad validando que no se repita. De repetirse lanza una AlumnoRepetidoException
        /// </summary>
        /// <param name="u">Universidad en la que se agregara el alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna una Universidad con el Alumno agregado, o no</returns>
        public static Universidad operator + (Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga del metodo + que agrega un Profesor a una Universidad validando que no se repita.
        /// </summary>
        /// <param name="u">Universidad en la que se agregara el Profesor</param>
        /// <param name="a">Profesor a agregar</param>
        /// <returns>Retorna una Universidad con el Profesor agregado, o no</returns>
        public static Universidad operator + (Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString que retorna los datos de la Universidad
        /// </summary>
        /// <returns>Datos de la Universidad en formato String</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        /// <summary>
        /// Retorna los datos de la Universidad en formato String
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Retorna los datos de la Universidad en formato String</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada j in uni.Jornadas)
            {
                sb.AppendLine(j.ToString());
            }

            return sb.ToString();
        }        

        /// <summary>
        /// Serializador de Universidad en formato XML
        /// </summary>
        /// <param name="gim">Universidad a serializar</param>
        /// <returns>True si logro serializar, false si no</returns>
        public static bool Guardar(Universidad gim)
        {
            bool retorno = true;
            Xml<Universidad> u = new Xml<Universidad>();

            if (u.Guardar("Universidad.xml", gim) == false)
            {
                retorno = false;
                throw new ArchivosException("No se pudo guardar la universidad.");
            }

            return retorno;
        }

        /// <summary>
        /// Deserializador de Universidad desde un formato XML
        /// </summary>
        /// <returns>Retorna un objeto del tipo Universidad con los datos leidos en el XML</returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            Xml<Universidad> u = new Xml<Universidad>();

            if (u.Leer("Universidad.xml", out retorno) == false)
            {
                throw new ArchivosException("No se pudo leer la universidad.");
            }

            return retorno;
        }
        #endregion

    }
}
