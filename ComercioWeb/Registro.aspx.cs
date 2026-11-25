using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace boostrabdesdecero
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.Nombre = txtNombre.Text.Trim();
            usuario.Apellido = txtApellido.Text.Trim();
            usuario.NombreUsuario = txtUsuario.Text.Trim();
            usuario.Password = txtPassword.Text;

            string repetirPassword = txtRepetirPassword.Text;

            if (usuario.Nombre == "" || usuario.Apellido == "" ||
                usuario.NombreUsuario == "" || usuario.Password == "" ||
                repetirPassword == "")
            {
                Response.Write("<script>alert('Todos los campos son obligatorios.');</script>");
                return;
            }

            if (usuario.Password != repetirPassword)
            {
                Response.Write("<script>alert('Las contraseñas no coinciden.');</script>");
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            if (negocio.existeUsuario(usuario.NombreUsuario))
            {
                Response.Write("<script>alert('El nombre de usuario ya existe.');</script>");
                return;
            }

            negocio.registrar(usuario);

            Response.Write("<script>alert('Usuario registrado correctamente.');</script>");
        }
    }
}