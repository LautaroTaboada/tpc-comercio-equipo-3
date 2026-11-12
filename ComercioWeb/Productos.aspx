<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="ComercioWeb.Productos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-3">Productos</h2>

    <asp:GridView ID="dgvProductos" runat="server"
        CssClass="table table-striped"
        DataKeyNames="Id"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="5"
        OnPageIndexChanging="dgvProductos_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Stock actual" DataField="StockActual" />
            <asp:BoundField HeaderText="Stock mínimo" DataField="StockMinimo" />
            <asp:BoundField HeaderText="Precio de venta" DataField="PrecioVenta"
                DataFormatString="{0:C2}" HtmlEncode="false" />
        </Columns>
    </asp:GridView>
</asp:Content>