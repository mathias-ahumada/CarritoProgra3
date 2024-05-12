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
}
