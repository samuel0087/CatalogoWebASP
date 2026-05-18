using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Microsoft.Ajax.Utilities;
using negocio;

namespace WebAppCatalogo
{
    public partial class AdminProducto : System.Web.UI.Page
    {
        private ArticuloNegocio nProducto = new ArticuloNegocio();
        private MarcaNegocio nMarca = new MarcaNegocio();
        private CategoriaNegocio nCategoria = new CategoriaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cargarCatalogo((List<Articulo>)nProducto.listar());
                    
                    ddlMarca.DataSource = nMarca.listar();
                    ddlMarca.DataBind();
                    ddlMarca.Items.Insert(0, new ListItem("Todas las marcas", "0"));

                    ddlCategoria.DataSource = nCategoria.listar();
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, new ListItem("Todas las Categorias", "0"));

                    tablaCatalogo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        private void cargarCatalogo(List<Articulo> lista)
        {
            try
            {
                rtrProductos.DataSource = lista;
                rtrProductos.DataBind();
            }
            catch
            {
                Session.Add("error", new Exception("No es posible cargar el catalogo"));
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("./FormProducto.aspx?edit=1");
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("../Error.aspx");
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtBuscar.Text.IsNullOrWhiteSpace())
                {
                    List<Articulo> listaFiltrada = nProducto.listar().FindAll(  x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()) ||
                                                                                x.Descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper()) ||
                                                                                x.Codigo.ToUpper().Contains(txtBuscar.Text.ToUpper()) );

                    if(listaFiltrada.Count > 0)
                    {
                        cargarCatalogo(listaFiltrada);
                        tablaCatalogo.Visible = listaFiltrada.Any();

                        Session.Add("lista", listaFiltrada );
                    }
                    else
                    {
                        pnlSinResultados.Visible = !listaFiltrada.Any();
                        tablaCatalogo.Visible = listaFiltrada.Any();
                        rtrProductos.DataSource = null;
                        rtrProductos.DataBind();
                    }
                }
                else
                {
                    cargarCatalogo(nProducto.listar());
                }

            }catch(Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string marca = ddlMarca.Text;
                if (!marca.IsNullOrWhiteSpace() && ddlMarca.SelectedValue != "0") 
                {
                    listaFiltrada = listaFiltrada.FindAll(x => x.Marca.Nombre.Contains(marca));
                    cargarCatalogo(listaFiltrada);
                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("../Error.aspx");
            }

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}