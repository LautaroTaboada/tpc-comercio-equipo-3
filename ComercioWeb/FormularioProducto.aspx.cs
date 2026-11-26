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
    public partial class FormularioProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlMarca.DataTextField = "Nombre";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    ddlCategoria.DataSource = categoriaNegocio.listar();
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                    ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                    cblProveedores.DataSource = proveedorNegocio.listar();
                    cblProveedores.DataTextField = "RazonSocial";
                    cblProveedores.DataValueField = "Id";
                    cblProveedores.DataBind();

                    Session["ProductoSeleccionado"] = null;
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                    if (id != "")
                    {
                        ProductoNegocio negocio = new ProductoNegocio();
                        Producto seleccionado = negocio.listar().Find(x => x.Id == int.Parse(id));
                        Session["ProductoSeleccionado"] = seleccionado;

                        txtId.Text = seleccionado.Id.ToString();
                        txtNombre.Text = seleccionado.Nombre;
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtStockMinimo.Text = seleccionado.StockMinimo.ToString();
                        txtGanancia.Text = seleccionado.PorcentajeGanancia.ToString(CultureInfo.InvariantCulture);
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                        // se tildan los proveedores que el producto ya tiene
                        List<int> idsProveedores = negocio.listarIdsProveedores(seleccionado.Id);
                        foreach (ListItem item in cblProveedores.Items)
                            item.Selected = idsProveedores.Contains(int.Parse(item.Value));

                        if (!seleccionado.Activo)
                            btnInactivar.Text = "Reactivar";
                    }
                    else
                    {
                        btnInactivar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                List<int> idsProveedores = new List<int>();
                foreach (ListItem item in cblProveedores.Items)
                {
                    if (item.Selected)
                        idsProveedores.Add(int.Parse(item.Value));
                }

                if (idsProveedores.Count == 0)
                {
                    lblError.Text = "Elegí al menos un proveedor.";
                    lblError.Visible = true;
                    return;
                }

                Producto producto = new Producto();
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.StockMinimo = int.Parse(txtStockMinimo.Text);
                producto.PorcentajeGanancia = decimal.Parse(txtGanancia.Text, CultureInfo.InvariantCulture);
                producto.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                producto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                ProductoNegocio negocio = new ProductoNegocio();
                int idProducto;

                if (Request.QueryString["id"] != null)
                {
                    producto.Id = int.Parse(txtId.Text);
                    negocio.modificar(producto);
                    idProducto = producto.Id;
                }
                else
                    idProducto = negocio.agregar(producto);

                negocio.guardarProveedores(idProducto, idsProveedores);

                Session["listaProductos"] = null;
                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Producto seleccionado = (Producto)Session["ProductoSeleccionado"];

                negocio.eliminarLogico(seleccionado.Id, !seleccionado.Activo);
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
