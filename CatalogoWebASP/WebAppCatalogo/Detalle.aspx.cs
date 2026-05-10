using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCatalogo
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio nArticulo = new ArticuloNegocio();
            try
            {
                Articulo ArticuloDetalle;

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    ArticuloDetalle = nArticulo.buscarPorId(id);

                    if( ArticuloDetalle == null)
                    {
                        Session.Add("error", new Exception("Articulo no encontrado"));
                        Response.Redirect("Error.aspx", false);
                    }

                    if (!IsPostBack)
                    {
                        imgProducto.ImageUrl = ArticuloDetalle.UrlImagen;
                        lblNombre.Text = ArticuloDetalle.Nombre;
                        lblDescripcion.Text = ArticuloDetalle.Descripcion;
                        lblPrecio.Text = ArticuloDetalle.Precio.ToString();
                    }
                }
                else
                {
                    Session.Add("error", new Exception("Articulo no encontrado"));
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}