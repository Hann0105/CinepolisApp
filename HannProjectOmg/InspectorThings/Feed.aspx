<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feed.aspx.cs" Inherits="HannProjectOmg.Feed" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <div class="row">
        <div class="col">
           <h1>Bienvenido Inspector</h1>
            <hr />

             <div class="container">
              <div class="row justify-content-md-center">
                <div class="col col-lg-2">
                 <a href="/InspectorThings/GenerarReportes" class="btn btn-primary">Generar Reportes</a><asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </div>
              </div>        
             </div>
        </div>
    </div>
    <br />


   <asp:GridView ID="grdInspectores" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowDeleting="grdInspectores_RowDeleting" DataKeyNames="idreporte"
                ShowHeaderWhenEmpty="true">
        <Columns>

            <asp:TemplateField HeaderText="Fecha">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Fecha") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Complejo">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Complejo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Región">
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
                    
                    <a href='/InspectorThings/GenerarReportes?idreporte=<%# Eval("idreporte") %>' class="btn btn-info btn-lg">Editar</a>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-lg btn-danger" CommandName="Delete" ToolTip="Delete" />

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    
</asp:Content>

