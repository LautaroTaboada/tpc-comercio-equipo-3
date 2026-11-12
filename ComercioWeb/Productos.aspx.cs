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
                {
                    if (Session["listaProductos"] == null)
                    {
                        ProductoNegocio negocio = new ProductoNegocio();
                        Session["listaProductos"] = negocio.listar();
                    }
                    dgvProductos.DataSource = Session["listaProductos"];
                    dgvProductos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                // Response.Redirect("Error.aspx");
            }
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            dgvProductos.DataSource = Session["listaProductos"];
            dgvProductos.DataBind();
        }
    }
}