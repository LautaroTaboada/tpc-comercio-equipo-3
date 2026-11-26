<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="boostrabdesdecero.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center">
        <div class="col-md-5">

            <h2 class="mb-4">Crear cuenta</h2>

            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
            </div>

            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
            </div>

            <div class="mb-3">
                <label class="form-label">Nombre de usuario</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario" />
            </div>
            <div class="mb-3">
    <label class="form-label">Correo electrónico</label>
    <asp:TextBox runat="server" CssClass="form-control"
        ID="txtEmail" TextMode="Email" />
</div>

            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>

            <div class="mb-3">
                <label class="form-label">Repetir contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtRepetirPassword" TextMode="Password" />
            </div>

            <asp:Button
                Text="Registrarse"
                CssClass="btn btn-primary"
                ID="btnRegistrar"
                OnClick="btnRegistrar_Click"
                runat="server" />

            <p class="mt-3">
                ¿Ya tenés cuenta?
                <a href="Login.aspx">Iniciar sesión</a>
            </p>

        </div>
    </div>

</asp:Content>