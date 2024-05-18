using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta(@"	SELECT A.ID, 
                                A.CODIGO, 
                                A.NOMBRE, 
                                A.DESCRIPCION, 
                                A.IdMarca, 
                                M.Descripcion AS DSM,
                                A.IdCategoria, 
                                C.Descripcion AS DSC,
                                A.Precio,
                                I.ImagenUrl
                                
                                FROM ARTICULOS A 
                                INNER JOIN MARCAS M ON (A.IdMarca=M.Id)
                                INNER JOIN CATEGORIAS C ON (A.IdCategoria=C.Id)
                                INNER JOIN IMAGENES I ON(A.Id = I.IdArticulo)
                                GROUP BY A.Id,A.CODIGO, A.NOMBRE, A.DESCRIPCION, A.IdMarca, 
                                M.Descripcion,A.IdCategoria, C.Descripcion,A.Precio,I.ImagenUrl");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.IDArticulo = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Nombre = (string)datos.Lector["DSM"];
                    aux.Marca.IDMarca = (int)datos.Lector["IDMarca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Nombre = (string)datos.Lector["DSC"];
                    aux.Categoria.IDCategoria = (int)datos.Lector["IDCategoria"];

                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.iman = new Imagen();
                    aux.iman.ImagenUrl = (string)datos.Lector["ImagenUrl"];

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
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Insertar en ARTICULOS
                string consulta = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IDMarca, @IDCategoria);";
                datos.setConsulta(consulta);

                // Establecer parámetros para el artículo
                datos.setParametros("@Codigo", nuevo.Codigo);
                datos.setParametros("@Nombre", nuevo.Nombre);
                datos.setParametros("@Descripcion", nuevo.Descripcion);
                datos.setParametros("@Precio", nuevo.Precio);
                datos.setParametros("@IDMarca", nuevo.Marca.IDMarca);
                datos.setParametros("@IDCategoria", nuevo.Categoria.IDCategoria);
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
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("UPDATE articulos SET Codigo=@codigo,Nombre=@nombre,Descripcion=@Descripcion,IdMarca=@IdMarca,IdCategoria=@IdCategoria,Precio=@Precio WHERE Id=@id");

                datos.setParametros("@codigo", articulo.Codigo);
                datos.setParametros("@nombre", articulo.Nombre);
                datos.setParametros("@descripcion", articulo.Descripcion);
                datos.setParametros("@idMarca", articulo.Marca.IDMarca);
                datos.setParametros("@idCategoria", articulo.Categoria.IDCategoria);
                datos.setParametros("@precio", articulo.Precio);
                datos.setParametros("@Id", articulo.IDArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int obtenerIDArticulo()
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo nuevo = new Articulo();

            try
            {
                datos.setConsulta("SELECT * FROM Articulos WHERE ID = (SELECT MAX(ID) FROM Articulos);");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    nuevo.IDArticulo = (int)datos.Lector["Id"];
                }

                return nuevo.IDArticulo;

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
                datos.setConsulta("DELETE FROM Articulos WHERE ID=@id");
                datos.setParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> ListaConSp()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion AS Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, Precio, M.Id AS IDMarca, C.Id AS IDCategoria FROM Articulos AS A, Marcas AS M, Categorias AS C  WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria  ";


                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.IDArticulo = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];
                    aux.Marca.IDMarca = (int)datos.Lector["IDMarca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Categoria.IDCategoria = (int)datos.Lector["IDCategoria"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"	SELECT A.ID, 
                                A.CODIGO, 
                                A.NOMBRE, 
                                A.DESCRIPCION, 
                                A.IdMarca, 
                                M.Descripcion AS DSM,
                                A.IdCategoria, 
                                C.Descripcion AS DSC,
                                A.Precio,
                                I.ImagenUrl
                                
                                FROM ARTICULOS A 
                                INNER JOIN MARCAS M ON (A.IdMarca=M.Id)
                                INNER JOIN CATEGORIAS C ON (A.IdCategoria=C.Id)
                                INNER JOIN IMAGENES I ON(A.Id = I.IdArticulo)
                                GROUP BY A.Id,A.CODIGO, A.NOMBRE, A.DESCRIPCION, A.IdMarca, 
                                M.Descripcion,A.IdCategoria, C.Descripcion,A.Precio,I.ImagenUrl";


                datos.setConsulta(consulta);
              //  datos.setProcedimiento(listar);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.IDArticulo = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Nombre = (string)datos.Lector["DSM"];
                    aux.Marca.IDMarca = (int)datos.Lector["IDMarca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Nombre = (string)datos.Lector["DSC"];
                    aux.Categoria.IDCategoria = (int)datos.Lector["IDCategoria"];

                    aux.iman = new Imagen();
                    aux.iman.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}