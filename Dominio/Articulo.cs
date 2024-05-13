using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Articulo
    {

        public Articulo()
        {
            Imagenes = new List<Imagen>();
        }

        //public static Image Imagen { get; internal set; }
        public int IDArticulo { get; set; }

        [DisplayName("Codigo ")]
        public string Codigo { get; set; }

        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Precio")]
        public decimal Precio { get; set; }

        [DisplayName("Marca")]
        public Marca Marca { get; set; }

        [DisplayName("Categoria")]
        public Categoria Categoria { get; set; }

        public List<Imagen> Imagenes { get; set; }
    }


    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            lista.Add(new Articulo());
            lista.Add(new Articulo()); /*creo dos intancia para trabajar en la tabla*/

            Marca marca1 = new Marca();
            marca1.IDMarca = 1;
            marca1.Nombre = "Samsung";

            Categoria categoria1 = new Categoria();
            categoria1.IDCategoria = 10;
            categoria1.Nombre = "Teléfonos móviles";

            lista[0].IDArticulo = 1;
            lista[0].Codigo = "15";
            lista[0].Descripcion = "Galaxy A05 128GB 4G";
            lista[0].Nombre = "Celular";
            lista[0].Precio = 324299;
            lista[0].Marca = marca1;
            lista[0].Categoria = categoria1;

            Marca marca2 = new Marca();
            marca2.IDMarca = 2;
            marca2.Nombre = "Motorola";

            Categoria categoria2 = new Categoria();
            categoria2.IDCategoria = 11;
            categoria2.Nombre = "Accesorios";

            lista[1].IDArticulo = 2;
            lista[1].Codigo = "24";
            lista[1].Descripcion = "Cargador 68W Salida tipo C";
            lista[1].Nombre = "Cargador";
            lista[1].Precio = 72000;
            lista[1].Marca = marca2;
            lista[1].Categoria = categoria2;


            return lista;


        }

    }

}
