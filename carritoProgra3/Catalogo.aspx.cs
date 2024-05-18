using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Net;

namespace carritoProgra3
{
    public partial class Catalogo : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) {
                LoadData();
            }
        }

        private void LoadData()
        {
            var articuloBusinees = new ArticulosNegocio();
            try
            {
                listaArticulos = articuloBusinees.listar();

                foreach (var item in listaArticulos) 
                {
                    if (!CargarImagen(item.iman.ImagenUrl))
                    {
                        item.iman.ImagenUrl = "https://img.freepik.com/vector-gratis/ilustracion-icono-galeria_53876-27002.jpg?size=626&ext=jpg&ga=GA1.1.1687694167.1713916800&semt=ais";
                    }
                }
                dgvArticulos.DataSource = listaArticulos;
                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar obtener los articulos: " + ex.Message);
            }
        }


        private bool CargarImagen(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return (response.StatusCode == HttpStatusCode.OK);
                }
            }
            catch
            {
                return false;
            }
        }



    }
}