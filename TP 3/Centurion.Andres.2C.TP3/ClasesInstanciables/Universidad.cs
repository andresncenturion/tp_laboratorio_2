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

        private List<Alumno> alumnos = new List<Alumno>();
        private List<Jornada> jornada = new List<Jornada>();
        private List<Profesor> profesores = new List<Profesor>();

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
         
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        public static bool operator == (Universidad g, Alumno a)
        {
            bool retorno = false;

            if(g.alumnos.Contains(a))
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator != (Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator == (Universidad g, Profesor i)
        {
            bool retorno = false;

            if(g.profesores.Contains(i))
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator != (Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator == (Universidad u, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor p in u.profesores)
            {
                if (p == clase)
                {
                    retorno = p;
                    break;
                }
                throw new SinProfesorException();
            }
            return retorno;
        }

        public static Profesor operator != (Universidad u, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                {
                    retorno = p;
                    break;
                }
                throw new SinProfesorException();
            }
            return retorno;
        }

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

        public static Universidad operator + (Universidad u, Alumno a)
        {
            if(!(u == a))
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        public static Universidad operator + (Universidad u, Profesor i)
        {
            if(!(u == i))
            {
                u.profesores.Add(i);
            }

            return u;
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada j in uni.Jornadas)
            {
                sb.AppendLine(j.ToString());
            }

            return sb.ToString();
        }

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

    }
}
