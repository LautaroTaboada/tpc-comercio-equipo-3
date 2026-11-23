<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriasInactivas.aspx.cs" Inherits="ComercioWeb.CategoriasInactivas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-4">Categorías inactivas</h1>
  <div class="mb-3">
    <a href="Categorias.aspx">Volver a categorías</a>
</div>
    
    <asp:GridView ID="dgvCategoriasInactivas"
    runat="server"
    OnSelectedIndexChanged="dgvCategoriasInactivas_SelectedIndexChanged"
    CssClass="table"
    AutoGenerateColumns="false"
    DataKeyNames="Id">

    <Columns>
    <asp:BoundField
        HeaderText="Nombre"
        DataField="Nombre" />

    <asp:CheckBoxField
        HeaderText="Activo"
        DataField="Activo" />

    <asp:CommandField
        HeaderText="Acción"
        ShowSelectButton="true"
        SelectText="Reactivar" />
</Columns>

</asp:GridView>
</asp:Content>
