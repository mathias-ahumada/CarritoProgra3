using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace carritoProgra3
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio= new ArticuloNegocio();
            dgvCatalogo.DataSource = negocio.listar();
            dgvCatalogo.DataBind();

        }

        protected void dgvCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}