<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarApunte_26.aspx.cs" Inherits="ProyectoArtemisa.RegistrarApunte_26" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">Registar Apunte
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    
        <div class="row">
        <div class="container col-lg-offset-2 col-lg-7" id="div_form">
            <div class="row">
            <label for="nombre" class="estilo_titulo">Registrar Apunte</label>
            </div>
            <br />

              <!-- Tipo de apunte -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Tipo Apunte :</label>
                    <div class="col-md-3">
                        <asp:checkBox runat="server" type="text" Text="Digital" ID="chk_digital" AutoPostBack="true" value="" ViewStateMode="Enabled" OnCheckedChanged="chk_digital_CheckedChanged" />
                    </div>
                    <div class="col-md-3">
                        <asp:checkBox runat="server" type="text" Text="Impreso" ID="chk_impreso" AutoPostBack="true" value="" ViewStateMode="Enabled" OnCheckedChanged="chk_impreso_CheckedChanged" />   
                    </div>
                </div>
            </div>
            <br />

            <!-- Codigo de barra -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Código de Barra :</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_codigoBarra" value="" ViewStateMode="Enabled" Enabled="true" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_codigoBarra" Display="Dynamic" ValidationGroup="AllValidator">
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
            
            <!-- Nombre del apunte -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Nombre :</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreApunte" value="" ViewStateMode="Enabled" />
                        
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreApunte" Display="Dynamic" ValidationGroup="AllValidator">
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

            <!-- Año del apunte -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Año :</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_ano" value="" ViewStateMode="Enabled" />
                        
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_ano" Display="Dynamic" ValidationGroup="AllValidator">
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

            <!-- Universidad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Universidad:</label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_universidadApunte" OnSelectedIndexChanged="ddl_universidadApunte_SelectedIndexChanged"/>
                    </div>
                    <asp:LinkButton ID="btn_registrarUniversidad" runat="server" OnClick="btn_registrarUniversidad_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                
                </div>
            </div>
            <br />

            <!-- Facultad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Facultad:</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_facultadApunte" OnSelectedIndexChanged="ddl_facultadApunte_SelectedIndexChanged" />
                    </div>
                    <asp:LinkButton ID="btn_registrarFacultad" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <!-- Materia -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Materia:</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_materiaApunte" OnSelectedIndexChanged="ddl_materiaApunte_SelectedIndexChanged" AutoPostBack="true" />
                    </div>
                    <asp:LinkButton ID="btn_registrarMateria" runat="server" OnClick="btn_registrarMateria_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

           <!-- Carrera -->
            <div class="row">
                    <br />
                    <asp:GridView ID="dgv_carrera" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered bs-table table-responsive ">
                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <Columns>
                            <asp:BoundField DataField="nombreMateria" HeaderText="Carreras" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px">
<ControlStyle Width="70px"></ControlStyle>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                <asp:LinkButton ID="btn_registrarCarrera" runat="server" OnClick="btn_registrarCarrera_onClick" Visible="false"><span class="glyphicon glyphicon-plus" aria-hidden="true" ></span></asp:LinkButton>
            </div>
            <br />

            <!-- Nombre el autor del apunte -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Nombre de Autor:</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreAutorApunte" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreAutorApunte" Display="Dynamic" ValidationGroup="AllValidator">
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

            <!-- Editorial -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Editorial:</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_editorialApunte" />
                    </div>
                    <asp:LinkButton ID="btn_regitrarEditorial" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <!-- Cantidad de hojas del apunte  -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Cantidad de Hojas :</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_cantHojasApunte" value="" ViewStateMode="Enabled" OnTextChanged="txt_cantHojasApunte_TextChanged" AutoPostBack="true"  />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_cantHojasApunte" Display="Dynamic" ValidationGroup="AllValidator">
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

            <!-- Precio del apunte-->
            <div class="row">
                <div class="form-group form-inline">
                    <!-- Precio apunte impreso-->
                    <label for="nombre" class="control-label col-md-3">Precio apunte impreso :</label>
                    <div class="col-md-1 col-lg-1">
                    <asp:TextBox runat="server" class="form-control" type="text" ID="txt_precioXHoja" value="" ViewStateMode="Enabled"  Enabled="false"/>
                    <!-- Verifica que se el textBox no este vacio-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_precioXHoja" Display="Dynamic" ValidationGroup="AllValidator">
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
            
            <!--Precio apunte digital-->
            <div class="row">
                <div class="form-group form-inline">
                    <label for="nombre" class="control-label col-md-3">Precio del apunte digital :</label>
                    <div class="col-md-1 col-lg-1">
                    <asp:TextBox runat="server" class="form-control" type="text" ID="txt_precioApunteDigital" value="" ViewStateMode="Enabled" Enabled="false"/>
                    <!-- Verifica que se el textBox no este vacio-->
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_precioApunteDigital" Display="Dynamic" ValidationGroup="AllValidator">
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
            
            <!-- Profesor -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Profesor:</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_profesorApunte" />
                    </div>
                    <asp:LinkButton ID="btn_registrarProfesor" runat="server" OnClick="btn_registrarProfesor_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <!-- Categoria -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Categoria:</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_categoriaApunte" />
                    </div>
                    <asp:LinkButton ID="btn_registrarCategoria" runat="server" OnClick="btn_registrarCategoria_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <!-- Descripcion -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Descripcion:</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_descripcion" value="" ViewStateMode="Enabled" Rows="3" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_descripcion" Display="Dynamic" ValidationGroup="AllValidator">
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
            <br />
            <br />
            

            <!-- Botones -->
            <div class="row col-lg-offset-8">
               <asp:Button runat="server" ID="btn_confirmar" Text="Confirmar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" OnClick="btn_confirmar_Click"/>
               <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_cancelar_Click"  />
            </div>
            <br />
         </div>
    </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server"></asp:Content>
