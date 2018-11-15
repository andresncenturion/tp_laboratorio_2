using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = true;
            XmlSerializer xs = new XmlSerializer(typeof(T));
            XmlTextWriter xwriter = null;
            
            try
            {
                xwriter = new XmlTextWriter(archivo, null);
                xs.Serialize(xwriter, datos);
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                xwriter.Close();
            }
            return retorno;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = true;
            XmlSerializer xs = new XmlSerializer(typeof(T));
            XmlTextReader xreader = null;                

            try
            {
                xreader = new XmlTextReader(archivo);
                datos = (T)xs.Deserialize(xreader);
            }
            catch (Exception)
            {
                datos = default(T); 
                retorno = false;
            }
            finally
            {
                xreader.Close();
            }

            return retorno;
        }
    }
}
