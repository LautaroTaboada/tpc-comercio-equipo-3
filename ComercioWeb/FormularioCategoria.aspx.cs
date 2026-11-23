using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace ComercioWeb
{
    public partial class FormularioCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "")
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();

                    Categoria seleccionada = (negocio.listar(id))[0];

                    txtId.Text = id;
                    txtNombre.Text = seleccionada.Nombre;
                }
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}