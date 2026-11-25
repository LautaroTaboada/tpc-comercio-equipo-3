<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="boostrabdesdecero.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div class="row justify-content-center">
    <div class="col-md-5">

        <h2 class="mb-4">Iniciar sesión</h2>

        <div class="mb-3">
            <label class="form-label">Nombre de usuario</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
        </div>

        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
        </div>

        <asp:Button
            Text="Ingresar"
            CssClass="btn btn-primary"
            ID="btnAceptar"
            OnClick="btnAceptar_Click"
            runat="server" />

        <p class="mt-3">
            ¿No tenés cuenta?
            <a href="Registro.aspx">Registrarse</a>
        </p>
        <p class="mt-2">
    <a href="RecuperarPassword.aspx">¿Olvidaste tu contraseña?</a>
</p>

    </div>
</div>
</asp:Content>
