using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace carritoProgra3
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio= new ArticulosNegocio();
            dgvCatalogo.DataSource = negocio.ListaConSp();
            dgvCatalogo.DataBind();

        }

        protected void dgvCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            // comentario de prueba         
        }
    }
}