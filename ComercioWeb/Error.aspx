<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ComercioWeb.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Ocurrió un error</h3>
    <asp:Label Text="" ID="lblError" runat="server" />
    <div class="mt-3">
        <a href="Inicio.aspx" class="btn btn-primary">Volver al inicio</a>
    </div>
</asp:Content>