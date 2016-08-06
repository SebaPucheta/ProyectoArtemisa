<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarEditorial_22.aspx.cs" Inherits="ProyectoArtemisa.RegistrarEditorial_22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-7" id="div_form">

       <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Registrar Editorial</b></h1>
            </div>
            <br />

   

        <div>
            <!--Ingreso el nombre de la editorial -->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Nombre del proveedor</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreEditorial" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreEditorial" Display="Dynamic" ValidationGroup="AllValidator">
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

   

        <div class="row col-lg-offset-8">
            <asp:Button runat="server" ID="btn_guardar" Text="Confirmar" OnClick="btn_guardar_Click" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" />
            <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_cancelar_Click"  />
        </div>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
