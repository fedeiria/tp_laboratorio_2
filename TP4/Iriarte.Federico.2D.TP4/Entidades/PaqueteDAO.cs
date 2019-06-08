using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region "Atributos"
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor estatico.
        /// </summary>
        static PaqueteDAO()
        {
            string rutaConexion = "Data Source = .\\SQLEXPRESS; Initial Catalog = correo-sp-2017; Integrated Security = true";
            conexion = new SqlConnection(rutaConexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Escribe los datos de un paquete en la tabla Paquetes.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            string sqlSentence = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES (@direccionEntrega, @trackingID, @alumno)";
            comando.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
            comando.Parameters.AddWithValue("@trackingID", p.TrackingID);
            comando.Parameters.AddWithValue("@alumno", "Federico Iriarte");

            try
            {
                comando.CommandText = sqlSentence;
                conexion.Open();
                comando.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            finally
            {
                comando.Parameters.Clear();
                conexion.Close();
            }
        }
        #endregion
    }
}
