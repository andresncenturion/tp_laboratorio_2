using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private const string mensaje = "DNI Invalido";

        public DniInvalidoException()
        {

        }

        public DniInvalidoException(Exception e) : this(mensaje, e)
        {

        }

        public DniInvalidoException(string msj) : this(msj, null)
        {

        }

        public DniInvalidoException(string msj, Exception e) : base(msj, e)
        {

        }
    }
}
