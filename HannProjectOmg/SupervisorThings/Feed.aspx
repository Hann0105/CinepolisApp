<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feed.aspx.cs" Inherits="HannProjectOmg.SupervisorThings.Feed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col">
           <h1>Bienvenido Supervisor</h1>
            <hr />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
    </div>


   <asp:GridView ID="grdInspectores" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="idreporte"
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
             <asp:TemplateField HeaderText="Nombre Inspector">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("estatus_bueno") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    
                    <a href='/SupervisorThings/ChecarReportes?idreporte=<%# Eval("idreporte") %>' class="btn btn-info btn-lg">Revisar</a>

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

</asp:Content>
