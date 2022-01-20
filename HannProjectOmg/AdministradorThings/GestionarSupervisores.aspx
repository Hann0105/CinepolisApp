<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarSupervisores.aspx.cs" Inherits="HannProjectOmg.AdministradorThings.GestionarSupervisores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><a href="/AdministradorThings/Admin" class="glyphicon glyphicon-chevron-left"></a>Gestionar Supervisores</h2>
    <hr />

    <asp:GridView ID="grdInspectores" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowDeleting="grdInspectores_RowDeleting" DataKeyNames="idUsuario"
                ShowHeaderWhenEmpty="true">
        <Columns>

            <asp:TemplateField HeaderText="idUsuario">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("idUsuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Apellido">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Apellido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("estatus_bueno") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    
                    <a href='/AdministradorThings/Supervisor?idUsuario=<%# Eval("idUsuario") %>' class="btn btn-info">Editar</a>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete" ToolTip="Delete" />

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <div class="container">
          <div class="row justify-content-md-center">
            <div class="col col-lg-2">
             <a href="/AdministradorThings/Supervisor" class="btn btn-info">Agregar</a>
            </div>
          </div>        
    </div>

</asp:Content>
