<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Complejos_Inspector.aspx.cs" Inherits="HannProjectOmg.AdministradorThings.Complejos_Inspector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2><a href="/AdministradorThings/GestionarInspectores" class="glyphicon glyphicon-chevron-left"></a>Gestionar Complejos</h2>

    <asp:DropDownList ID="drpComplejos" runat="server"></asp:DropDownList>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <asp:GridView ID="grdInspectores" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowDeleting="grdInspectores_RowDeleting" DataKeyNames="idRel"
                ShowHeaderWhenEmpty="true">
        <Columns>

            <asp:TemplateField HeaderText="Complejo">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Complejo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Inspector">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Inspector") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-lg btn-danger" CommandName="Delete" ToolTip="Delete" />

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>
