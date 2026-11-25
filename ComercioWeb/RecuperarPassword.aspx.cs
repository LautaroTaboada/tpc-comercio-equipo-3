using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace boostrabdesdecero
{
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();

            if (usuario == "")
            {
                Response.Write("<script>alert('Ingresá tu nombre de usuario.');</script>");
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            if (negocio.existeUsuario(usuario))
            {
                Response.Write("<script>alert('Usuario encontrado.');</script>");
            }
            else
            {
                Response.Write("<script>alert('No se encontró el usuario.');</script>");
            }
        }
    }
}