using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region "Metodos"
        /// <summary>
        /// Guarda los datos del programa en un archivo xml.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer xs = null;
            XmlTextWriter xmlText = null;

            try
            {
                xs = new XmlSerializer(typeof(T));
                xmlText = new XmlTextWriter(archivo, Encoding.UTF8);
                xs.Serialize(xmlText, datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                xmlText.Close();
            }

            return true;
        }

        /// <summary>
        /// Lee los datos del programa guardados en un archivo xml.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer xs = null;
            XmlTextReader xmlReader = null;

            try
            {
                xs = new XmlSerializer(typeof(T));
                xmlReader = new XmlTextReader(archivo);
                datos = (T)xs.Deserialize(xmlReader);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                xmlReader.Close();
            }

            return true;
        }
        #endregion
    }
}
