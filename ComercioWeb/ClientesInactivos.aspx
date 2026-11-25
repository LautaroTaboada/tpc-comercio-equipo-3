<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientesInactivos.aspx.cs" Inherits="ComercioWeb.ClientesInactivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h1>Clientes inactivos</h1>
        <a href="Clientes.aspx" class="btn btn-outline-secondary">Volver</a>
    </div>
    <asp:GridView ID="gvInactivos" runat="server"
        DataKeyNames="Id"
        CssClass="table"
        AutoGenerateColumns="false"
        OnSelectedIndexChanged="gvInactivos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Apellido y nombre" DataField="NombreCompleto" />
            <asp:BoundField HeaderText="Documento" DataField="Documento" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
            <asp:TemplateField HeaderText="Acción" HeaderStyle-CssClass="text-end" ItemStyle-CssClass="text-end text-nowrap">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName="Select" Text="Reactivar" CssClass="btn btn-sm btn-outline-success" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
