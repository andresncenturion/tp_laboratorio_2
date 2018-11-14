using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = true;
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(archivo, false);
                sw.WriteLine();
            }
            catch(Exception)
            {
                retorno = false;
            }
            finally
            {
                sw.Close();
            }

            return retorno;
        }
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = true;
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
            }
            catch(Exception)
            {
                datos = null;
                retorno = false;
            }
            finally
            {
                sr.Close();
            }

            return retorno;
        }
    }
}
