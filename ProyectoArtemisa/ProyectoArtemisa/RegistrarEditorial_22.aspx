<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarEditorial_22.aspx.cs" Inherits="ProyectoArtemisa.RegistrarEditorial_22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-2 col-lg-7" id="div_form">

       <div class="row">
            <label for="nombre" class="estilo_titulo">Registrar Editorial</label>
            </div>
            <br />

        <div>
            <!--Ingreso el nombre de-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Nombre Editorial</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreEditorial" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreEditorial" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el nombre de la Editorial</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

        </div>
        <div>
            <!--Ingreso el nombre de-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Nombre del contacto</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreContacto" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreContacto" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el nombre del contacto de la Editorial</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

        </div>

        <div>
            <!--Ingreso el nombre de-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Telefono</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_telefono" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_telefono" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el numero de la Editorial</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

        </div>

        <div>
             <!-- Provincia -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Provincia:</label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_provincia" OnSelectedIndexChanged="ddl_provinciaApunte_SelectedIndexChanged"/>
                    </div>
                   <asp:LinkButton ID="btn_registrarProvincia" runat="server" OnClick="btn_registrarProvincia_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                
                </div>
            </div>
            <br />

            <!--Ciudad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Ciudad:</label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_ciudad" />
                    </div>
                    <asp:LinkButton ID="btn_registrarCiudad" runat="server" OnClick="btn_registrarCiudad_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                
                </div>
            </div>
            <br />

            <!--Ingreso el nombre de-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Direccion</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_direccion" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_direccion" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar la direccion de la Editorial</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

        </div>
        <div>
            <!--Ingreso el nombre de-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Email</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_email" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_email" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el email de la Editorial</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="reEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt_email" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un email valido</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
        </div>
        <br />

        <div class="row col-lg-offset-8">
            <asp:Button runat="server" ID="btn_guardar" Text="Confirmar" OnClick="btn_guardar_Click" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" />
            <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_cancelar_Click"  />
        </div>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
