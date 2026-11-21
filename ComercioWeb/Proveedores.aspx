<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="ComercioWeb.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h1>Proveedores</h1>
        <a href="FormularioProveedor.aspx" class="btn btn-primary">Agregar</a>
    </div>
    <table class="table">
        <thead>
            <tr><th>Razón social</th><th>CUIT</th><th>Email</th><th>Teléfono</th><th>Acción</th></tr>
        </thead>
        <tbody>
            <tr><td>Distribuidora Norte S.A.</td><td>30-11111111-1</td><td>ventas@distnorte.example</td><td>11-5555-0001</td><td><a href="FormularioProveedor.aspx">✍</a></td></tr>
            <tr><td>Mayorista Sur S.R.L.</td><td>30-22222222-2</td><td>pedidos@mayosur.example</td><td>11-5555-0002</td><td><a href="FormularioProveedor.aspx">✍</a></td></tr>
        </tbody>
    </table>
</asp:Content>