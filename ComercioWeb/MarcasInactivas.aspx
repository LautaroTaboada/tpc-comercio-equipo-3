<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MarcasInactivas.aspx.cs" Inherits="ComercioWeb.MarcasInactivas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="mb-4">Marcas inactivas</h1>

    <div class="mb-3">
        <a href="Marcas.aspx">Volver a marcas</a>
    </div>

    <asp:GridView ID="gvMarcasInactivas"
        runat="server"
        OnSelectedIndexChanged="gvMarcasInactivas_SelectedIndexChanged"
        CssClass="table"
        AutoGenerateColumns="false"
        DataKeyNames="Id">

        <Columns>
            <asp:BoundField
                HeaderText="Nombre"
                DataField="Nombre" />

            <asp:CheckBoxField
                HeaderText="Activo"
                DataField="Activo" />

            <asp:TemplateField HeaderText="Acción" HeaderStyle-CssClass="text-end" ItemStyle-CssClass="text-end text-nowrap">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName="Select" Text="Reactivar" CssClass="btn btn-sm btn-outline-success" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

</asp:Content>