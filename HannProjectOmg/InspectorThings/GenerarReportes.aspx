<%@ Page Title="Generar Reporte" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GenerarReportes.aspx.cs" Inherits="HannProjectOmg.InspectorThings.GenerarReportes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<head>
 <link href="../Content/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="form-validation.css" rel="stylesheet">
  </head>

  <body>

    <div class="container">
      <div class="py-5 text-center">
        <h2>Generar Reporte</h2>
      </div>

    <!--Selección de Region y Complejo -->
      <div class="row">
        <div class="col-md-4 order-md-2 mb-4">
          <h4 class="d-flex justify-content-between align-items-center mb-3">
            <span class="text-muted">Región asignada</span>
          </h4>
          <ul class="list-group mb-3">
            <li class="list-group-item d-flex justify-content-between lh-condensed">
              <div>
                <h5 class="mb-3 text-muted">Región</h5>
                 
                <asp:DropDownList ID="drpRegion" AutoPostBack="true" CssClass="form-select form-select-sm" runat="server" OnSelectedIndexChanged="drpRegion_SelectedIndexChanged"></asp:DropDownList>
              </div>
            </li>
               <li class="list-group-item d-flex justify-content-between lh-condensed">
              <div>
                <h5 class="mb-3 text-muted">Complejo</h5>
                <asp:DropDownList ID="drpComplejo" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
              </div>
            </li>
              </li>
               <li class="list-group-item d-flex justify-content-between lh-condensed">
              <div>
                <h5 class="mb-3 text-muted">Status</h5>
                <asp:DropDownList ID="drpStatus" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
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
                          <asp:DropDownList ID="drpInstalaciones" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpInstalaciones_SelectedIndexChanged"></asp:DropDownList>
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
                          <asp:DropDownList ID="drpSalas" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpSalas_SelectedIndexChanged"></asp:DropDownList>
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

                   
                          <asp:DropDownList ID="drpPersonal" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpPersonal_SelectedIndexChanged"></asp:DropDownList>
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
                          <asp:DropDownList ID="drpServicio" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpServicio_SelectedIndexChanged"></asp:DropDownList>
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
                          <asp:DropDownList ID="drpInsumos" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpInsumos_SelectedIndexChanged"></asp:DropDownList>
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
                          <asp:DropDownList ID="drpDulceria" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpDulceria_SelectedIndexChanged"></asp:DropDownList>
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
                          <asp:DropDownList ID="drpSanidad" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpSanidad_SelectedIndexChanged"></asp:DropDownList>
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
                          <asp:DropDownList ID="drpTaquilla" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpTaquilla_SelectedIndexChanged"></asp:DropDownList>
                   <asp:TextBox ID="txtTaquilla" runat="server"></asp:TextBox>
                     </div>
              </div>
            </div>
              

                

              
            <hr class="mb-4">
                <asp:Button ID="btnRegistrar" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="Enviar" OnClick="btnRegistrar_Click" />
                <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-primary btn-lg btn-block" Text="Editar" OnClick="btnEditar_Click" />
                <asp:Label ID="lblError" runat="server"></asp:Label>
          </form>
        </div>
      </div>

    </div>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery-slim.min.js"><\/script>')</script>
    <script src="../../assets/js/vendor/popper.min.js"></script>
    <script src="../../dist/js/bootstrap.min.js"></script>
    <script src="../../assets/js/vendor/holder.min.js"></script>
    <script>
      // Example starter JavaScript for disabling form submissions if there are invalid fields
      (function() {
        'use strict';

        window.addEventListener('load', function() {
          // Fetch all the forms we want to apply custom Bootstrap validation styles to
          var forms = document.getElementsByClassName('needs-validation');

          // Loop over them and prevent submission
          var validation = Array.prototype.filter.call(forms, function(form) {
            form.addEventListener('submit', function(event) {
              if (form.checkValidity() === false) {
                event.preventDefault();
                event.stopPropagation();
              }
              form.classList.add('was-validated');
            }, false);
          });
        }, false);
      })();
    </script>
  </body>

</asp:Content>
