<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="ComercioWeb.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h1>Proveedores</h1>
        <div>
            <a href="ProveedoresInactivos.aspx" class="btn btn-outline-secondary">Ver inactivos</a>
            <a href="FormularioProveedor.aspx" class="btn btn-primary">Agregar</a>
        </div>
    </div>
    <div class="mb-3">
        <label class="form-label">Filtrar por razón social o CUIT</label>
        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
    </div>
    <asp:GridView ID="gvProveedores" runat="server"
        DataKeyNames="Id"
        CssClass="table"
        AutoGenerateColumns="false"
        OnSelectedIndexChanged="gvProveedores_SelectedIndexChanged"
        OnRowDeleting="gvProveedores_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="Razón social" DataField="RazonSocial" />
            <asp:BoundField HeaderText="CUIT" DataField="Cuit" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
            <asp:TemplateField HeaderText="Acción" HeaderStyle-CssClass="text-end" ItemStyle-CssClass="text-end text-nowrap">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName="Select" Text="✍" CssClass="btn btn-sm btn-outline-secondary" />
                    <asp:LinkButton runat="server" CommandName="Delete" Text="Desactivar" CssClass="btn btn-sm btn-outline-danger ms-1" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>