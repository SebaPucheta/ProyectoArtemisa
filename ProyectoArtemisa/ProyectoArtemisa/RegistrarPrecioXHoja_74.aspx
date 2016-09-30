<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarPrecioXHoja_74.aspx.cs" Inherits="ProyectoArtemisa.RegistrarPrecioXHoja_74" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">

    <br />
    <br />
    <br />
    <br />


    <div class="row">
        <div class="container col-lg-offset-3 col-lg-7" id="div_form">

            <!-- Titulo -->
            <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Precio de Hoja</b></h1>
            </div>
            <br />

            <!-- Precio -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Nuevo precio :</label>
                    <div class="col-md-3">

                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_precio" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_precio" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un precio</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                        </asp:RequiredFieldValidator>
                         <!-- Verifica que se el textBox tenga un nombre solo con letras y coma (no se pueden poner puntos-->
                        <asp:RegularExpressionValidator runat="server" ValidationExpression="^[0-9,]*$" ControlToValidate="txt_precio" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el precio correctamente (no usar puntos)</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <br />

            <!-- Fecha de registro -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Fecha de registro :</label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" class="form-control" Enabled ="false" type="text" ID="txt_fecha" value="" ViewStateMode="Enabled" />
                         <!-- Verifica que se ingrese un fecha en el formato correcto-->
                            <asp:CompareValidator ControlToValidate="txt_fecha" cultureinvariantvalues="true" display="Dynamic" ID="cv_fechaNacimiento" runat="server" Operator="DataTypeCheck" Type="Date" setfocusonerror="true" ValidationGroup="AllValidator">
                                <div class="alert alert-danger">
                                  <strong>Formato de fecha invalido, el formato correcto es dd/mm/aaaa</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                           </asp:CompareValidator>
                            
                            <!-- Verifica que se ingrese un fecha de nacimiento, osea que el campo no este vacio-->
                             <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_fecha" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un fecha</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                            </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />

            <div class="row col-lg-offset-8">
                <asp:Button runat="server" ID="btn_registrar" Text="Registrar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" OnClick="btn_registrar_Click" />
                <asp:Button runat="server" ID="btn_salir" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_salir_Click" />
            </div>

            <br />
            <br />

        </div>
    </div>


</asp:Content>

