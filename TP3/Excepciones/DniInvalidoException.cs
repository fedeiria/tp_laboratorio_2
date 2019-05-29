using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region "Atributos"
        private string mensajeBase;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public DniInvalidoException()
            : base("El formato de DNI no es valido.") { }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e)
            : base("El formato de DNI no es valido.", e) { }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(string message)
        {
            this.mensajeBase = message;
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception innerException)
            : base(message, innerException) { }
        #endregion
    }
}
