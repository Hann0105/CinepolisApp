<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChecarReportes.aspx.cs" Inherits="HannProjectOmg.SupervisorThings.ChecarReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">
      <div class="py-5 text-center">
        <h2>Revisar Reporte</h2>
      </div>

    <!--Selección de Region y Complejo -->
      <div class="row">
        <div class="col-md-4 order-md-2 mb-4">
          <h4 class="d-flex justify-content-between align-items-center mb-3">
            <span class="text-muted">Región</span>
          </h4>
          <ul class="list-group mb-3">
            <li class="list-group-item d-flex justify-content-between lh-condensed">
              <div>
                <h5 class="mb-3 text-muted">Región</h5>
                 
                  <asp:Label ID="lblRegion" runat="server" Text="Label"></asp:Label>
              </div>
            </li>
               <li class="list-group-item d-flex justify-content-between lh-condensed">
              <div>
                <h5 class="mb-3 text-muted">Complejo</h5>
                  <asp:Label ID="lblComplejo" runat="server" Text="Label"></asp:Label>
              </div>
            </li>
              </li>
               <li class="list-group-item d-flex justify-content-between lh-condensed">
              <div>
                <h5 class="mb-3 text-muted">Status</h5>
                <asp:DropDownList ID="drpStatus" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                  <asp:Button ID="btnChangeStatus" runat="server" Text="Cambiar Status" OnClick="btnChangeStatus_Click" />
              </div>
            </li>
        </div>

          <!--Estatus-->
        <div class="col-md-8 order-md-1">
          <form class="needs-validation" novalidate>
            <div class="row">
           

        <!--Instalaciones-->
            <div class="row">
              <div class="col-md-8 mb-3">
               <div class="col-md-8 mb-3">
                         <label for="firstName" style="padding-left:1.5rem; margin-top:1rem">Instalaciones</label>
                          <br>
                          <asp:DropDownList ID="drpInstalaciones" AutoPostBack="true" CssClass="form-control" runat="server" ></asp:DropDownList>
                            <asp:TextBox ID="txtInstalaciones" runat="server"></asp:TextBox>
                     </div>
              </div>
            </div>


        <!--Salas-->
            <div class="row">
              <div class="col-md-8 mb-3">
               <div class="col-md-8 mb-3">
                         <label for="firstName" style="padding-left:1.5rem; margin-top:1rem">Salas</label>
                          <br>
                          <asp:DropDownList ID="drpSalas" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:TextBox ID="txtSalas" runat="server"></asp:TextBox>
                     </div>
              </div>
            </div>

               <!--Personal-->
            <div class="row">
              <div class="col-md-8 mb-3">
               <div class="col-md-8 mb-3">
                         <label for="firstName" style="padding-left:1.5rem; margin-top:1rem">Personal</label>
                          <br>

                   
                          <asp:DropDownList ID="drpPersonal" AutoPostBack="true" CssClass="form-control" runat="server" ></asp:DropDownList>
                   <asp:TextBox ID="txtPersonal" runat="server"></asp:TextBox>
                     </div>
              </div>
            </div>
                
            <!--Servicio-->
            <div class="row">
              <div class="col-md-8 mb-3">
               <div class="col-md-8 mb-3">
                         <label for="firstName" style="padding-left:1.5rem; margin-top:1rem">Servicio</label>
                          <br>
                          <asp:DropDownList ID="drpServicio" AutoPostBack="true" CssClass="form-control" runat="server" ></asp:DropDownList>
                   <asp:TextBox ID="txtServicio" runat="server"></asp:TextBox>
                     </div>
              </div>
            </div>

              <!--Insumos-->
            <div class="row">
              <div class="col-md-8 mb-3">
               <div class="col-md-8 mb-3">
                         <label for="firstName" style="padding-left:1.5rem; margin-top:1rem">Insumos</label>
                          <br>
                          <asp:DropDownList ID="drpInsumos" AutoPostBack="true" CssClass="form-control" runat="server" ></asp:DropDownList>
                   <asp:TextBox ID="txtInsumos" runat="server"></asp:TextBox>
                     </div>
              </div>
            </div>

              <!--Dulceria-->
            <div class="row">
              <div class="col-md-8 mb-3">
               <div class="col-md-8 mb-3">
                         <label for="firstName" style="padding-left:1.5rem; margin-top:1rem">Dulceria</label>
                          <br>
                          <asp:DropDownList ID="drpDulceria" AutoPostBack="true" CssClass="form-control" runat="server" ></asp:DropDownList>
                   <asp:TextBox ID="txtDulceria" runat="server"></asp:TextBox>
                     </div>
              </div>
            </div>


            <!--Servicio-->
            <div class="row">
              <div class="col-md-8 mb-3">
               <div class="col-md-8 mb-3">
                         <label for="firstName" style="padding-left:1.5rem; margin-top:1rem">Sanidad</label>
                          <br>
                          <asp:DropDownList ID="drpSanidad" AutoPostBack="true" CssClass="form-control" runat="server" ></asp:DropDownList>
                   <asp:TextBox ID="txtSanidad" runat="server"></asp:TextBox>
                     </div>
              </div>
            </div>

             <!--Taquilla-->
            <div class="row">
              <div class="col-md-8 mb-3">
               <div class="col-md-8 mb-3">
                         <label for="firstName" style="padding-left:1.5rem; margin-top:1rem">Taquilla</label>
                          <br>
                          <asp:DropDownList ID="drpTaquilla" AutoPostBack="true" CssClass="form-control" runat="server" ></asp:DropDownList>
                   <asp:TextBox ID="txtTaquilla" runat="server"></asp:TextBox>
                     </div>
              </div>
            </div>
              

                

              
            <hr class="mb-4">
                
                <asp:Label ID="lblError" runat="server"></asp:Label>
          </form>
        </div>
      </div>

    </div>

</asp:Content>
