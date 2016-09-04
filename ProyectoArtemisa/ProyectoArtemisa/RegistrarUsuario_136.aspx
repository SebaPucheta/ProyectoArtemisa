<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario_136.aspx.cs" Inherits="ProyectoArtemisa.RegistrarUsuario_136" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">


    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
        <div>
            <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Registrar Usuario</b></h1>
            </div>
            <br />
        </div>

        <!--Ingreso el nombre de usuario-->
        <div class="row">
            <div class="form-group">
                <label for="cuil" class="control-label col-md-3">Nombre de usuario</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombreUsuario" ViewStateMode="Enabled" />
                    <br />
                    <!--Valido que se haya insertado un nombre de usuario-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreUsuario" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el nombre de usuario</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <br />

        <!--Ingreso el nombre de cliente-->
        <div class="row">
            <div class="form-group">
                <label for="cuil" class="control-label col-md-3">Nombre</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre" ViewStateMode="Enabled" />
                    <br />
                    <!--Valido que se haya insertado un nombre de cliente-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombre" Display="Dynamic" ValidationGroup="AllValidator">
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

        <!--Ingreso el apellido de cliente-->
        <div class="row">
            <div class="form-group">
                <label for="cuil" class="control-label col-md-3">Apellido</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido" ViewStateMode="Enabled" />
                    <br />
                    <!--Valido que se haya insertado un apellido de cliente-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_apellido" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el nombre de usuario</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <br />

        <!--Ingreso el número de documento-->
        <div class="row">
            <div class="form-group">
                <label for="cuil" class="control-label col-md-3">D.N.I.</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_dni" ViewStateMode="Enabled" />
                    <br />
                    <!--Valido que se haya insertado un dni-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_dni" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un D.N.I.</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                  </button>
                            </div>
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <br />

        <!--Ingreso el correo electrónico-->
        <div class="row">
            <div class="form-group">
                <label for="cuil" class="control-label col-md-3">e-mail</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_email" ViewStateMode="Enabled" TextMode="Email" />
                    <br />
                    <!--Valido que se haya insertado un email-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_email" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un e-mail</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                    </asp:RequiredFieldValidator>
                    <!--Valido que se haya insertado un email con su formato correcto-->
                    <asp:RegularExpressionValidator runat="server" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" ControlToValidate="txt_email" Display="Dynamic" ValidationGroup="AllValidator">
                        <div class="alert alert-danger">
                                  <strong>Se debe ingresar un e-mail correctamente</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                    </asp:RegularExpressionValidator>


                </div>
            </div>
        </div>
        <br />

        <!--Ingreso la contraseña-->
        <div class="row">
            <div class="form-group">
                <label for="cuil" class="control-label col-md-3">Ingrese la contraseña</label>
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
                </div>
            </div>
        </div>
        <br />

        <!--Ingreso la contraseña nuevamente-->
        <div class="row">
            <div class="form-group">
                <label for="cuil" class="control-label col-md-3">Repita la contraseña</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_pass2" ViewStateMode="Enabled" TextMode="Password" />
                    <br />
                    <!--Valido que se haya insertado una contraseña-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_pass2" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe reingresar la contraseña</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                    </asp:RequiredFieldValidator>
                    <!--Valido que se haya ingresado la misma contraseña que antes-->
                    <asp:CompareValidator runat="server" ControlToCompare="txt_pass" ControlToValidate="txt_pass2" Display="Dynamic" ValidationGroup="AllValidator">
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
            <asp:Button Text="Crear" OnClick="btn_guardar_Click" ID="btn_guardar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
            <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_cancelar_Click" />
        </div>
        <br />
    </div>


</asp:Content>

