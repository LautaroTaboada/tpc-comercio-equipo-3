<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioProveedor.aspx.cs" Inherits="ComercioWeb.FormularioProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-4">Proveedor</h1>
    <div class="row">
        <div class="col-md-6">
            <div class="mb-3">
                <label class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false" />
            </div>
            <div class="mb-3">
                <label class="form-label">Razón social</label>
                <asp:TextBox runat="server" ID="txtRazonSocial" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">CUIT</label>
                <asp:TextBox runat="server" ID="txtCuit" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
            </div>
            <div class="mb-3">
                <label class="form-label">Teléfono</label>
                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="lblError" CssClass="text-danger" Visible="false" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <a href="Proveedores.aspx" class="btn btn-link">Cancelar</a>
                <asp:Button Text="Inactivar" runat="server" ID="btnInactivar" CssClass="btn btn-outline-danger float-end" OnClick="btnInactivar_Click" />
            </div>
        </div>
    </div>
</asp:Content>