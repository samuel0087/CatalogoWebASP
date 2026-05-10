using datos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public Usuario Login(Usuario user) 
        {
            string query = "SELECT Id, nombre, apellido, urlImagenPerfil, admin FROM USERS WHERE email = @correo AND pass = @password";
            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@correo", user.Email);
                datos.setearParametro("@password", user.Password);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    user.Nombre = datos.Lector["nombre"] is DBNull ? null : (string)datos.Lector["nombre"];
                    user.Apellido = datos.Lector["apellido"] is DBNull ? null : (string)datos.Lector["apellido"];
                    user.Admin = !(datos.Lector["admin"] is DBNull) && (bool)datos.Lector["admin"];
                    return user;
                }

                return null;            
            }
            catch (Exception ex)
            {
                throw new Exception("Problema buscando el usuario.", ex);
            }
        }
    }
}
