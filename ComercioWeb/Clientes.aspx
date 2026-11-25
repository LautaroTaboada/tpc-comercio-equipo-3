<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ComercioWeb.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h1>Clientes</h1>
        <div>
            <a href="ClientesInactivos.aspx" class="btn btn-outline-secondary">Ver inactivos</a>
            <a href="FormularioCliente.aspx" class="btn btn-primary">Agregar</a>
        </div>
    </div>
    <div class="mb-3">
        <label class="form-label">Filtrar por apellido, nombre o documento</label>
        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
    </div>
    <asp:GridView ID="gvClientes" runat="server"
        DataKeyNames="Id"
        CssClass="table"
        AutoGenerateColumns="false"
        OnSelectedIndexChanged="gvClientes_SelectedIndexChanged"
        OnRowDeleting="gvClientes_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="Apellido y nombre" DataField="NombreCompleto" />
            <asp:BoundField HeaderText="Documento" DataField="Documento" />
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