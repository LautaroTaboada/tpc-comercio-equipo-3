using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace ComercioWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is boostrabdesdecero.Login || Page is boostrabdesdecero.Registro || Page is boostrabdesdecero.RecuperarPassword || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }

            if (Session["usuario"] != null)
            {
                menuConSesion.Visible = true;
                menuSinSesion.Visible = false;
            }
            else
            {
                menuConSesion.Visible = false;
                menuSinSesion.Visible = true;
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}