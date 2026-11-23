using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace ComercioWeb
{
    public partial class NuevaCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

                ddlProveedor.DataSource = proveedorNegocio.listar();
                ddlProveedor.DataTextField = "RazonSocial";
                ddlProveedor.DataValueField = "Id";
                ddlProveedor.DataBind();

                ProductoNegocio productoNegocio = new ProductoNegocio();

                ddlProducto.DataSource = productoNegocio.listar();
                ddlProducto.DataTextField = "Nombre";
                ddlProducto.DataValueField = "Id";
                ddlProducto.DataBind();
            }
        }
    }
}