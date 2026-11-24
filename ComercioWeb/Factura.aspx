<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="ComercioWeb.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="border p-4">
        <div class="d-flex justify-content-between mb-3">
            <div>
                <h3>Mi Comercio</h3>
            </div>
            <div class="text-end">
                <h3>FACTURA N° <asp:Label ID="lblNumero" runat="server" /></h3>
                <span>Fecha: <asp:Label ID="lblFecha" runat="server" /></span>
            </div>
        </div>
        <p>
            <strong>Cliente:</strong> <asp:Label ID="lblCliente" runat="server" /> &nbsp;
            <strong>Documento:</strong> <asp:Label ID="lblDocumento" runat="server" />
        </p>
        <asp:GridView ID="dgvDetalle" runat="server" CssClass="table" AutoGenerateColumns="false" GridLines="None">
            <Columns>
                <asp:TemplateField HeaderText="Producto">
                    <ItemTemplate><%# Eval("Producto.Nombre") %></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Cant." DataField="Cantidad" />
                <asp:BoundField HeaderText="Precio unitario" DataField="PrecioUnitario" DataFormatString="{0:C2}" />
                <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" DataFormatString="{0:C2}" />
            </Columns>
        </asp:GridView>
        <h4 class="text-end">TOTAL: <asp:Label ID="lblTotal" runat="server" /></h4>
    </div>
    <div class="mt-3">
        <input type="button" value="Imprimir" class="btn btn-primary" onclick="window.print()" />
        <a href="NuevaVenta.aspx" class="btn btn-link">Nueva venta</a>
    </div>
</asp:Content>