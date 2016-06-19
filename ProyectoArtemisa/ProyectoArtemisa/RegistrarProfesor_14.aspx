<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarProfesor_14.aspx.cs" Inherits="ProyectoArtemisa.RegistrarProfesor_14" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">

    <br />
    <br />
    <br />
    <br />


    <div class="row">
        <div class="container col-lg-offset-2 col-lg-7" id="div_form">

            <!-- Titulo -->
            <div class="row">
                <div class="form-group">
                    <label for="titulo" class="h2">Registrar profesor</label>
                </div>
            </div>

            <!-- Nombre -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Nombre :</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombre" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombre" Display="Dynamic" ValidationGroup="val_profesor">
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

            <!-- Apellido -->
            <div class="row">
                <div class="form-group">
                    <label for="apellido" class="control-label col-md-3">Apellido :</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_apellido" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_apellido" Display="Dynamic" ValidationGroup="val_profesor">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un apellido</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />

            <!-- Materia -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Materia:</label>
                    <div class="col-md-5">
                        <asp:label CssClass="form-control" runat="server" ID="lbl_materiaProfesor" />
                    </div>
                    <asp:LinkButton ID="btn_registrarMateria" runat="server" OnClick="btn_registrarMateria_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <div class="row col-lg-offset-8">
                <asp:Button runat="server" ID="btn_registrar" Text="Registrar" CssClass="btn btn-primary btn_flat" ValidationGroup="val_profesor" Enabled="true" OnClick="btn_registrar_Click" />
                <asp:Button runat="server" ID="btn_salir" Text="Salir" CssClass="btn btn-danger btn_flat"/>
            </div>

            <br />
            <br />

        </div>
    </div>





</asp:Content>

