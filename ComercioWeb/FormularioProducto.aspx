<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="ComercioWeb.FormularioProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="mb-4">Producto</h1>

    <div class="row">
        <div class="col-md-6">

            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="150" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es obligatorio" ControlToValidate="txtNombre" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                <asp:RegularExpressionValidator ErrorMessage="La descripción admite hasta 300 caracteres" ControlToValidate="txtDescripcion" ValidationExpression="^[\s\S]{0,300}$" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <div class="row">
                <div class="col-md-6 mb-3">
                    <label for="ddlMarca" class="form-label">Marca</label>
                    <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="ddlCategoria" class="form-label">Categoría</label>
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-6 mb-3">
                    <label for="txtStockMinimo" class="form-label">Stock mínimo</label>
                    <asp:TextBox runat="server" ID="txtStockMinimo" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator ErrorMessage="El stock mínimo es obligatorio" ControlToValidate="txtStockMinimo" CssClass="text-danger" Display="Dynamic" runat="server" />
                    <asp:RangeValidator ErrorMessage="El stock mínimo debe ser un entero entre 0 y 100000" ControlToValidate="txtStockMinimo" Type="Integer" MinimumValue="0" MaximumValue="100000" CssClass="text-danger" Display="Dynamic" runat="server" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="txtGanancia" class="form-label">% de ganancia</label>
                    <asp:TextBox runat="server" ID="txtGanancia" CssClass="form-control" TextMode="Number" step="0.01" />
                    <asp:RequiredFieldValidator ErrorMessage="El % de ganancia es obligatorio" ControlToValidate="txtGanancia" CssClass="text-danger" Display="Dynamic" runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Ingresá entre 0 y 999.99, con punto y hasta 2 decimales (ej: 30.5)" ControlToValidate="txtGanancia" ValidationExpression="^\d{1,3}(\.\d{1,2})?$" CssClass="text-danger" Display="Dynamic" runat="server" />
                </div>
            </div>

        </div>

        <div class="col-md-6">

            <div class="mb-3">
                <label class="form-label">Proveedores (uno o más)</label>
                <asp:CheckBoxList runat="server" ID="cblProveedores" CssClass="form-check" />
            </div>

            <div class="alert alert-info">
                <strong>Precio de venta (calculado):</strong>
                último precio de compra + % de ganancia. No se carga a mano.
            </div>

            <div class="alert alert-warning">
                El stock actual lo mueven las compras y las ventas, por eso no se edita acá.
            </div>

        </div>
    </div>

    <div class="mb-3">
        <asp:Label runat="server" ID="lblError" CssClass="text-danger" Visible="false" />
    </div>

    <div class="mb-3">
        <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
        <a href="Productos.aspx" class="btn btn-link">Cancelar</a>
        <asp:Button Text="Inactivar" runat="server" ID="btnInactivar" CssClass="btn btn-outline-danger float-end" OnClick="btnInactivar_Click" CausesValidation="false" />
    </div>

</asp:Content>
