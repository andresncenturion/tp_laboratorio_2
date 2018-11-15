using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Legajo: " + this.legajo);
            sb.AppendLine(base.ToString());

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

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

        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if(pg1.Equals(pg2))
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator != (Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        
    }
}
