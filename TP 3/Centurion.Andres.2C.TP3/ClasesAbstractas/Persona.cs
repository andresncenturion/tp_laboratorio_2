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

        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades

        /// <summary>
        /// Lee o escribe el campo apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value); // Validacion de apellido
            }
        }

        /// <summary>
        /// Lee o escribe(y valida) el campo dni
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Lee o escribe el campo nacionalidad
        /// </summary>
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

        /// <summary>
        /// Lee o escribe el campo nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value); // Validacion de nombre
            }
        }

        /// <summary>
        /// Escribe el DNI validado
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona en tipo Int</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona en tipo String</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Metodos

        #region Sobrecargas

        /// <summary>
        /// Sobreescribe el metodo ToString para que retorne los datos de la Persona
        /// </summary>
        /// <returns>Datos de la Persona en formato String</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.apellido, this.nombre);                        
            sb.AppendLine("NACIONALIDAD: " + this.nacionalidad);
            sb.AppendLine("DNI: " + this.dni);

            return sb.ToString();
        }
        #endregion

        #region Validaciones

        /// <summary>
        /// Valida que el DNI recibido este dentro del rango esperado para el tipo de nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        /// <param name="dato">DNI de la Persona</param>
        /// <returns>DNI validado segun rango</returns>
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

        /// <summary>
        /// Valida que los caracteres del DNI sean numericos
        /// </summary>
        /// <param name="nacionalidad"> Nacionalidad de la Persona</param>
        /// <param name="dato"> DNI de la persona</param>
        /// <returns>DNI validado por caracteres y por rango</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno;

            if (Regex.IsMatch(dato, @"^[0-9]+[0-9\.]*$")) // Valida que los caracteres del DNI sean numeros
            {                
                if (int.TryParse(dato, out retorno))
                {
                    retorno = ValidarDni(nacionalidad, retorno); // Valida que el DNI este dentro del rango esperado
                }
            }
            else
            {
                throw new DniInvalidoException("El dni tiene caracteres que no corresponden");
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el nombre o apellido recibidos contengan caracteres validos
        /// </summary>
        /// <param name="dato">String a validar(nombre o apellido de la Persona)</param>
        /// <returns>Nombre o apellido validados</returns>
        private string ValidarNombreApellido(string dato)
        {
            string validos = @"^([A-Z][a-z]+)(\s[A-Z][a-z]+)$";

            if(!Regex.IsMatch(dato, validos))
            {
                dato = "";
            }

            return dato;
        }
        #endregion
        #endregion
    }
}
