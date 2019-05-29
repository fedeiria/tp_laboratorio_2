using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region "Metodos"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            : base("Se produjo un error al intentar leer/guardar los datos.", innerException) { }
        #endregion
    }
}
