using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class MarcasNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT ID, DESCRIPCION FROM MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IDMarca = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("insert into MARCAS(Descripcion) Values ('" + nuevo.Nombre+ "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("DELETE FROM Marcas WHERE ID=@id");
                datos.setParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TieneProductosAsociados(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            // Consulta SQL para contar los productos asociados a la marca
            datos.setConsulta("SELECT COUNT(*) FROM articulos AS a INNER JOIN marcas AS m ON a.IdMarca=m.ID WHERE m.ID=@IDMarca;");
            datos.setParametros("@IDMarca", marca.IDMarca);
            // Verifica cuántos productos asociados a la marca hay
            int cantidadProductos = datos.ejecutarScalar();
            
            return cantidadProductos > 0;
        }
    }
}
