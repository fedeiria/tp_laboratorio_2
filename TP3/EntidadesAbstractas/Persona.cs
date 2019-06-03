using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region "Atributos"
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        private int dni;
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Obtiene y agrega el nombre de la persona.
        /// </summary>
        public string Nombre
        {
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
            get
            {
                return this.nombre;
            }
        }

        /// <summary>
        /// Obtiene y agrega el apellido de la persona.
        /// </summary>
        public string Apellido
        {
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
            get
            {
                return this.apellido;
            }
        }

        /// <summary>
        /// Obtiene y agrega el dni de la persona.
        /// </summary>
        public int DNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
            get
            {
                return this.dni;
            }
        }

        /// <summary>
        /// Agrega el dni de la persona.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Obtiene y agrega la nacionalidad de la persona a partir del enumerado ENacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            set
            {
                this.nacionalidad = value;
            }
            get
            {
                return this.nacionalidad;
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Valida que el dato ingresado sea mayor a 0 y menor a 90000000 para nacionalidad Argentina
        /// Y mayor a 89999999 y menor o igual a 99999999 para nacionalidad Extranjera.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad is ENacionalidad.Argentino)
            {
                if (dato > 0 && dato < 90000000)
                {
                    return dato;
                }

                throw new NacionalidadInvalidaException();
            }
            else
            {
                if (dato > 89999999 && dato <= 99999999)
                {
                    return dato;
                }

                throw new NacionalidadInvalidaException();
            }
        }

        /// <summary>
        /// Valida que la cadena ingresada sea numerica y este dentro de los parametros permitidos.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int value = 0;

            if (dato.Length > 6 && dato.Length < 9)
            {
                foreach (char c in dato)
                {
                    if (!char.IsNumber(c))
                    {
                        throw new DniInvalidoException();
                    }
                }

                value = this.ValidarDni(nacionalidad, int.Parse(dato));
            }
            else
            {
                throw new DniInvalidoException();
            }

            return value;
        }

        /// <summary>
        /// Valida que la cadena ingresada este compuesta por letras del abecedario.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if (!char.IsLetter(c))
                {
                    dato = string.Empty;
                }
            }

            return dato;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Retorna una cadena con los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}\nNACIONALIDAD: {this.Nacionalidad}\n\n");
        }
        #endregion
    }
}
