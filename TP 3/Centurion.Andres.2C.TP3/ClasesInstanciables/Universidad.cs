using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

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

    }
}
