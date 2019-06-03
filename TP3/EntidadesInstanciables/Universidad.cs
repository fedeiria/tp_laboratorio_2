using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region "Atributos"
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Obtiene y agrega un item de la lista de jornadas segun su indice.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            set
            {
                this.jornada[i] = value;
            }
            get
            {
                return this.jornada[i];
            }
        }

        /// <summary>
        /// Obtiene y agrega un item de la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            set
            {
                this.jornada = value;
            }
            get
            {
                return this.jornada;
            }
        }

        /// <summary>
        /// Obtiene y agrega un item de la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            set
            {
                this.alumnos = value;
            }
            get
            {
                return this.alumnos;
            }
        }

        /// <summary>
        /// Obtiene y agrega un item de la lista de Profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            set
            {
                this.profesores = value;
            }
            get
            {
                return this.profesores;
            }
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Retorna true si el alumno ya esta inscripto en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno aux in g.Alumnos)
            {
                if (aux == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna false si el alumno no esta inscripto en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Retorna true si el profesor da clases en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor aux in g.Instructores)
            {
                if (aux == i)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna false si el profesor no da clases en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Retorna el primer profesor capaz de dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor aux in g.Instructores)
            {
                if (aux == clase)
                {
                    return aux;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Retorna el primer profesor que no puede dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor aux in g.Instructores)
            {
                if (aux != clase)
                {
                    return aux;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega un alumno a la universidad siempre y cuando el mismo ya no se encuentre inscripto.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }

            return u;
        }

        /// <summary>
        /// Agrega un profesor a la universidad siempre y cuando el mismo ya no se encuentre inscripto.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Genera una nueva jornada indicando la clase, un profesor capaz de dar esa clase y la lista de alumnos habilitados para la misma.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Jornada j = new Jornada(clase, u == clase);

            foreach (Alumno aux in u.Alumnos)
            {
                if (aux == clase)
                {
                    j += aux;
                }
            }

            u.Jornadas.Add(j);
            return u;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Retorna una cadena con todos los datos de la universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder show = new StringBuilder();

            show.AppendLine("JORNADA:");

            for (int i = 0; i < uni.Jornadas.Count; i++)
            {
                show.AppendLine(uni[i].ToString());
            }

            return show.ToString();
        }

        /// <summary>
        /// Lee los datos de un archivo xml
        /// </summary>
        /// <returns></returns>
        public static bool Leer()
        {
            string fileName = "Universidad.xml";
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Leer(fileName, out Universidad aux);
        }

        /// <summary>
        /// Guarda los datos de un objeto Universidad en un archivo xml.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            string fileName = "Universidad.xml";
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar(fileName, uni);
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Retorna una cadena con todos los datos de la universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion
    }
}
