using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region "Atributos"
        private static Random random;
        private Queue<Universidad.EClases> clasesDelDia;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor estatico.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        private Profesor() { }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Asigna dos clases aleatorios a la lista de clases.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            Thread.Sleep(1000);
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Retorna una cadena indicando las clases asignadas al profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder show = new StringBuilder();

            show.AppendLine("CLASES DEL DIA:");

            foreach (Universidad.EClases aux in this.clasesDelDia)
            {
                show.AppendLine(aux.ToString());
            }

            return show.ToString();
        }

        /// <summary>
        /// Retorna una cadena con los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return string.Format($"{base.MostrarDatos()}\n{this.ParticiparEnClase()}");
        }

        /// <summary>
        /// Retorna una cadena con los datos del profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// retorna true si el profesor tiene asignada la clase pasada en el parametro clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return (i.clasesDelDia.Contains(clase));
        }

        /// <summary>
        /// retorna false si el profesor no tiene asignada la clase pasada en el parametro clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
