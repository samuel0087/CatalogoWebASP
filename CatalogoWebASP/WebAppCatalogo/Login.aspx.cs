using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using Microsoft.Ajax.Utilities;

namespace WebAppCatalogo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioNegocio nUsuario = new UsuarioNegocio();

            try
            {
                if(!txtEmail.Text.IsNullOrWhiteSpace() && !txtPassword.Text.IsNullOrWhiteSpace()) 
                {
                    user.Email = txtEmail.Text;
                    user.Password = txtPassword.Text;

                    Usuario usuarioLogueado = nUsuario.Login(user);

                    if(usuarioLogueado != null)
                    {
                        Session.Add("user", usuarioLogueado);
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        Session.Add("error", new Exception("Usuario y/o contraseña incorrecta/s"));
                        Response.Redirect("Error.aspx", false);
                    }
                }

            }
            catch (Exception ex) 
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}