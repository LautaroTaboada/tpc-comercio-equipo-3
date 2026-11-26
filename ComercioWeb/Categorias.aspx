<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="ComercioWeb.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="d-flex justify-content-between align-items-center mb-3">
        <h1>Categorías</h1>
        <a href="CategoriasInactivas.aspx" class="btn btn-outline-secondary">Ver inactivas</a>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
           <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
           <asp:Label ID="lblMensaje" runat="server" />
        </div>
        <div class="col-md-8">
     <asp:GridView ID="dgvCategorias" runat="server"
    DataKeyNames="Id"
    CssClass="table"
    AutoGenerateColumns="false"
    OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged"
    OnRowDeleting="dgvCategorias_RowDeleting">

    <Columns>
        <asp:BoundField
            HeaderText="Nombre"
            DataField="Nombre" />
        <asp:TemplateField HeaderText="Acción" HeaderStyle-CssClass="text-end" ItemStyle-CssClass="text-end text-nowrap">
            <ItemTemplate>
                <asp:LinkButton runat="server" CommandName="Select" Text="✍" CssClass="btn btn-sm btn-outline-secondary" />
                <asp:LinkButton runat="server" CommandName="Delete" Text="Desactivar" CssClass="btn btn-sm btn-outline-danger ms-1" />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>
</div>
    </div>
</asp:Content>