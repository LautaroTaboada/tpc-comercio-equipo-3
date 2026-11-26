using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComercioWeb
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    cargarGrilla();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        private void cargarGrilla()
        {
            if (Session["listaProductos"] == null)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Session["listaProductos"] = negocio.listar();
            }
            List<Producto> lista = ((List<Producto>)Session["listaProductos"]).FindAll(x => x.Activo);

            string filtro = txtFiltro.Text.Trim().ToUpper();
            if (filtro != "")
            {
                lista = lista.FindAll(x =>
                    x.Nombre.ToUpper().Contains(filtro) ||
                    x.Marca.Nombre.ToUpper().Contains(filtro) ||
                    x.Categoria.Nombre.ToUpper().Contains(filtro));
            }

            dgvProductos.DataSource = lista;
            dgvProductos.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            dgvProductos.PageIndex = 0;
            cargarGrilla();
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            cargarGrilla();
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioProducto.aspx?id=" + id);
        }

        protected void dgvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(dgvProductos.DataKeys[e.RowIndex].Value);

            ProductoNegocio negocio = new ProductoNegocio();
            negocio.eliminarLogico(id, false);

            Session["listaProductos"] = null;
            cargarGrilla();
        }
    }
}