using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region "Constructores"
        /// <summary>
        /// constructor por defecto.
        /// </summary>
        public AlumnoRepetidoException()
            : base("Alumno repetido.") { }
        #endregion
    }
}
