<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProveedoresInactivos.aspx.cs" Inherits="ComercioWeb.ProveedoresInactivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h1>Proveedores inactivos</h1>
        <a href="Proveedores.aspx" class="btn btn-outline-secondary">Volver</a>
    </div>
    <asp:GridView ID="gvInactivos" runat="server"
        DataKeyNames="Id"
        CssClass="table"
        AutoGenerateColumns="false"
        OnSelectedIndexChanged="gvInactivos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Razón social" DataField="RazonSocial" />
            <asp:BoundField HeaderText="CUIT" DataField="Cuit" />
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