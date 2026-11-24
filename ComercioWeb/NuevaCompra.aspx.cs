using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComercioWeb
{
    public partial class NuevaCompra : System.Web.UI.Page
    {
        private List<DetalleCompra> Lineas
        {
            get { return (List<DetalleCompra>)Session["lineasCompra"]; }
        }

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
                    ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                    ddlProveedor.DataSource = proveedorNegocio.listar();
                    ddlProveedor.DataTextField = "RazonSocial";
                    ddlProveedor.DataValueField = "Id";
                    ddlProveedor.DataBind();

                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    ddlProducto.DataSource = productoNegocio.listar().FindAll(x => x.Activo);
                    ddlProducto.DataTextField = "Nombre";
                    ddlProducto.DataValueField = "Id";
                    ddlProducto.DataBind();

                    Session["lineasCompra"] = new List<DetalleCompra>();
                }
                cargarLineas();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        private void cargarLineas()
        {
            dgvLineas.DataSource = Lineas;
            dgvLineas.DataBind();
            lblTotal.Text = Lineas.Sum(x => x.Subtotal).ToString("C2");
            btnConfirmar.Enabled = Lineas.Count > 0;
        }

        private void mostrarError(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Visible = true;
        }

        protected void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;

            int cantidad = 0;
            decimal precio = 0;

            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0 ||
                !decimal.TryParse(txtPrecio.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out precio) || precio <= 0)
            {
                mostrarError("Ingresá una cantidad entera mayor a 0 y un precio mayor a 0.");
                return;
            }

            int idProducto = int.Parse(ddlProducto.SelectedValue);
            DetalleCompra existente = Lineas.Find(x => x.Producto.Id == idProducto);

            if (existente != null)
            {
                existente.Cantidad += cantidad;
                existente.PrecioCompra = precio;
            }
            else
            {
                DetalleCompra nueva = new DetalleCompra();
                nueva.Producto.Id = idProducto;
                nueva.Producto.Nombre = ddlProducto.SelectedItem.Text;
                nueva.Cantidad = cantidad;
                nueva.PrecioCompra = precio;
                Lineas.Add(nueva);
            }

            txtCantidad.Text = "";
            txtPrecio.Text = "";
            cargarLineas();
        }

        protected void dgvLineas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Lineas.RemoveAt(e.RowIndex);
            cargarLineas();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lineas.Count == 0)
                {
                    mostrarError("Agregá al menos una línea.");
                    return;
                }

                Compra compra = new Compra();
                compra.Proveedor.Id = int.Parse(ddlProveedor.SelectedValue);
                compra.Usuario.Id = ((Usuario)Session["usuario"]).Id;
                compra.Detalles = Lineas;

                CompraNegocio negocio = new CompraNegocio();
                negocio.registrar(compra);

                Session["lineasCompra"] = null;
                Session["listaProductos"] = null;
                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
    }
}