using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region "Atributos"
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
        private EEstado estado;
        private string trackingID;
        private string direccionEntrega;
        public event DelegadoEstado InformaEstado;
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Obtiene y agrega un estado de paquete.
        /// </summary>
        public EEstado Estado
        {
            set
            {
                this.estado = value;
            }
            get
            {
                return this.estado;
            }
        }

        /// <summary>
        /// Obtiene y agrega un numero de envio.
        /// </summary>
        public string TrackingID
        {
            set
            {
                this.trackingID = value;
            }
            get
            {
                return this.trackingID;
            }
        }

        /// <summary>
        /// Obtiene y agrega una direccion de entrega del paquete.
        /// </summary>
        public string DireccionEntrega
        {
            set
            {
                this.direccionEntrega = value;
            }
            get
            {
                return this.direccionEntrega;
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Informa el estado del paquete (Ingresado, EnViaje, Entregado).
        /// </summary>
        public void MockCicloDeVida()
        {
            this.InformaEstado.Invoke(this, null);
            Thread.Sleep(4000);
            this.Estado++;
            this.InformaEstado.Invoke(this, null);
            Thread.Sleep(4000);
            this.Estado++;
            this.InformaEstado.Invoke(this, null);
        }

        /// <summary>
        /// Retorna los datos del paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Retorna los datos del paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Comprueba si dos paquetes tienen el mismo trackingID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }

        /// <summary>
        /// Comprueba si dos paquetes no tienen el mismo trackingID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
