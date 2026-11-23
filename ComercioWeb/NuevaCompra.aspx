<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaCompra.aspx.cs" Inherits="ComercioWeb.NuevaCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-4">Nueva compra</h1>
    <div class="mb-3 col-md-4">
        <label class="form-label">Proveedor</label>
       <asp:DropDownList runat="server" ID="ddlProveedor" CssClass="form-select">
</asp:DropDownList>
    </div>
    <div class="row align-items-end mb-3">
        <div class="col-md-5">
            <label class="form-label">Producto</label>
            <asp:DropDownList runat="server" ID="ddlProducto" CssClass="form-select">
                <asp:ListItem Text="Yerba mate 1 kg" />
                <asp:ListItem Text="Aceite de girasol 900 ml" />
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <label class="form-label">Cantidad</label>
            <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" TextMode="Number" />
        </div>
        <div class="col-md-3">
            <label class="form-label">Precio de compra</label>
            <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" TextMode="Number" />
        </div>
        <div class="col-md-2">
            <asp:Button Text="Agregar línea" runat="server" ID="btnAgregarLinea" CssClass="btn btn-success" />
        </div>
    </div>
    <table class="table">
        <thead>
            <tr><th>Producto</th><th>Cantidad</th><th>Precio de compra</th><th>Subtotal</th><th></th></tr>
        </thead>
        <tbody>
            <tr><td>Yerba mate 1 kg</td><td>20</td><td>$ 3.200,00</td><td>$ 64.000,00</td><td><a href="#">Quitar</a></td></tr>
            <tr><td>Aceite de girasol 900 ml</td><td>12</td><td>$ 1.800,00</td><td>$ 21.600,00</td><td><a href="#">Quitar</a></td></tr>
        </tbody>
        <tfoot>
            <tr><th colspan="3" class="text-end">Total</th><th>$ 85.600,00</th><th></th></tr>
        </tfoot>
    </table>
    <asp:Button Text="Confirmar compra" runat="server" ID="btnConfirmar" CssClass="btn btn-primary" />
    <a href="Inicio.aspx" class="btn btn-link">Cancelar</a>
</asp:Content>