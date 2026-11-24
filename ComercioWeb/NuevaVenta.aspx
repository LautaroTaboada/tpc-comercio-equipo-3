<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="ComercioWeb.NuevaVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-4">Nueva venta</h1>

    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-danger d-block" Visible="false" />

    <div class="mb-3 col-md-4">
        <label class="form-label">Cliente</label>
        <asp:DropDownList runat="server" ID="ddlCliente" CssClass="form-select" />
    </div>

    <div class="row align-items-end mb-3">
        <div class="col-md-5">
            <label class="form-label">Producto</label>
            <asp:DropDownList runat="server" ID="ddlProducto" CssClass="form-select"
                AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" />
        </div>
        <div class="col-md-2">
            <label class="form-label">Cantidad</label>
            <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" TextMode="Number" />
        </div>
        <div class="col-md-3">
            <label class="form-label">Precio unitario</label>
            <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" Enabled="false" />
        </div>
        <div class="col-md-2">
            <asp:Button Text="Agregar línea" runat="server" ID="btnAgregarLinea" CssClass="btn btn-success" OnClick="btnAgregarLinea_Click" />
        </div>
    </div>

    <asp:GridView ID="dgvLineas" runat="server" CssClass="table" AutoGenerateColumns="false"
        GridLines="None" OnRowDeleting="dgvLineas_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Producto">
                <ItemTemplate><%# Eval("Producto.Nombre") %></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Precio unitario" DataField="PrecioUnitario" DataFormatString="{0:C2}" />
            <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" DataFormatString="{0:C2}" />
            <asp:TemplateField HeaderText="Acción" HeaderStyle-CssClass="text-end" ItemStyle-CssClass="text-end text-nowrap">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName="Delete" Text="Quitar" CssClass="btn btn-sm btn-outline-danger" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <h5 class="text-end">Total: <asp:Label ID="lblTotal" runat="server" Text="$ 0,00" /></h5>

    <asp:Button Text="Confirmar venta" runat="server" ID="btnConfirmar" CssClass="btn btn-primary" OnClick="btnConfirmar_Click" />
    <a href="Inicio.aspx" class="btn btn-link">Cancelar</a>
</asp:Content>