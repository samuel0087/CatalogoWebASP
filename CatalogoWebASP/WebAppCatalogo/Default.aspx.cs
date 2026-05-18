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
        private ArticuloNegocio nProducto = new ArticuloNegocio();
        private MarcaNegocio nMarca = new MarcaNegocio();
        private CategoriaNegocio nCategoria = new CategoriaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                List<Articulo> listaArticulos = nProducto.listar();

                if (!IsPostBack)
                {
                    cargarCatalogo(listaArticulos);

                    ddlMarca.DataSource = nMarca.listar();
                    ddlMarca.DataBind();
                    ddlMarca.Items.Insert(0, new ListItem("Todas las marcas", "0"));

                    ddlCategoria.DataSource = nCategoria.listar();
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, new ListItem("Todas las Categorias", "0"));

                    grillaCatalogo.Visible = true;

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

        public List<Articulo> filtratPorTexto(string filtro)
        {
            try
            {
                List<Articulo> lista = nProducto.listar().FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
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

        private void cargarCatalogo(List<Articulo> lista)
        {
            try
            {
                rtrArticulos.DataSource = lista;
                rtrArticulos.DataBind();
            }
            catch
            {
                Session.Add("error", new Exception("No es posible cargar el catalogo"));
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {

                List<Articulo> listaFiltrada = filtratPorTexto(txtBuscar.Text);

                listaFiltrada = (listaFiltrada.Count > 0 && ddlMarca.SelectedIndex != 0) ? listaFiltrada.FindAll(x => x.Marca.Nombre == ddlMarca.SelectedValue) : listaFiltrada;
                listaFiltrada = (listaFiltrada.Count > 0 && ddlCategoria.SelectedIndex != 0) ? listaFiltrada.FindAll(x => x.Categoria.Nombre == ddlCategoria.SelectedValue) : listaFiltrada;
                if (listaFiltrada.Count > 0)
                {


                    cargarCatalogo(listaFiltrada);
                    grillaCatalogo.Visible = listaFiltrada.Any();
                    pnlSinResultados.Visible = false;
                }
                else
                {
                    pnlSinResultados.Visible = !listaFiltrada.Any();
                    grillaCatalogo.Visible = listaFiltrada.Any();
                    rtrArticulos.DataSource = null;
                    rtrArticulos.DataBind();
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