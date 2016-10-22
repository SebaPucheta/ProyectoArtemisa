<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarFacultad_65.aspx.cs" Inherits="ProyectoArtemisa.RegistrarFacultad_65" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    
     <div class="row">
        <div class="container col-lg-offset-3 col-lg-7" id="div_form">

             <!-- Titulo -->
              <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Registrar Facultad</b></h1>
            </div>
            <br />

            <!-- Universidad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Universidad: </label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_universidadFacultad" />
                    </div>
                    <asp:LinkButton ID="btn_registrarUniversidad" runat="server" OnClick="btn_registrarUniversidad_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarUniversidad"  runat="server" ><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <!-- Nombre -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Nombre: </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombre" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombre" Display="Dynamic" ValidationGroup="val_universidad">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un nombre</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />  

            <!-- Provincia -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Provincia: </label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_provincia" OnSelectedIndexChanged="ddl_provinciaApunte_SelectedIndexChanged"/>
                    </div>
                   <asp:LinkButton ID="btn_registrarProvincia" runat="server" OnClick="btn_registrarProvincia_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarProvincia" runat="server" ><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <!--Ciudad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Ciudad: </label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_ciudad" />
                    </div>
                    <asp:LinkButton ID="btn_registrarCiudad" runat="server" OnClick="btn_registrarCiudad_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarCiudad" runat="server" ><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <div class="row col-lg-offset-8">
                <asp:Button runat="server" ID="btn_registrar" Text="Confirmar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="val_universidad" Enabled="true" OnClick="btn_registrar_Click" />
                <asp:Button runat="server" ID="btn_salir" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_salir_Click" />
            </div>

            <br />
            <br />

        </div>
    </div>
    
    
    
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
