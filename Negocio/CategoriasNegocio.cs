using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CategoriasNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT ID, DESCRIPCION FROM CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IDCategoria = (int)datos.Lector["Id"];
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
        public void agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
                
            try
            {
                datos.setConsulta("insert into Categorias(Descripcion) Values ('" + nuevo.Nombre + "')");
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
                datos.setConsulta("DELETE FROM Categorias WHERE ID=@id");
                datos.setParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TieneProductosAsociados(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            // Consulta SQL para contar los productos asociados a la marca
            datos.setConsulta("SELECT COUNT(*) FROM articulos AS a INNER JOIN categorias AS c ON a.IdCategoria=c.ID WHERE c.ID=@IDCategoria;");
            datos.setParametros("@IDCategoria", categoria.IDCategoria);
            // Verifica cuántos productos asociados a la categoría hay
            int cantidadProductos = datos.ejecutarScalar();

            return cantidadProductos > 0;
        }
    }
}
