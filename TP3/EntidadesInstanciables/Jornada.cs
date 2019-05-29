using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region "Atributos"
        private Profesor instructor;
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Obtiene y establece una clase del enumerado EClases
        /// </summary>
        public Universidad.EClases Clase
        {
            set
            {
                this.clase = value;
            }
            get
            {
                return this.clase;
            }
        }

        /// <summary>
        /// Obtiene y establece un objeto de la clase Profesor.
        /// </summary>
        public Profesor Instructor
        {
            set
            {
                this.instructor = value;
            }
            get
            {
                return this.instructor;
            }
        }

        /// <summary>
        /// Obtiene y establece un objeto de la lista de alumnos.
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
        #endregion

        #region "Metodos"
        /// <summary>
        /// Lee y retorna una cadena a partir de un archivo de texto.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string data = string.Empty;
            string fileName = "Jornada.txt";
            
            texto.Leer(fileName, out data);

            return data;
        }

        /// <summary>
        /// Guarda los datos de una Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string fileName = "Jornada.txt";

            return texto.Guardar(fileName, jornada.ToString());
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Retorna una cadena con los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder show = new StringBuilder();

            show.AppendFormat($"CLASE DE {this.Clase} POR {this.Instructor.ToString()}");
            show.AppendLine("\nALUMNOS:");

            foreach (Alumno aux in this.Alumnos)
            {
                show.AppendLine(aux.ToString());
            }

            show.AppendLine("<---------------------------------------------->");

            return show.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Retorna true si un alumno ya forma parte de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno aux in j.Alumnos)
            {
                if (aux == a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna false si un alumno no forma parte de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada siempre y cuando el mismo ya no forme parte de la lista.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                throw new AlumnoRepetidoException();
            }
            
            j.Alumnos.Add(a);
            return j;
        }
        #endregion
    }
}
