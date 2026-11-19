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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuarioIngresado = new Usuario();

            usuarioIngresado.NombreUsuario = txtEmail.Text;
            usuarioIngresado.Password = txtPassword.Text;

            UsuarioNegocio negocio = new UsuarioNegocio();

            if (negocio.loguear(usuarioIngresado))
            {
                Session["usuario"] = usuarioIngresado;

                if (usuarioIngresado.TipoUsuario == TipoUsuario.ADMINISTRADOR)
                {
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Usuario o contraseña incorrectos');</script>");
            }
        }
    }
}