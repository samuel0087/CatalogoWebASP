using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCatalogo
{
    public partial class FormProducto : System.Web.UI.Page
    {
        private ArticuloNegocio nArticulo = new ArticuloNegocio();
        private MarcaNegocio nMarca = new MarcaNegocio();
        private CategoriaNegocio nCategoria = new CategoriaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategoria.DataSource = nCategoria.listar();
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, new ListItem("Seleccione una Categoria", "0"));


                ddlMarca.DataSource = nMarca.listar();
                ddlMarca.DataTextField = "Nombre";
                ddlMarca.DataValueField = "IdMarca";
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("Seleccione una marca", "0"));


                if (Request.QueryString["id"] != null)
                {
                    btnEliminar.Visible = true;
                    int id = int.Parse(Request.QueryString["id"]);
                    Articulo articulo = nArticulo.buscarPorId(id);

                    if(articulo != null)
                    {
                        txtCodigo.Text = articulo.Codigo;
                        txtNombre.Text = articulo.Nombre;
                        txtDescripcion.Text = articulo.Descripcion;
                        txtImagenUrl.Text = articulo.UrlImagen;
                        imgPreview.ImageUrl = articulo.UrlImagen;
                        txtPrecio.Text = articulo.Precio.ToString();

                        ddlCategoria.SelectedValue = articulo.Categoria.IdCategoria.ToString();
                        ddlMarca.SelectedValue = articulo.Marca.IdMarca.ToString();
                    }
                }
            }

        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AdminProducto.aspx", false);
            }
            catch
            {
                Session.Add("error", new Exception("No se pudo redirigir la pagina, por favor vuelva al inicio"));
            }
        }
    }
}