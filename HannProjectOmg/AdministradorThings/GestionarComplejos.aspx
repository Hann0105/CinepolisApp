<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarComplejos.aspx.cs" Inherits="HannProjectOmg.AdministradorThings.GestionarComplejos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><a href="/AdministradorThings/Admin" class="glyphicon glyphicon-chevron-left"></a>Gestionar Complejos</h2>

    <asp:GridView ID="grdInspectores" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowDeleting="grdInspectores_RowDeleting" DataKeyNames="idComplejo"
                ShowHeaderWhenEmpty="true">
        <Columns>

            <asp:TemplateField HeaderText="idComplejo">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("idComplejo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Complejo">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Complejo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Region">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Nombre_Region") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("estatus_bueno") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    
                    <a href='/AdministradorThings/Complejo?idComplejo=<%# Eval("idComplejo") %>' class="btn btn-info btn-lg">Editar</a>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-lg btn-danger" CommandName="Delete" ToolTip="Delete" />

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <div class="container">
          <div class="row justify-content-md-center">
            <div class="col col-lg-2">
              <a href="/AdministradorThings/Complejo" class="btn btn-info">Agregar</a>
            </div>
          </div>        
    </div>

</asp:Content>
