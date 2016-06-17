<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarCarrera_10.aspx.cs" Inherits="ProyectoArtemisa.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
    <!--Este es un formulario para ver si se ejecuta siempre, aparte se va usar como pagina por defecto para cargar.-->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div id="div_form">
        <div>
            <!--Titulo que le coloco al form-->
            <h1>Registrar Carrera</h1>
        </div>
        <div>
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Universidad</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_universidad" />
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
            </div>
        </div>

        <div>
            <br />
            <!--Ingreso una facultad-->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Facultad</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_facultad" />
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
            </div>



            <br />
        </div>
        <div>
            <!--Ingreso el nombre de la carrera-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Nombre de la carrera</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreCarrera" value="" ViewStateMode="Enabled" />
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

        </div>
        <br />
        <div>
            <!--Boton guardar la carrera-->
            <asp:Button Text="GUARDAR" runat="server"  CssClass="btn btn-default" ID="btn_guardar" />
        </div>


    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
