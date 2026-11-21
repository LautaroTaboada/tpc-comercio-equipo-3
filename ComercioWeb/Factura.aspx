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
                <h3>FACTURA N° 0001-00000001</h3>
                <span>Fecha: 21/11/2026</span>
            </div>
        </div>
        <p><strong>Cliente:</strong> Gómez, María &nbsp; <strong>Documento:</strong> 30111222</p>
        <table class="table">
            <thead>
                <tr><th>Producto</th><th>Cant.</th><th>Precio unitario</th><th>Subtotal</th></tr>
            </thead>
            <tbody>
                <%--<tr><td>Gaseosa cola 2,25 l</td><td>3</td><td>$ 1.800,00</td><td>$ 5.400,00</td></tr>--%>
                <tr><td>Fideos tirabuzón 500 g</td><td>2</td><td>$ 1.170,00</td><td>$ 2.340,00</td></tr>
            </tbody>
            <tfoot>
                <tr><th colspan="3" class="text-end">TOTAL</th><th>$ 7.740,00</th></tr>
            </tfoot>
        </table>
    </div>
    <div class="mt-3">
        <input type="button" value="Imprimir" class="btn btn-primary" onclick="window.print()" />
        <a href="NuevaVenta.aspx" class="btn btn-link">Nueva venta</a>
    </div>
</asp:Content>