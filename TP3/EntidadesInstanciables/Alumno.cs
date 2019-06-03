using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region "Atributos"
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region "Constructores"
        /// <summary>
        /// constructor por defecto.
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// constructor de instancia.
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// constructor de instancia.
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Retorna una cadena indicando las clases que toma un Alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format($"TOMA CLASES DE {this.claseQueToma}");
        }

        /// <summary>
        /// Retorna una cadena con los datos del Alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return string.Format($"{base.MostrarDatos()}\n\nESTADO DE CUENTA: {this.estadoCuenta}\n{this.ParticiparEnClase()}");
        }

        /// <summary>
        /// Retorna una cadena con los datos del Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Retorna true si el estado de cuenta del alumno es distinto a Deudor y toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase);
        }

        /// <summary>
        /// Retorna true si el alumno no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }
        #endregion
    }
}
