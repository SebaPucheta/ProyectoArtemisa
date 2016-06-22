<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarProvincia_105.aspx.cs" Inherits="ProyectoArtemisa.RegistrarProvincia_105" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="row">
        <div class="container col-lg-offset-2 col-lg-7" id="div_form">
 
            <div class="row">
            <label for="nombre" class="estilo_titulo">Registrar Provincia</label>
            </div>
            <br />
    <!-- Nombre -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Nombre :</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreProvincia" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreProvincia" Display="Dynamic" ValidationGroup="val_universidad">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
