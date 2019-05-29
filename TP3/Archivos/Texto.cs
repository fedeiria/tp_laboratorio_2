using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region "Metodos"
        /// <summary>
        /// Guarda los datos del programa en un archivo de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(archivo, true);
                sw.WriteLine(datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                sw.Close();
            }

            return true;
        }

        /// <summary>
        /// Lee los datos del programa guardados en un archivo de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                sr.Close();
            }

            return true;
        }
        #endregion
    }
}
