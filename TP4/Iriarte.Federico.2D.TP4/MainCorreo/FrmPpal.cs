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

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo = null;

        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            FormClosing += FrmPpal_FormClosing;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);

            nuevoPaquete.InformaEstado += paq_InformaEstado;

            if (!(this.mtxtTrackingID.MaskFull && !(string.IsNullOrEmpty(txtDireccion.Text))))
            {
                MessageBox.Show($"Los campos '{this.lblTrackingID.Text}' y '{this.label1.Text}' no pueden estar vacios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.mtxtTrackingID.Focus();
            }
            else
            {
                try
                {
                    correo += nuevoPaquete;
                    this.mtxtTrackingID.Focus();
                }
                catch (TrackingIdRepetidoException idRepetido)
                {
                    MessageBox.Show(idRepetido.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.mtxtTrackingID.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.mtxtTrackingID.Focus();
                }
            }
            
            this.txtDireccion.Clear();
            this.mtxtTrackingID.Clear();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                correo.FinEntregas();
            }
            catch (Exception threadException)
            {
                MessageBox.Show(threadException.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete aux in correo.Paquetes)
            {
                if (aux.Estado is Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(aux);
                }
                else if (aux.Estado is Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(aux);
                }
                else
                {
                    this.lstEstadoEntregado.Items.Add(aux);
                }
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            try
            {
                if (!(elemento is null))
                {
                    this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                    GuardaString.Guardar(elemento.MostrarDatos(elemento), "salida.txt");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
