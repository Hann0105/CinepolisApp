<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Complejo.aspx.cs" Inherits="HannProjectOmg.AdministradorThings.Complejo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Gestiona al Complejo</h1>

    <asp:Label ID="lblComplejo" runat="server" Text="Complejo" ></asp:Label>
    <asp:TextBox ID="txtComplejo" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="lblRegion" runat="server" Text="Region" ></asp:Label>
    <asp:DropDownList ID="drpRegion" runat="server"></asp:DropDownList>
    <br />

    <asp:Label ID="lblEstatus" runat="server" CssClass="control-label" Text="Estatus"></asp:Label>
    <asp:DropDownList ID="drpStatus" runat="server">
    </asp:DropDownList>
    
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" class="btn btn-info" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnInsert" runat="server" Text="Agregar" OnClick="btnInsert_Click" />

</asp:Content>
