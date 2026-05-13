using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace WebAppCatalogo
{
    public partial class AdminProducto : System.Web.UI.Page
    {
        private ArticuloNegocio nProducto = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                rtrProductos.DataSource = (List<Articulo>)nProducto.listar();
                rtrProductos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}