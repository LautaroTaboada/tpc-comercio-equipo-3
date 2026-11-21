<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="ComercioWeb.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-4">Categorías</h1>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" />
        </div>
        <div class="col-md-8">
            <table class="table">
                <thead>
                    <tr><th>Nombre</th><th>Estado</th><th>Acción</th></tr>
                </thead>
                <tbody>
                    <tr><td>Almacén</td><td>Activa</td><td><a href="#">✍</a></td></tr>
                    <tr><td>Limpieza</td><td>Activa</td><td><a href="#">✍</a></td></tr>
                    <tr><td>Bebidas</td><td>Activa</td><td><a href="#">✍</a></td></tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>