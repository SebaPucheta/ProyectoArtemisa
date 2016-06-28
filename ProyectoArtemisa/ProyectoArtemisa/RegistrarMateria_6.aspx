<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarMateria_6.aspx.cs" Inherits="ProyectoArtemisa.RegistrarMateria_6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
        
         <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Registrar Materia</b></h1>
            </div>
            <br />
        <!-- Universidad -->
        <div class="row">
            <div class="form-group">
                <label for="option" class="control-label col-md-3">Universidad:</label>
                <div class="col-md-5">
                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_universidadMateria" OnSelectedIndexChanged="ddl_universidadMateria_SelectedIndexChanged"  AutoPostBack="true"/>
                </div>
                <asp:LinkButton ID="btn_registrarUniversidad" runat="server" OnClick="btn_registrarUniversidad_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                <asp:LinkButton ID="btn_modificarUniversidad"  runat="server" ><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
            </div>
        </div>
        <br />
        <!-- Facultad -->
        <div class="row">
            <div class="form-group">
                <label for="option" class="control-label col-md-3">Facultad:</label>
                <div class="col-md-5">
                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_facultadMateria" OnSelectedIndexChanged="ddl_facultadMateria_SelectedIndexChanged" AutoPostBack="true" />
                </div>
                <asp:LinkButton ID="btn_registrarFacultad" OnClick="btn_registrarFacultad_onClick" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                <asp:LinkButton ID="btn_modificarFacultad"  runat="server" ><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
            </div>
        </div>
        <br />
        <!-- Carreras -->

        <div class="row">
            
                <label for="option" class="control-label col-md-3">Carrera:</label>
                <br />
            <div class="col-lg-6 ">
                <asp:GridView ID="ggv_grillaCarrerasMateria" runat="server" AutoGenerateColumns="False" CssClass="table">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#ffffcc" />
                    <Columns>
                        <asp:BoundField DataField="df_idCarrera" HeaderText="ID Carrera" />
                        <asp:BoundField DataField="df_nombreCarrera" HeaderText="Carreras" />
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                        <ItemTemplate>
                        <asp:CheckBox ID="chk_seleccionado" runat="server" DataField="df_chk_seleccionado" EnableViewState="true" />
                        </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_modificarCarrera" CommandName="select" runat="server" ><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                                </ItemTemplate>   
                                <ControlStyle Width="3px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
            <asp:LinkButton ID="btn_registrarCarrera" runat="server" OnClick="btn_registrarCarrera_onClick" Visible="false"><span class="glyphicon glyphicon-plus" aria-hidden="true" ></span></asp:LinkButton>
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
            <asp:Button runat="server" ID="btn_registrarMateria" Text="Confirmar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" OnClick="btn_registrarMateria_Click" />
            <asp:Button runat="server" ID="btn_cancelarMateria" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_cancelarMateria_Click" />
        </div>
        <br />
        <br />
        <br />
        <!-- Fin del FORM -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
