using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public static class Calculadora
    {
        #region "Metodos"
        /// <summary>
        /// Comprueba que la cadena recibida sea un operador aritmetico equivalente a Suma, Resta, Multiplicacion o Division. Caso contrario asigna la operacion Suma.
        /// </summary>
        /// <param name="operador">Valor a comprobar</param>
        /// <returns>Operador valido, si el operador no es valido devuelve '+'</returns>
        private static string ValidarOperador(string operador)
        {
            string pattern = "[+---*-/]";

            if (Regex.IsMatch(operador, pattern))
            {
                return operador;
            }
           
            return operador = "+";
        }

        /// <summary>
        /// Realiza operaciones de Suma, Resta, Multiplicacion y Division con los datos recibidos. Valida que el parametro operador se encuentre entre los operaciones aritmeticas validas (+, -, *, /).
        /// </summary>
        /// <param name="num1">Dato recibido para operar</param>
        /// <param name="num2">Dato recibido para operar</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case "+":
                {
                    resultado = num1 + num2;
                    break;
                }
                case "-":
                {
                    resultado = num1 - num2;
                    break;
                }
                case "*":
                {
                    resultado = num1 * num2;
                    break;
                }
                case "/":
                {
                    resultado = num1 / num2;
                    break;
                }
            }

            return resultado;
        }
        #endregion
    }
}
