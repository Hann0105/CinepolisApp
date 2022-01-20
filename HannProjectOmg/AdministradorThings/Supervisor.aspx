<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Supervisor.aspx.cs" Inherits="HannProjectOmg.AdministradorThings.Supervisor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Gestionar Supervisor</h1>

    <asp:Label ID="lblUser" runat="server" CssClass="control-label" Text="Usuario" ></asp:Label>
    <asp:TextBox ID="txtUser" runat="server"  CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Label ID="lblPassword" runat="server" CssClass="control-label" Text="Contraseña"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Label ID="lblNombre" runat="server" CssClass="control-label" Text="Nombre"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Label ID="lblApellido" runat="server" CssClass="control-label" Text="Apellido"></asp:Label>
    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Label ID="lblEstatus" runat="server" CssClass="control-label" Text="Estatus"></asp:Label>
    <asp:DropDownList ID="drpStatus" runat="server">
    </asp:DropDownList>
    
    <br />

    <asp:Label ID="lblError" runat="server" CssClass="control-label" Text=""></asp:Label>
    <asp:Button ID="btnUpdate"  CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnInsert"  CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="btnInsert_Click" />

</asp:Content>
