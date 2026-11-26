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
            string email = txtEmail.Text.Trim();

            if (usuario == "" || email == "")
            {
                Response.Write("<script>alert('Completá todos los campos.');</script>");
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            bool coincide = negocio.verificarUsuarioEmail(usuario, email);

            if (coincide)
            {
                try
                {
                    EmailService servicio = new EmailService();

                    servicio.enviarEmail(
                        email,
                        "Prueba ComercioWeb",
                        "El servicio de correo funciona correctamente."
                    );

                    Response.Write("<script>alert('Correo enviado correctamente.');</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('No se pudo enviar el correo. Revisá la configuración.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('El usuario y el correo no coinciden.');</script>");
            }
        }
    }
}