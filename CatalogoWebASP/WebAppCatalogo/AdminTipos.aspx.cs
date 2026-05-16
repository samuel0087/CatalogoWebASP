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
    public partial class AdminTipos : System.Web.UI.Page
    {
        private string Tipo
        {
            get
            {
                return (Request.QueryString["tipo"] ?? "").ToLower();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Tipo != "marca" && Tipo != "categoria")
                {
                    Session.Add("error", new Exception("Tipo de administración inválido."));
                    Response.Redirect("Error.aspx", false);
                    return;
                }

                if (!IsPostBack)
                {
                    configurarPantalla();
                    cargarListado();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        private void configurarPantalla()
        {
            if (Tipo == "marca")
            {
                lblTitulo.Text = "Administrar marcas";
                lblSubtitulo.Text = "Crear, modificar o eliminar marcas del catálogo.";
            }
            else
            {
                lblTitulo.Text = "Administrar categorías";
                lblSubtitulo.Text = "Crear, modificar o eliminar categorías del catálogo.";
            }
        }

        private void cargarListado()
        {
            List<ItemAdministrable> lista = new List<ItemAdministrable>();

            if (Tipo == "marca")
            {
                MarcaNegocio negocio = new MarcaNegocio();

                lista = negocio.listar()
                    .Select(x => new ItemAdministrable
                    {
                        Id = x.IdMarca,
                        Nombre = x.Nombre
                    })
                    .ToList();
            }
            else
            {
                CategoriaNegocio negocio = new CategoriaNegocio();

                lista = negocio.listar()
                    .Select(x => new ItemAdministrable
                    {
                        Id = x.IdCategoria,
                        Nombre = x.Nombre
                    })
                    .ToList();
            }

            rtrItems.DataSource = lista;
            rtrItems.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
        //            return;

        //        int id = 0;
        //        int.TryParse(hfId.Value, out id);

        //        if (Tipo == "marca")
        //        {
        //            MarcaNegocio negocio = new MarcaNegocio();

        //            Marca marca = new Marca
        //            {
        //                IdMarca = id,
        //                Nombre = txtDescripcion.Text.Trim()
        //            };

        //            if (id == 0)
        //                negocio.agregar(marca);
        //            else
        //                negocio.modificar(marca);
        //        }
        //        else
        //        {
        //            CategoriaNegocio negocio = new CategoriaNegocio();

        //            Categoria categoria = new Categoria
        //            {
        //                IdCategoria = id,
        //                Nombre = txtDescripcion.Text.Trim()
        //            };

        //            if (id == 0)
        //                negocio.agregar(categoria);
        //            else
        //                negocio.modificar(categoria);
        //        }

        //        limpiarFormulario();
        //        cargarListado();
        //    }
        //    catch (Exception ex)
        //    {
        //        Session.Add("error", ex);
        //        Response.Redirect("Error.aspx", false);
        //    }
        //}

        //protected void btnEditar_Click(object sender, EventArgs e)
        //{
        //    string[] datos = ((Button)sender).CommandArgument.Split('|');

        //    hfId.Value = datos[0];
        //    txtDescripcion.Text = datos[1];

        //    btnGuardar.Text = "Modificar";
        //}

        //protected void btnEliminar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int id = int.Parse(((Button)sender).CommandArgument);

        //        if (Tipo == "marca")
        //        {
        //            MarcaNegocio negocio = new MarcaNegocio();
        //            negocio.eliminar(id);
        //        }
        //        else
        //        {
        //            CategoriaNegocio negocio = new CategoriaNegocio();
        //            negocio.eliminar(id);
        //        }

        //        limpiarFormulario();
        //        cargarListado();
        //    }
        //    catch (Exception ex)
        //    {
        //        Session.Add("error", ex);
        //        Response.Redirect("Error.aspx", false);
        //    }
        //}

        //protected void btnLimpiar_Click(object sender, EventArgs e)
        //{
        //    limpiarFormulario();
        //}

        //private void limpiarFormulario()
        //{
        //    hfId.Value = "";
        //    txtDescripcion.Text = "";
        //    btnGuardar.Text = "Guardar";
        //}
    }
}
