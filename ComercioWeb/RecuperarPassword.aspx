<%@ Page Title="Recuperar contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarPassword.aspx.cs" Inherits="boostrabdesdecero.RecuperarPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center">
        <div class="col-md-5">

            <h2 class="mb-4">Recuperar contraseña</h2>

            <p>Ingresá tu nombre de usuario para continuar.</p>

            <div class="mb-3">
                <label class="form-label">Nombre de usuario</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario" />
            </div>

            <asp:Button
                Text="Continuar"
                CssClass="btn btn-primary"
                ID="btnContinuar"
                OnClick="btnContinuar_Click"
                runat="server" />

            <p class="mt-3">
                <a href="Login.aspx">Volver al inicio de sesión</a>
            </p>

        </div>
    </div>

</asp:Content>