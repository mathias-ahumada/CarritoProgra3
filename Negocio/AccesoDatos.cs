using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector 
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            string conexionLV = "server=(LocalDb)\\MSSQLLocalDB; database=CATALOGO_P3_DB; integrated security=true";
            string conexionMathias = "Data Source=DESKTOP-LPCCPED\\SQLEXPRESS;Initial Catalog=CATALOGO_P3_DB;Integrated Security=True";
            conexion = new SqlConnection(conexionMathias);
            comando = new SqlCommand();
        }
        public void setConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;

        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void ejecutarAccion()
        {
            comando.Connection= conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }

        public int ejecutarScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                int cantidad = (int)comando.ExecuteScalar();
                return cantidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion ()
        {
            if (lector != null) 
                lector.Close();
            conexion.Close();
        }

        public void setParametros(string clave, object valor)
        {
            comando.Parameters.AddWithValue(clave, valor);
        }
    }
}
