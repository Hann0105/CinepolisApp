<%@ Page Title="Inicio Sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HannProjectOmg._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


        <center>
        <h3>Iniciar Sesión</h3>
            <div class="row">
            <div class="col">         
                 <hr>
             </div>
             </div>
            <!-- Inicio de Sesión-->
                  <div class="row">
                     <div class="col">
                        <label>Usuario</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtUser" runat="server" placeholder="Usuario"></asp:TextBox>
                        </div>
                        <label>Contraseña</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <asp:Button class="btn btn-primary btn-block btn-lg" ID="InicioSesion" runat="server" Text="Iniciar Sesión" OnClick="InicioSesionButton"/>
                        </div>
                          <asp:Label ID="lblSalida" runat="server" style="color: #dc3545"></asp:Label>
                       <!-- <div class="form-group">
                           <a href="usersignup.aspx"><input class="btn btn-info btn-block btn-lg" id="Button2" type="button" value="Sign Up" /></a>
                        </div>-->
                     </div>
                  </div>
                </center>

</asp:Content>

