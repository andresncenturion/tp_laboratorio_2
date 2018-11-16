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
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        public Profesor()
        {

        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        protected override string MostrarDatos()
        {
            string retorno;
            StringBuilder sb = new StringBuilder();
            
            sb.Append(base.ToString());

            return sb.ToString();
        }

        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            if(i.clasesDelDia.Contains(clase))
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator != (Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }            
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Clases del dia: ");
            if (!object.ReferenceEquals(this.clasesDelDia, null))
            {
                foreach (Universidad.EClases clase in this.clasesDelDia)
                {
                    sb.AppendLine("" + clase.ToString());
                }
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }


    }
}
