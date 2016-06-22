<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarCarrera_10.aspx.cs" Inherits="ProyectoArtemisa.RegistrarCarrera_101" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
     <div class="container col-lg-offset-2 col-lg-7" id="div_form">
        <div>
            <!--Titulo que le coloco al form-->
            <div class="row">
            <label for="nombre" class="estilo_titulo">Registrar Carrera</label>
            </div>
            <br />
        </div>
        
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Universidad</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_universidad" OnSelectedIndexChanged="ddl_universidad_SelectedIndexChanged"/>
                       </div>
                    <asp:LinkButton ID="btn_registrarUniversidad" runat="server" OnClick="btn_registrarUniversidad_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                         <!--Valido que se ingrese una facultad-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_universidad" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar una Universidad</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
           <br />

            <!--Ingreso una facultad-->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Facultad</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_facultad" AutoPostBack="true"/>
                       </div>
                         <asp:LinkButton ID="btn_registrarFacultad" OnClick="btn_registrarFacultad_onClick" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                        <!--Valido que se ingrese una facultad-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_facultad" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar una Facultad</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RequiredFieldValidator>
                    </div>
             </div>
 <br />


        
        
            <!--Ingreso el nombre de la carrera-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Nombre de la carrera</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombreCarrera" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una carrera-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreCarrera" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el nombre de Carrera</strong> 
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
            <asp:Button Text="Confirmar" OnClick="btn_guardar_Click" ID="btn_guardar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
            <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_cancelar_Click"  />
        </div>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
