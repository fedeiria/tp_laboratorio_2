using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region "Constructores"
        /// <summary>
        /// constructor por defecto.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="numero">Valor recibido</param>
        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="strNumero">Parametro recibido</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Llama al metodo ValidarNumero y asigna el valor a la propiedad 'numero'.
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Comprueba la cadena ingresada. Si es numerica retorna el valor en formato double. Caso contrario le asigna cero.
        /// </summary>
        /// <param name="strNumero">Cadena a comprobar</param>
        /// <returns>Numero en formato double</returns>
        private double ValidarNumero(string strNumero)
        {
            double valor = 0;

            if (double.TryParse(strNumero, out valor))
            {
                return valor;
            }

            return valor;
        }

        /// <summary>
        /// Convierte la representacion en forma de cadena de un numero binario en formato decimal. Si la cadena no cumple con el formato binario devuelve 'Valor invalido'.
        /// </summary>
        /// <param name="binario">Cadena a comprobar</param>
        /// <returns>Resultado de la conversion</returns>
        public string BinarioDecimal(string binario)
        {
            int contador = 0;
            bool flag = false;
            double decimales = 0;
            string cadenaDecimal;

            for (int i = binario.Length - 1; i >= 0; i--)
            {
                if (binario[i] == '1' || binario[i] == '0')
                {
                    if (binario[i] == '1')
                    {
                        decimales += Math.Pow(2, contador);
                    }

                    flag = true;
                    contador++;
                }
                else
                {
                    break;
                }
            }

            if (flag)
            {
                cadenaDecimal = Convert.ToString(decimales);
            }
            else
            {
                cadenaDecimal = "Valor invalido";
            }

            return cadenaDecimal;
        }

        /// <summary>
        /// Convierte la parte entera de un numero de punto flotante en formato binario. Si el valor ingresado no es numerico devuelve 'Valor invalido'.
        /// </summary>
        /// <param name="binario">Cadena a comprobar</param>
        /// <returns>Resultado de la conversion en formato entero</returns>
        public string DecimalBinario(double numero)
        {
            string binario = string.Empty;

            int auxNumero = Convert.ToInt32(numero);

            if (auxNumero > 0)
            {
                while (true)
                {
                    if ((auxNumero % 2) == 0)
                    {
                        binario = "0" + binario;
                    }
                    else
                    {
                        binario = "1" + binario;
                    }

                    auxNumero /= 2;

                    if (auxNumero <= 0)
                    {
                        break;
                    }
                }

                return binario;
            }
            else
            {
                return binario = "Numero invalido";
            }
        }

        /// <summary>
        /// Convierte la parte entera de la representacion en forma de cadena de un numero decimal en formato binario. Si la cadena no cumple con el formato binario devuelve 'Valor invalido'.
        /// </summary>
        /// <param name="binario">Cadena a comprobar</param>
        /// <returns>Resultado de la conversion</returns>
        public string DecimalBinario(string numero)
        {
            string binario = string.Empty;

            bool esNumerico = int.TryParse(numero, out int numeroAConvertir);

            while (esNumerico)
            {
                if ((numeroAConvertir % 2) == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }

                numeroAConvertir /= 2;

                if (numeroAConvertir < 1)
                {
                    break;
                }
            }

            if (!esNumerico)
            {
                binario = "Valor invalido";
            }

            return binario;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Realiza la suma entre dos objetos de la clase Numero
        /// </summary>
        /// <param name="n1">Numero a sumar</param>
        /// <param name="n2">Numero a sumar</param>
        /// <returns>Resultado</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Realiza la resta entre dos objetos de la clase Numero
        /// </summary>
        /// <param name="n1">Numero a restar</param>
        /// <param name="n2">Numero a restar</param>
        /// <returns>Resultado</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la multiplicacion entre dos objetos de la clase Numero
        /// </summary>
        /// <param name="n1">Numero a multiplicar</param>
        /// <param name="n2">Numero a multiplicar</param>
        /// <returns>Resultado</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la division entre dos objetos de la clase Numero
        /// </summary>
        /// <param name="n1">Numero a dividir</param>
        /// <param name="n2">Numero a dividir</param>
        /// <returns>Resultado</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }
        #endregion
    }
}
