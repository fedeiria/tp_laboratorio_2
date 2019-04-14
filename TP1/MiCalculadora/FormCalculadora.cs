using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Limpia los TextBox y ComboBox del programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = 0;
                }
            }

            this.lblResultado.Text = string.Empty;
            this.txtNumero1.Focus();
        }

        /// <summary>
        /// Cierra el programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Realiza el calculo de una operacion aritmetica en base al valor ingresado en el parametro operador.
        /// </summary>
        /// <param name="numero1">Operando</param>
        /// <param name="numero2">Operando</param>
        /// <param name="operador">Operador</param>
        /// <returns>Resultado de la operacion. Si el operador no es valido calcula la suma.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            double resultado = Calculadora.Operar(n1, n2, operador);

            return resultado;
        }

        /// <summary>
        /// Llama al metodo Operar de la clase Calculadora y muestra el resultado devuelto de la operacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Convert.ToString(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));
        }

        /// <summary>
        /// Llama al metodo DecimalBinario de la clase Numero y muestra el resultado devuelto de la operacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();

            lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
        }

        /// <summary>
        /// Llama al metodo BinarioDecimal de la clase Numero y muestra el resultado devuelto de la operacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();

            lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
        }
    }
}
