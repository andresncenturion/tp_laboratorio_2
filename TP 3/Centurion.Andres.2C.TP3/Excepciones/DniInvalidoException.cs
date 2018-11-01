using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private const string mensajeBase = "DNI Invalido";

        public DniInvalidoException()
        {

        }

        public DniInvalidoException(Exception e) : this(mensajeBase, e)
        {

        }

        public DniInvalidoException(string mensaje) : this(mensajeBase, null)
        {

        }

        public DniInvalidoException(string mensaje, Exception e) : base(mensajeBase, e)
        {

        }
    }
}
