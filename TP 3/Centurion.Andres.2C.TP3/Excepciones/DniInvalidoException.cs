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

        public DniInvalidoException(string mensaje) : this(mensaje, null)
        {

        }

        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {

        }
    }
}
