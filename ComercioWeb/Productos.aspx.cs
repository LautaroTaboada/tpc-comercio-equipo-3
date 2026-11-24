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
            List<Producto> lista = (List<Producto>)Session["listaProductos"];
            dgvProductos.DataSource = lista.FindAll(x => x.Activo);
            dgvProductos.DataBind();
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