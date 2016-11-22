<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="ProyectoArtemisa.ModificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
        <div>
    <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Registrar Empleado</b></h1>
            </div>
            <br />
        </div>

        
         <!--Ingreso la contraseña actual-->
        <div class="row">
            <div class="form-group">
                <label for="cuil" class="control-label col-md-3">Ingrese la contraseña actual:</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_pass" ViewStateMode="Enabled" TextMode="Password" />
                    <br />
                    <!--Valido que se haya insertado una contraseña-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_pass" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar una contraseña</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                    </asp:RequiredFieldValidator>
                    <asp:Label runat="server" ID="lbl_contrasenaActual" Visible="false">
                            <div class="alert alert-danger">
                                  <strong>La contraseña es incorrecta</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                    </asp:Label>
                </div>
            </div>
        </div>
        <br />

        <!--Ingreso la contraseña nueva-->
        <div class="row">
            <div class="form-group">
                <label for="cuil" class="control-label col-md-3">Ingrese la nueva contraseña:</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_passnueva" ViewStateMode="Enabled" TextMode="Password" />
                    <br />
                    <!--Valido que se haya insertado una contraseña-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_passnueva" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar una contraseña</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <br />

        <!--Ingreso la contraseña nuevamente-->
        <div class="row">
            <div class="form-group">
                <label for="cuil" class="control-label col-md-3">Repita la nueva contraseña:</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_passnueva2" ViewStateMode="Enabled" TextMode="Password" />
                    <br />
                    <!--Valido que se haya insertado una contraseña-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_passnueva2" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe reingresar la contraseña</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                    </asp:RequiredFieldValidator>
                    <!--Valido que se haya ingresado la misma contraseña que antes-->
                    <asp:CompareValidator runat="server" ControlToCompare="txt_passnueva" ControlToValidate="txt_passnueva2" Display="Dynamic" ValidationGroup="AllValidator">
                        <div class="alert alert-danger">
                                  <strong>Las contraseñas no son iguales</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                    </asp:CompareValidator>

                </div>
            </div>
        </div>
        <br />


        <div class="row col-lg-offset-8">
            <asp:Button Text="Confirmar" OnClick="btn_guardar_Click" ID="btn_guardar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
        </div>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
