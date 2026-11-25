using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComercioWeb
{
    public partial class ClientesInactivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                cargar();
        }

        private void cargar()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            gvInactivos.DataSource = negocio.listarInactivos();
            gvInactivos.DataBind();
        }

        protected void gvInactivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvInactivos.SelectedDataKey.Value);

            ClienteNegocio negocio = new ClienteNegocio();
            negocio.reactivar(id);

            cargar();
        }
    }
}