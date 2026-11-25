using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace ComercioWeb
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarMarcas();
            }
        }

        private void cargarMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            gvMarcas.DataSource = negocio.listar();
            gvMarcas.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Marca nueva = new Marca();
            MarcaNegocio negocio = new MarcaNegocio();

            nueva.Nombre = txtNombre.Text.Trim();

            if (nueva.Nombre != "" && !negocio.existe(nueva.Nombre))
            {
                negocio.agregar(nueva);
                txtNombre.Text = "";
                cargarMarcas();
            }
        }
        protected void gvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioMarca.aspx?id=" + id);
        }
        protected void gvMarcas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvMarcas.DataKeys[e.RowIndex].Value);

            MarcaNegocio negocio = new MarcaNegocio();

            negocio.eliminar(id);

            gvMarcas.DataSource = negocio.listar();
            gvMarcas.DataBind();
        }
    }
}