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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                ArticuloNegocio nArticulos = new ArticuloNegocio();
                List<Articulo> listaArticulos = nArticulos.listar();

                if (!IsPostBack)
                {
                    rtrArticulos.DataSource = listaArticulos;
                    rtrArticulos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                string valor = ((Button)sender).CommandArgument;
                if (valor != null)
                {
                    Response.Redirect("Detalle.aspx?id=" + valor, false);
                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
            
        }
    }
}