<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="boostrabdesdecero.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <div class="row">
      <div class="col-2"></div>
      <div class="col">
          <div class="mb-3">
    <label for="txtEmail" class="form-label">Mail address</label> 
     <asp:TextBox runat="server" cssClass="form-control" ID="txtEmail" />
   
  </div>
  <div class="mb-3">
    <label for ="password" class="form-label">Password</label>
  
      <asp:TextBox runat="server" cssClass="form-control"  id="txtPassword" type="password"/>
  </div>
  
   <asp:button Text="Ingresar"  CssClass="btn btn-primary" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />


      </div>
      <div class="col-2"></div>
  </div>
</asp:Content>
