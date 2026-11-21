<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="ComercioWeb.NuevaVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-4">Nueva venta</h1>
    <div class="mb-3 col-md-4">
        <label class="form-label">Cliente</label>
        <asp:DropDownList runat="server" ID="ddlCliente" CssClass="form-select">
            <asp:ListItem Text="Gómez, María" />
            <asp:ListItem Text="Pérez, Carlos" />
            <asp:ListItem Text="Rodríguez, Ana" />
        </asp:DropDownList>
    </div>
    <div class="row align-items-end mb-3">
        <div class="col-md-5">
            <label class="form-label">Producto</label>
            <asp:DropDownList runat="server" ID="ddlProducto" CssClass="form-select">
                <asp:ListItem Text="Gaseosa cola 2,25 l (stock 40)" />
                <asp:ListItem Text="Fideos tirabuzón 500 g (stock 9)" />
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <label class="form-label">Cantidad</label>
            <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" TextMode="Number" />
        </div>
        <div class="col-md-3">
            <label class="form-label">Precio unitario</label>
            <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" Enabled="false" />
        </div>
        <div class="col-md-2">
            <asp:Button Text="Agregar línea" runat="server" ID="btnAgregarLinea" CssClass="btn btn-success" />
        </div>
    </div>
    <table class="table">
        <thead>
            <tr><th>Producto</th><th>Cantidad</th><th>Precio unitario</th><th>Subtotal</th><th></th></tr>
        </thead>
        <tbody>
            <tr><td>Gaseosa cola 2,25 l</td><td>3</td><td>$ 1.800,00</td><td>$ 5.400,00</td><td><a href="#">Quitar</a></td></tr>
            <tr><td>Fideos tirabuzón 500 g</td><td>2</td><td>$ 1.170,00</td><td>$ 2.340,00</td><td><a href="#">Quitar</a></td></tr>
        </tbody>
        <tfoot>
            <tr><th colspan="3" class="text-end">Total</th><th>$ 7.740,00</th><th></th></tr>
        </tfoot>
    </table>
    <asp:Button Text="Confirmar venta" runat="server" ID="btnConfirmar" CssClass="btn btn-primary" />
    <a href="Inicio.aspx" class="btn btn-link">Cancelar</a>
</asp:Content>