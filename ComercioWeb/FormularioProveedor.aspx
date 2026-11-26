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
                <asp:TextBox runat="server" ID="txtRazonSocial" CssClass="form-control" MaxLength="150" />
                <asp:RequiredFieldValidator ErrorMessage="La razón social es obligatoria" ControlToValidate="txtRazonSocial" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">CUIT</label>
                <asp:TextBox runat="server" ID="txtCuit" CssClass="form-control" MaxLength="13" placeholder="XX-XXXXXXXX-X" />
                <asp:RequiredFieldValidator ErrorMessage="El CUIT es obligatorio" ControlToValidate="txtCuit" CssClass="text-danger" Display="Dynamic" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="El CUIT debe tener el formato XX-XXXXXXXX-X" ControlToValidate="txtCuit" ValidationExpression="^\d{2}-\d{8}-\d$" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" MaxLength="150" />
                <asp:RegularExpressionValidator ErrorMessage="El email no tiene un formato válido" ControlToValidate="txtEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Teléfono</label>
                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" MaxLength="30" />
                <asp:RegularExpressionValidator ErrorMessage="Solo números, espacios y guiones (mínimo 6)" ControlToValidate="txtTelefono" ValidationExpression="^[0-9 \-]{6,30}$" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="lblError" CssClass="text-danger" Visible="false" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <a href="Proveedores.aspx" class="btn btn-link">Cancelar</a>
                <asp:Button Text="Inactivar" runat="server" ID="btnInactivar" CssClass="btn btn-outline-danger float-end" OnClick="btnInactivar_Click" CausesValidation="false" />
            </div>
        </div>
    </div>
</asp:Content>
