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
    public partial class FormularioMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "")
                {
                    MarcaNegocio negocio = new MarcaNegocio();

                    Marca seleccionada = (negocio.listar(id))[0];

                    txtId.Text = id;
                    txtNombre.Text = seleccionada.Nombre;
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Marca nueva = new Marca();
            MarcaNegocio negocio = new MarcaNegocio();

            nueva.Id = int.Parse(txtId.Text);
            nueva.Nombre = txtNombre.Text.Trim();

            negocio.modificar(nueva);

            Response.Redirect("Marcas.aspx");
        }
    }
}