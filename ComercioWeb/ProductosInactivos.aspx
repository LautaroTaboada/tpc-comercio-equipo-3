<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductosInactivos.aspx.cs" Inherits="ComercioWeb.ProductosInactivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-3">Productos inactivos</h2>
    <div class="mb-3">
        <a href="Productos.aspx">Volver a productos</a>
    </div>

    <asp:GridView ID="dgvInactivos" runat="server"
        CssClass="table table-striped"
        DataKeyNames="Id"
        AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvInactivos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Stock actual" DataField="StockActual" />
            <asp:TemplateField HeaderText="Acción" HeaderStyle-CssClass="text-end" ItemStyle-CssClass="text-end text-nowrap">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName="Select" Text="Reactivar" CssClass="btn btn-sm btn-outline-success" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>