<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Blanco.aspx.cs" Inherits="ProyectoArtemisa.Blanco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <br />
    <br />
    <br />
    <br />

    <div class="row">
        <div class="container col-lg-offset-2 col-lg-7" id="div_form">
             <!-- Tipo Documento -->
                <div class="row">
                    <div class="form-group">
                        <label for="option" class="control-label col-md-3">Tipo Documento:</label>
                        <div class="col-md-5">
                            <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_documento" />
                        </div>
                    </div>
                </div>
            <br />
                
                <!-- Nº Documento -->
                <div class="row">
                    <div class="form-group">
                        <label for="documento" class="control-label col-md-3">Nº Documento :</label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nroDocumento" value="" ViewStateMode="Enabled" />
                            
                            <!-- Verifica que se ingrese un numero-->
                            <asp:CompareValidator ControlToValidate="txt_nroDocumento" cultureinvariantvalues="true" display="Dynamic" ID="cvr_nroDocumento" runat="server" Operator="DataTypeCheck" Type="Integer" setfocusonerror="true"  ValidationGroup="AllValidator" BorderColor="Red" CssClass="danger">
                               <div class="alert alert-danger">
                                  <strong>No se a ingresado un número</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                            </asp:CompareValidator>
                            
                            <!--Verifica que el valor ingresado sea razonablemente valido-->
                            <asp:RangeValidator ControlToValidate="txt_nroDocumento" MaximumValue="100000000" Type="Integer" EnableClientScript="false" Text="Cantidad de digitos incorrecto" runat="server"  ValidationGroup="AllValidator" MinimumValue="900000" Display="Dynamic">
                                <div class="alert alert-danger">
                                  <strong>El documento ingresado es incorrecto</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                            </asp:RangeValidator>
                           
                            <!-- Verifica que el campo no sea nulo-->
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nroDocumento" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un Nº de documento</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            <br />

                <!-- Nombre -->
                <div class="row">
                    <div class="form-group">
                        <label for="nombre" class="control-label col-md-3">Nombre :</label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombre" value="" ViewStateMode="Enabled" />
                            <!-- Verifica que se el textBox no este vacio-->
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

                <!-- Apellido -->
                <div class="row">
                    <div class="form-group">
                        <label for="apellido" class="control-label col-md-3">Apellido :</label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" class="form-control" type="text" ID="txt_apellido" value="" ViewStateMode="Enabled" />
                            
                            <!-- Verifica que se el textBox no este vacio-->
                             <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_apellido" Display="Dynamic" ValidationGroup="AllValidator">
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

                <!-- Fecha de Nacimiento-->
                <div class="row">
                    <div class="form-group">
                        <label for="apellido" class="control-label col-md-3">Fecha de Nacimiento :</label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" ID="txt_fechaNacimiento" Class="form-control" ValidationGroup="AllValidator" />
                            
                            <!-- Verifica que se ingrese un fecha en el formato correcto-->
                            <asp:CompareValidator ControlToValidate="txt_fechaNacimiento" cultureinvariantvalues="true" display="Dynamic" ID="cv_fechaNacimiento" runat="server" Operator="DataTypeCheck" Type="Date" setfocusonerror="true" ValidationGroup="AllValidator">
                                <div class="alert alert-danger">
                                  <strong>Formato de fecha invalido, el formato correcto es dd/mm/aaaa</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                           </asp:CompareValidator>
                            
                            <!-- Verifica que se ingrese un fecha de nacimiento, osea que el campo no este vacio-->
                             <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_fechaNacimiento" Display="Dynamic" ValidationGroup="AllValidator">
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

                <!-- Cuil -->
                <div class="row">
                    <div class="form-group">

                        <label for="cuil" class="control-label col-md-3">CUIL :</label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" class="form-control" type="text" ID="txt_cuil" value="" ViewStateMode="Enabled" />
                            <br />  
                            
                            
                            <!-- Verifica que el TextBox no este vacio--> 
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nroDocumento" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un Nº de documento</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />

                <!-- Discapacitado -->
                <div class="row">
                    <div class="form-group">
                         <label class="checkbox-inline col-lg-offset-2">
                           <asp:CheckBox runat="server" type="checkbox" name="" ID="chk_discapacitado" />Discapacitado </label>
                    </div>
                </div>
                <br />
            <div class="row col-lg-offset-8">
                        <asp:Button runat="server" ID="btn_confirmar" Text="Confirmar" CssClass="btn btn-primary btn_flat" ValidationGroup="AllValidator" Enabled="true" />
                        <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-danger btn_flat"  />
                    </div>
            <br />

        </div>
    </div>
    <br />
    <br />

    <div class="row">
        <div class="container col-lg-offset-2 col-lg-5" id="div_grilla">
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered bs-table table-responsive " DataSourceID="SqlDataSource1">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <Columns>
                    <asp:BoundField DataField="nroDocumento" HeaderText="nroDocumento" SortExpression="nroDocumento" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                    <asp:BoundField DataField="apellido" HeaderText="apellido" SortExpression="apellido" />
                    <asp:BoundField DataField="fechaNacimiento" HeaderText="fechaNacimiento" SortExpression="fechaNacimiento" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PAV2ConnectionString %>" SelectCommand="Select P.nroDocumento, TD.descripcion, P.nombre , P.apellido, P.fechaNacimiento From Pasajero P join TipoDNI TD on P.tipoDocumento = TD.tipoDNI "></asp:SqlDataSource>
            
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
