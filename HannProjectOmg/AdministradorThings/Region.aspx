<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Region.aspx.cs" Inherits="HannProjectOmg.AdministradorThings.Region" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Gestiona Región</h1>

    <asp:Label ID="lblRegion" runat="server" CssClass="control-label" Text="Region" ></asp:Label>
    <asp:TextBox ID="txtRegion"  CssClass="form-control" runat="server"></asp:TextBox>
    <br />
    
    <asp:Label ID="lblEstatus" runat="server" CssClass="control-label" Text="Estatus"></asp:Label>
    <asp:DropDownList ID="drpStatus" runat="server">
    </asp:DropDownList>
    
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnInsert" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="btnInsert_Click" />

</asp:Content>
