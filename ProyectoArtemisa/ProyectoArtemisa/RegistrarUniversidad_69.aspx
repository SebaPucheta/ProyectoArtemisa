<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarUniversidad_69.aspx.cs" Inherits="ProyectoArtemisa.RegistrarUniversidad_69" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">

    <div class="row">
        <div class="container col-lg-offset-3 col-lg-7" id="div_form">

             <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Registrar Universidad</b></h1>
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

            <div class="row col-lg-offset-8">
                <asp:Button runat="server" ID="btn_registrar" Text="Confirmar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="val_universidad" Enabled="true" OnClick="btn_registrar_Click" />
                <asp:Button runat="server" ID="btn_salir" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_salir_Click" />
            </div>

            <br />
            <br />

        </div>
    </div>


</asp:Content>

