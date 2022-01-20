<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="HannProjectOmg.AdministradorThings.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Bienvenido Administrador</h2>

    <a href="/AdministradorThings/GestionarRegiones.aspx" class="btn btn-primary">Gestionar Regiones</a>
    <a href="/AdministradorThings/GestionarComplejos.aspx" class="btn btn-primary">Gestionar Complejos</a>
    <a href="/AdministradorThings/GestionarSupervisores.aspx" class="btn btn-primary">Gestionar Supervisores</a>
    <a href="/AdministradorThings/GestionarInspectores.aspx" class="btn btn-primary">Gestionar Inspectores</a>
    
    
</asp:Content>
