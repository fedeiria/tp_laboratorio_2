using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region "Atributos"
        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Obtiene y agrega un item a la lista de paquetes.
        /// </summary>
        public List<Paquete> Paquetes
        {
            set
            {
                this.paquetes = value;
            }
            get
            {
                return this.paquetes;
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Retorna una cadena con los datos de todos los paquetes que se encuentran en la lista.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder show = new StringBuilder();

            foreach (Paquete aux in ((Correo)elementos).Paquetes)
            {
                show.AppendLine(string.Format("{0} para {1} ({2})", aux.TrackingID, aux.DireccionEntrega, aux.Estado.ToString()));
            }

            return show.ToString();
        }

        /// <summary>
        /// Finaliza todos los hilos de la lista mockPaquetes.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread aux in this.mockPaquetes)
            {
                if (aux.IsAlive)
                {
                    aux.Abort();
                }
            }
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agrega un paquete a la lista de paquetes comprobando que el mismo ya no se encuentre guardado. Crea un hilo, lo inicializa y lo agrega a la lista de hilos. Graba los datos del paquete en la base de datos.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete aux in c.Paquetes)
            {
                if (aux == p)
                {
                    throw new TrackingIdRepetidoException($"El Tracking ID {aux.TrackingID} ya figura en la lista de envios.");
                }
            }

            try
            {
                c.Paquetes.Add(p);
                PaqueteDAO.Insertar(p);
                Thread hiloPaquete = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hiloPaquete);
                hiloPaquete.Start();

                return c;
            }
            catch (Exception e)
            {
                throw new Exception("Se produjo un error al intentar guardar el paquete en la base de datos.", e.InnerException);
            }
        }
        #endregion
    }
}
