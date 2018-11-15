using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

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
                this.apellido = ValidarNombreApellido(value);
            }
        }

        public int Dni
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
                this.nombre = ValidarNombreApellido(value);
            }
        }

        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nombre: " + this.nombre);
            sb.AppendLine("Apellido: " + this.apellido);
            sb.AppendLine("DNI: " + this.dni);
            sb.AppendLine("Nacionalidad: " + this.nacionalidad);

            return sb.ToString();
        }
        
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {            
            if(nacionalidad == ENacionalidad.Argentino)
            {
                if(dato < 1 || dato > 89999999)
                {
                    throw new NacionalidadInvalidaException("El DNI no es valido para esta nacionalidad.");
                }
            }
            else
            {
                if(dato < 90000000 || dato > 99999999)
                {
                    throw new NacionalidadInvalidaException("El DNI no es valido para esta nacionalidad.");
                }
            }
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;

            if (Regex.IsMatch(dato, @"^[0-9]+[0-9\.]*$"))
            {
                dato = dato.Replace(".", "");
                if (int.TryParse(dato, out dni))
                {
                    dni = ValidarDni(nacionalidad, dni);
                }
            }
            else
            {
                throw new DniInvalidoException("El dni tiene caracteres que no corresponden");
            }

            return dni;
        }

        private string ValidarNombreApellido(string dato)
        {
            string validos = @"^([A-Z][a-z]+)(\s[A-Z][a-z]+)$";

            if(!Regex.IsMatch(dato, validos))
            {
                dato = "";
            }

            return dato;
        }
    }
}
