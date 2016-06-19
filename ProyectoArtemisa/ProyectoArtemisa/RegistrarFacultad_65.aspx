<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarFacultad_65.aspx.cs" Inherits="ProyectoArtemisa.RegistrarFacultad_65" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    
     <div class="row">
        <div class="container col-lg-offset-2 col-lg-7" id="div_form">

             <!-- Titulo -->
            <div class="row">
                <div class="form-group">
                    <label for="titulo" class="h2">Registrar universidad</label>
                </div>
            </div>

            <!-- Universidad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Universidad:</label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_universidad" OnSelectedIndexChanged="ddl_universidadApunte_SelectedIndexChanged"/>
                    </div>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btn_registrarUniversidad_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                
                </div>
            </div>
            <br />

            <!-- Nombre -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Nombre :</label>
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
                    <label for="option" class="control-label col-md-3">Provincia:</label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_provincia" OnSelectedIndexChanged="ddl_universidadApunte_SelectedIndexChanged"/>
                    </div>
                    <asp:LinkButton ID="btn_registrarUniversidad" runat="server" OnClick="btn_registrarProvincia_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                
                </div>
            </div>
            <br />

            <!--Ciudad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Ciudad:</label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_ciudad" OnSelectedIndexChanged="ddl_universidadApunte_SelectedIndexChanged"/>
                    </div>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btn_registrarCiudad_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                
                </div>
            </div>
            <br />

            <div class="row col-lg-offset-8">
                <asp:Button runat="server" ID="btn_registrar" Text="Registrar" CssClass="btn btn-primary btn_flat" ValidationGroup="val_universidad" Enabled="true" OnClick="btn_registrar_Click" />
                <asp:Button runat="server" ID="btn_salir" Text="Salir" CssClass="btn btn-danger btn_flat" OnClick="btn_salir_Click" />
            </div>

            <br />
            <br />

        </div>
    </div>
    
    
    
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
