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
    public partial class NuevaVenta : System.Web.UI.Page
    {
        private List<DetalleVenta> Lineas
        {
            get { return (List<DetalleVenta>)Session["lineasVenta"]; }
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
                    ClienteNegocio clienteNegocio = new ClienteNegocio();
                    ddlCliente.DataSource = clienteNegocio.listar();
                    ddlCliente.DataTextField = "NombreCompleto";
                    ddlCliente.DataValueField = "Id";
                    ddlCliente.DataBind();

                    cargarProductos();
                    mostrarPrecio();
                    Session["lineasVenta"] = new List<DetalleVenta>();
                }
                cargarLineas();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> lista = negocio.listar().FindAll(x => x.Activo && x.StockActual > 0 && x.UltimoPrecioCompra > 0);

            ddlProducto.Items.Clear();
            foreach (Producto p in lista)
                ddlProducto.Items.Add(new ListItem(p.Nombre + " (stock " + p.StockActual + ")", p.Id.ToString()));
        }

        private Producto obtenerProducto(int id)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            return negocio.listar().Find(x => x.Id == id);
        }

        private void mostrarPrecio()
        {
            if (ddlProducto.Items.Count == 0)
            {
                txtPrecio.Text = "";
                return;
            }
            Producto p = obtenerProducto(int.Parse(ddlProducto.SelectedValue));
            txtPrecio.Text = p.PrecioVenta.ToString("C2");
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

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarPrecio();
        }

        protected void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;

            if (ddlProducto.Items.Count == 0)
            {
                mostrarError("No hay productos con stock disponible.");
                return;
            }

            int cantidad = 0;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                mostrarError("Ingresá una cantidad entera mayor a 0.");
                return;
            }

            Producto producto = obtenerProducto(int.Parse(ddlProducto.SelectedValue));
            DetalleVenta existente = Lineas.Find(x => x.Producto.Id == producto.Id);
            int yaAgregado = existente != null ? existente.Cantidad : 0;

            if (yaAgregado + cantidad > producto.StockActual)
            {
                mostrarError("Stock insuficiente. Disponible: " + producto.StockActual + ".");
                return;
            }

            if (existente != null)
            {
                existente.Cantidad += cantidad;
            }
            else
            {
                DetalleVenta nueva = new DetalleVenta();
                nueva.Producto.Id = producto.Id;
                nueva.Producto.Nombre = producto.Nombre;
                nueva.Cantidad = cantidad;
                nueva.PrecioUnitario = producto.PrecioVenta;
                Lineas.Add(nueva);
            }

            txtCantidad.Text = "";
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
                if (ddlCliente.Items.Count == 0)
                {
                    mostrarError("Seleccioná un cliente.");
                    return;
                }

                foreach (DetalleVenta linea in Lineas)
                {
                    Producto actual = obtenerProducto(linea.Producto.Id);
                    int disponible = actual != null ? actual.StockActual : 0;

                    if (linea.Cantidad > disponible)
                    {
                        mostrarError("Stock insuficiente para " + linea.Producto.Nombre + ". Disponible: " + disponible + ".");
                        return;
                    }
                }

                Venta venta = new Venta();
                venta.Cliente.Id = int.Parse(ddlCliente.SelectedValue);
                venta.Usuario.Id = ((Usuario)Session["usuario"]).Id;
                venta.Detalles = Lineas;

                VentaNegocio negocio = new VentaNegocio();
                int idVenta = negocio.registrar(venta);

                Session["lineasVenta"] = null;
                Session["listaProductos"] = null;
                Response.Redirect("Factura.aspx?id=" + idVenta, false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
    }
}