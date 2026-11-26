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
    public partial class FormularioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "")
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    Cliente seleccionado = (negocio.listar(id))[0];

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtApellido.Text = seleccionado.Apellido;
                    txtDocumento.Text = seleccionado.Documento;
                    txtEmail.Text = seleccionado.Email;
                    txtTelefono.Text = seleccionado.Telefono;
                }
                else
                {
                    btnInactivar.Visible = false; // en un alta no hay nada que inactivar
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente();

            cliente.Nombre = txtNombre.Text.Trim();
            cliente.Apellido = txtApellido.Text.Trim();
            cliente.Documento = txtDocumento.Text.Trim();
            cliente.Email = txtEmail.Text.Trim() != "" ? txtEmail.Text.Trim() : null;
            cliente.Telefono = txtTelefono.Text.Trim() != "" ? txtTelefono.Text.Trim() : null;

            if (cliente.Nombre == "" || cliente.Apellido == "" || cliente.Documento == "")
            {
                lblError.Text = "Nombre, apellido y documento son obligatorios.";
                lblError.Visible = true;
                return;
            }

            int id = txtId.Text != "" ? int.Parse(txtId.Text) : 0;

            if (negocio.existe(cliente.Documento, id))
            {
                lblError.Text = "Ya existe un cliente con ese documento.";
                lblError.Visible = true;
                return;
            }

            if (id != 0)
            {
                cliente.Id = id;
                negocio.modificar(cliente);
            }
            else
            {
                negocio.agregar(cliente);
            }

            Response.Redirect("Clientes.aspx");
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            negocio.eliminar(int.Parse(txtId.Text));
            Response.Redirect("Clientes.aspx");
        }
    }
}