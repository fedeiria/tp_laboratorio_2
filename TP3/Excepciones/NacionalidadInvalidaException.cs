using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <param name="e"></param>
        public NacionalidadInvalidaException()
            : base("La nacionalidad no se condice con el numero de DNI") { }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="e"></param>
        public NacionalidadInvalidaException(string message)
            : base(message) { }
        #endregion
    }
}
