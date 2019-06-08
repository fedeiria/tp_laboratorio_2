using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        #region "Constructores
        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="message"></param>
        public TrackingIdRepetidoException(string message)
            : base(message) { }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="message"></param>
        public TrackingIdRepetidoException(string message, Exception inner)
            : base (message, inner) { }
        #endregion
    }
}
