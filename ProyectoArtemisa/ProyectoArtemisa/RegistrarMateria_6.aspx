<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarMateria_6.aspx.cs" Inherits="ProyectoArtemisa.RegistrarMateria_6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-2 col-lg-7" id="div_form">
        <br />
        <br />
        <br />
        <br />
        <!-- Universidad -->
        <div class="row">
            <div class="form-group">
                <label for="option" class="control-label col-md-3">Universidad:</label>
                <div class="col-md-5">
                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_universidadMateria" />
                </div>
                <asp:Button runat="server" ID="btn_registrar" Text="Registrar" CssClass="btn btn-primary btn_flat" ValidationGroup="AllValidator" Enabled="true" />
            </div>
        </div>
        <br />
        <!-- Facultad -->
        <div class="row">
            <div class="form-group">
                <label for="option" class="control-label col-md-3">Facultad:</label>
                <div class="col-md-5">
                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_facultadMateria" />
                </div>
                <asp:Button runat="server" ID="Button1" Text="Registrar" CssClass="btn btn-primary btn_flat" ValidationGroup="AllValidator" Enabled="true" />
            </div>
        </div>
        <br />
        <!-- Carreras -->

        <div class="row">
                <label for="option" class="control-label col-md-3">Carrera:</label>
                <br />
                <asp:GridView ID="ggv_grillaCarrerasMateria" runat="server" AutoGenerateColumns="False" CssClass="table">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#ffffcc" />
                    <Columns>
                        <asp:BoundField DataField="idCarrera" HeaderText="Carreras" />
                        <asp:CheckBoxField HeaderText="Seleccionar" />
                    </Columns>
                </asp:GridView>
        </div>
        <br />
                <!-- Nivel de la materia -->
                <div class="row">
                    <div class="form-group">
                        <label for="documento" class="control-label col-md-3">Año de cursado :</label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nivelCursadoMateria" value="" ViewStateMode="Enabled" />
                            
                            <!-- Verifica que se ingrese un numero-->
                            <asp:CompareValidator ControlToValidate="txt_nivelCursadoMateria" cultureinvariantvalues="true" display="Dynamic" ID="cvr_anoCursadoMateria" runat="server" Operator="DataTypeCheck" Type="Integer" setfocusonerror="true"  ValidationGroup="AllValidator" BorderColor="Red" CssClass="danger">
                               <div class="alert alert-danger">
                                  <strong>No se ha ingresado un año de cursado</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                            </asp:CompareValidator>
                            
                            <!--Verifica que el valor ingresado sea razonablemente valido-->
                            <asp:RangeValidator ControlToValidate="txt_nivelCursadoMateria" MaximumValue="6" Type="Integer" EnableClientScript="false" Text="Cantidad de digitos incorrecto" runat="server"  ValidationGroup="AllValidator" MinimumValue="1" Display="Dynamic">
                                <div class="alert alert-danger">
                                  <strong>El año ingresado no es correcto</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                            </asp:RangeValidator>
                            
                            <!-- Verifica que el campo no sea nulo-->
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nivelCursadoMateria" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un año de cursado</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            <br />
        <!-- Nombre materia-->
        <div class="row">
            <div class="form-group">
                <label for="nombre" class="control-label col-md-3">Materia :</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreMateriaLibro" value="" ViewStateMode="Enabled" />
                    <!-- Verifica que se el textBox no este vacio-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreMateriaLibro" Display="Dynamic" ValidationGroup="AllValidator">
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
        <!-- Descripcion materia-->
        <div class="row">
            <div class="form-group">
                <label for="nombre" class="control-label col-md-3">Descripcion :</label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" class="form-control" type="text" ID="txt_descripcionMateriaLibro" value="" ViewStateMode="Enabled" TextMode="MultiLine"/>
                    <!-- Verifica que se el textBox no este vacio-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_descripcionMateriaLibro" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar una descripcion</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <br />

        <!--Botones -->
        <div class="row col-lg-offset-8">
            <asp:Button runat="server" ID="btn_registrarMateria" Text="Registrar" CssClass="btn btn-primary btn_flat" ValidationGroup="AllValidator" Enabled="true" OnClick="btn_registrarMateria_Click" />
            <asp:Button runat="server" ID="btn_cancelarMateria" Text="Cancelar" CssClass="btn btn-danger btn_flat" />
        </div>
        <br />
        <br />
        <br />
        <!-- Fin del FORM -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
