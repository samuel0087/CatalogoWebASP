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
                    cargarCatalogo(nProducto.listar());
                    
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

        public List<Articulo> filtratPorTexto(string filtro) 
        {
            try
            {
               List<Articulo> lista = nProducto.listar().FindAll(   x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                                                                                    x.Descripcion.ToUpper().Contains(filtro.ToUpper()) ||
                                                                                    x.Codigo.ToUpper().Contains(filtro.ToUpper()));

                return lista;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                return null;
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                List<Articulo> listaFiltrada = filtratPorTexto(txtBuscar.Text);

                listaFiltrada = (listaFiltrada.Count > 0 && ddlMarca.SelectedIndex != 0) ? listaFiltrada.FindAll(x => x.Marca.Nombre == ddlMarca.SelectedValue) : listaFiltrada;
                listaFiltrada = (listaFiltrada.Count > 0 && ddlCategoria.SelectedIndex != 0) ?  listaFiltrada.FindAll(x => x.Categoria.Nombre == ddlCategoria.SelectedValue) : listaFiltrada;
                if (listaFiltrada.Count > 0)
                {


                    cargarCatalogo(listaFiltrada);
                    tablaCatalogo.Visible = listaFiltrada.Any();
                }
                else
                {
                    pnlSinResultados.Visible = !listaFiltrada.Any();
                    tablaCatalogo.Visible = listaFiltrada.Any();
                    rtrProductos.DataSource = null;
                    rtrProductos.DataBind();
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}