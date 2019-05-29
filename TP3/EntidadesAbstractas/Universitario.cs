using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region "Atributos"
        private int legajo;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario() { }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Retorna una cadena indicando las clases que toma un Universitario.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Retorna una cadena con los datos del Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return string.Format($"{base.ToString()}LEGAJO NUMERO: {this.legajo}");
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Comprueba si el objeto es de tipo Universitario.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Comprueba si dos universitarios tienen mismo DNI o Legajo.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2))
            {
                if (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Comprueba si dos universitarios tienen diferente DNI o Legajo.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
