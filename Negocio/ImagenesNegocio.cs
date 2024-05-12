using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenesNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT Id, IdArticulo, ImagenUrl FROM imagenes ORDER BY IdArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.IDImagen = (int)datos.Lector["Id"];
                    aux.IDArticulo = (int)datos.Lector["IdArticulo"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

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

        public void agregarImagen(Imagen nuevaImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Insertar en IMAGENES
                string consulta = "INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl);";
                datos.setConsulta(consulta);

                // Establecer parámetros para la imagen
                datos.setParametros("@IdArticulo", nuevaImagen.IDArticulo);
                datos.setParametros("@ImagenUrl", nuevaImagen.ImagenUrl);
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

        public void actualizarImagen(Imagen nuevaImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Actualizar IMAGENES
                string consulta = "UPDATE imagenes SET ImagenUrl=@ImagenUrl WHERE IdArticulo=@IdArticulo AND ID=@ID;";
                datos.setConsulta(consulta);

                // Establecer parámetros para la imagen
                // Si no especificamos ID, se actualizarían TODAS las imágenes dadas de cierto artículo
                datos.setParametros("@IdArticulo", nuevaImagen.IDArticulo);
                datos.setParametros("@ImagenUrl", nuevaImagen.ImagenUrl);
                datos.setParametros("@ID", nuevaImagen.IDImagen);
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
                datos.setConsulta("DELETE FROM Imagenes WHERE ID=@id");
                datos.setParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TieneProductosAsociados(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            // Consulta SQL para contar los productos asociados a la imagen
            datos.setConsulta("SELECT COUNT(*) FROM IMAGENES I INNER JOIN Articulos A ON I.IDArticulo=A.ID WHERE I.ID=@IDImagen;");
            datos.setParametros("@IDImagen", imagen.IDImagen);
            // Verifica cuántos productos asociados a la imagen hay
            int cantidadProductos = datos.ejecutarScalar();

            return cantidadProductos > 0;
        }

        public void vincularImagenes(List<Articulo> articulos, List<Imagen> imagenes)
        // Vamos artículo por artículo y recorremos todas las imágenes para agregarlas
        // a la lista de imágenes de cada artículo, cuando sea apropiado.
        {
            foreach (Articulo miArticulo in articulos)
            {
                foreach (Imagen miImagen in imagenes)
                {
                    if (miImagen.IDArticulo.ToString() == miArticulo.IDArticulo.ToString())
                    {
                        miArticulo.Imagenes.Add(miImagen);
                    }
                }
            }
        }
    }
}
