<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ComercioWeb.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h1>Clientes</h1>
        <a href="FormularioCliente.aspx" class="btn btn-primary">Agregar</a>
    </div>
    <div class="mb-3">
        <label class="form-label">Filtrar</label>
        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" />
    </div>
    <table class="table">
        <thead>
            <tr><th>Apellido y nombre</th><th>Documento</th><th>Email</th><th>Teléfono</th><th>Acción</th></tr>
        </thead>
        <tbody>
            <tr><td>Gómez, María</td><td>30111222</td><td>maria.gomez@example.com</td><td>11-4444-0001</td><td><a href="FormularioCliente.aspx">✍</a></td></tr>
            <tr><td>Pérez, Carlos</td><td>28333444</td><td>carlos.perez@example.com</td><td>11-4444-0002</td><td><a href="FormularioCliente.aspx">✍</a></td></tr>
            <tr><td>Rodríguez, Ana</td><td>35555666</td><td>ana.rodriguez@example.com</td><td>11-4444-0003</td><td><a href="FormularioCliente.aspx">✍</a></td></tr>
        </tbody>
    </table>
</asp:Content>