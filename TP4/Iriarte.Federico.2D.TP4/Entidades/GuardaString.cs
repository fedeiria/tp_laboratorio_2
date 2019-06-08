using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        #region "Metodos"
        /// <summary>
        /// Genera un archivo de texto en el escritorio con la informacion de todos los paquetes que se encuentran en la lista.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo, true))
                {
                    writer.WriteLine(texto);
                }

                return true;
            }
            catch (PathTooLongException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (IOException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (NotSupportedException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
        #endregion
    }
}
