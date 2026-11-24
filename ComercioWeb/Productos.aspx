<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="ComercioWeb.Productos" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h2>Productos</h2>
        <a href="ProductosInactivos.aspx" class="btn btn-outline-secondary">Ver inactivos</a>
    </div>

    <asp:GridView ID="dgvProductos" runat="server"
        CssClass="table table-striped"
        DataKeyNames="Id"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="5"
        OnPageIndexChanging="dgvProductos_PageIndexChanging"
        OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged"
        OnRowDeleting="dgvProductos_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Stock actual" DataField="StockActual" />
            <asp:BoundField HeaderText="Stock mínimo" DataField="StockMinimo" />
            <asp:BoundField HeaderText="Precio de venta" DataField="PrecioVenta"
                DataFormatString="{0:C2}" HtmlEncode="false" />
            <asp:TemplateField HeaderText="Acción" HeaderStyle-CssClass="text-end" ItemStyle-CssClass="text-end text-nowrap">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName="Select" Text="✍" CssClass="btn btn-sm btn-outline-secondary" />
                    <asp:LinkButton runat="server" CommandName="Delete" Text="Desactivar" CssClass="btn btn-sm btn-outline-danger ms-1" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <a href="FormularioProducto.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>