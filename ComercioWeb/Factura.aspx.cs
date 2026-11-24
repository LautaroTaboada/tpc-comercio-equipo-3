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
    public partial class Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] == null)
                    {
                        Response.Redirect("NuevaVenta.aspx", false);
                        return;
                    }

                    VentaNegocio negocio = new VentaNegocio();
                    Venta venta = negocio.obtener(int.Parse(Request.QueryString["id"]));

                    lblNumero.Text = venta.NumeroFactura;
                    lblFecha.Text = venta.Fecha.ToString("dd/MM/yyyy HH:mm");
                    lblCliente.Text = venta.Cliente.NombreCompleto;
                    lblDocumento.Text = venta.Cliente.Documento;
                    dgvDetalle.DataSource = venta.Detalles;
                    dgvDetalle.DataBind();
                    lblTotal.Text = venta.Total.ToString("C2");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
    }
}