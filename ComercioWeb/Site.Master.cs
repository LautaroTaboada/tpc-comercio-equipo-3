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
            bool esPublica = Page is boostrabdesdecero.Login || Page is boostrabdesdecero.Registro || Page is boostrabdesdecero.RecuperarPassword || Page is Error;
            bool esAdmin = Seguridad.esAdmin(Session["usuario"]);

            if (!esPublica && !Seguridad.sesionActiva(Session["usuario"]))
            {
                Response.Redirect("Login.aspx", false);
            }
            else if (!esAdmin && esPaginaAdmin())
            {
                Session.Add("error", "Se requieren permisos de administrador para acceder a esta pantalla.");
                Response.Redirect("Error.aspx", false);
            }

            if (Session["usuario"] != null)
            {
                menuConSesion.Visible = true;
                menuSinSesion.Visible = false;

                phProductos.Visible = esAdmin;
                phProveedores.Visible = esAdmin;
                phCompras.Visible = esAdmin;
                phAdministrar.Visible = esAdmin;
            }
            else
            {
                menuConSesion.Visible = false;
                menuSinSesion.Visible = true;
            }
        }

        private bool esPaginaAdmin()
        {
            return Page is Productos || Page is ProductosInactivos || Page is FormularioProducto
                || Page is Proveedores || Page is ProveedoresInactivos || Page is FormularioProveedor
                || Page is NuevaCompra
                || Page is Marcas || Page is MarcasInactivas || Page is FormularioMarca
                || Page is Categorias || Page is CategoriasInactivas || Page is FormularioCategoria;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}