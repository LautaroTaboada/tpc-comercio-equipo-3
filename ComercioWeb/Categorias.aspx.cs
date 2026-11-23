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
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                dgvCategorias.DataSource = negocio.listar();
                dgvCategorias.DataBind();
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            if (!string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                if (!negocio.existe(txtNombre.Text.Trim()))
                {
                    Categoria nueva = new Categoria();
                    nueva.Nombre = txtNombre.Text.Trim();

                    negocio.agregar(nueva);

                    dgvCategorias.DataSource = negocio.listar();
                    dgvCategorias.DataBind();

                    txtNombre.Text = "";
                    lblMensaje.Text = "Categoria agregada correctamente";
                }
                else
                {
                    lblMensaje.Text = "La categoria ya existe";
                }
            }
            else
            {
                lblMensaje.Text = "Debe ingresar un nombre";
            }
        }
        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCategoria.aspx?id=" + id);
        }
    }
}