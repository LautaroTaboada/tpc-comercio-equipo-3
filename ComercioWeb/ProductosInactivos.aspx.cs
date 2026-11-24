using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComercioWeb
{
    public partial class ProductosInactivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                cargarGrilla();
        }

        private void cargarGrilla()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvInactivos.DataSource = negocio.listar().FindAll(x => !x.Activo);
            dgvInactivos.DataBind();
        }

        protected void dgvInactivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvInactivos.SelectedDataKey.Value);

            ProductoNegocio negocio = new ProductoNegocio();
            negocio.eliminarLogico(id, true);

            Session["listaProductos"] = null;
            cargarGrilla();
        }
    }
}