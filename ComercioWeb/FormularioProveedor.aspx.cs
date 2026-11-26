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
    public partial class FormularioProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "")
                {
                    ProveedorNegocio negocio = new ProveedorNegocio();
                    Proveedor seleccionado = (negocio.listar(id))[0];

                    txtId.Text = id;
                    txtRazonSocial.Text = seleccionado.RazonSocial;
                    txtCuit.Text = seleccionado.Cuit;
                    txtEmail.Text = seleccionado.Email;
                    txtTelefono.Text = seleccionado.Telefono;
                }
                else
                {
                    btnInactivar.Visible = false;
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            ProveedorNegocio negocio = new ProveedorNegocio();
            Proveedor proveedor = new Proveedor();

            proveedor.RazonSocial = txtRazonSocial.Text.Trim();
            proveedor.Cuit = txtCuit.Text.Trim();
            proveedor.Email = txtEmail.Text.Trim() != "" ? txtEmail.Text.Trim() : null;
            proveedor.Telefono = txtTelefono.Text.Trim() != "" ? txtTelefono.Text.Trim() : null;

            if (proveedor.RazonSocial == "" || proveedor.Cuit == "")
            {
                lblError.Text = "Razón social y CUIT son obligatorios.";
                lblError.Visible = true;
                return;
            }

            int id = txtId.Text != "" ? int.Parse(txtId.Text) : 0;

            if (negocio.existe(proveedor.Cuit, id))
            {
                lblError.Text = "Ya existe un proveedor con ese CUIT.";
                lblError.Visible = true;
                return;
            }

            if (id != 0)
            {
                proveedor.Id = id;
                negocio.modificar(proveedor);
            }
            else
            {
                negocio.agregar(proveedor);
            }

            Response.Redirect("Proveedores.aspx");
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            negocio.eliminar(int.Parse(txtId.Text));
            Response.Redirect("Proveedores.aspx");
        }
    }
}