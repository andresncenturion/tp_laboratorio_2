using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    public enum ENacionalidad
    {
        Argentino, Extranjero
    }

    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
                  
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string StringToDni
        {            
            set
            {
                zdcdf
            }
        }

        public Persona()
        {

        }

        public Persona (string nombre, string apellido, ENacionalidad nacionalidad)
        {
           
        }

        public Persona (string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.nacionalidad = nacionalidad;
        }

        public Persona (string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {

        }

        private string ValidarNombreApellido(string dato)
        {

        }
    }
}
