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
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

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

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public static bool operator == (Jornada j, Alumno a)
        {
            bool retorno = false;

            if(j.Alumnos.Contains(a))
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator != (Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator + (Jornada jornada, Alumno a)
        {
            if (jornada != a)
            {
                jornada.alumnos.Add(a);
            }

            return jornada;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Clase: " + this.clase);
            sb.AppendLine("Profesor: " + this.instructor);
            foreach (Alumno a in alumnos)
            {
                sb.AppendLine("" + a.ToString());
            }
            
            return sb.ToString();
        }

        public bool Guardar(Jornada jornada)
        {
            bool retorno = true;    
            Texto t = new Texto();

            if(t.Guardar("Jornada.txt", jornada.ToString()) == false)
            {
                throw new ArchivosException("Error al guardar archivo");
            }

            return retorno;
        }

        public string Leer()
        {
            string retorno;
            Texto t = new Texto();            

            if(t.Leer("Jornada.txt", out retorno) == false)
            {
                throw new ArchivosException("Error al leer el archivo");
            }

            return retorno;
        }
    }
}
