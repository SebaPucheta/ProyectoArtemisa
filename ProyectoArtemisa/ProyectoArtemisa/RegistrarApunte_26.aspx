<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarApunte_26.aspx.cs" Inherits="ProyectoArtemisa.RegistrarApunte_26" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">Registar Apunte
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    
        <div class="row">
        <div class="container col-lg-offset-3 col-lg-7" id="div_form">
             <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Registrar Apunte</b></h1>
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
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_codigoBarra" value="" ViewStateMode="Enabled" Enabled="false" />
                        <%--<!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_codigoBarra" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un nombre</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                        </asp:RequiredFieldValidator>--%>
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
                    <div class="col-md-3">
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
                    <asp:LinkButton ID="btn_registrarUniversidad"  runat="server" OnClick="btn_registrarUniversidad_onClick"><span class="glyphicon glyphicon-plus " aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarUniversidad"  runat="server" OnClick="btn_modificarUniversidad_onClick"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
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
                    <asp:LinkButton ID="btn_registrarFacultad" OnClick="btn_registrarFacultad_onClick" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarFacultad" OnClick="btn_modificarFacultad_onClick" runat="server" ><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
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
                    <asp:LinkButton ID="btn_modificarMateria" runat="server" OnClick="btn_modificarMateria_onClick"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

           <!-- Carrera -->
            <div class="row">
                 <label for="option" class="control-label col-md-3">Carrera:</label>
               
                <div class="col-lg-6 ">
                    <asp:GridView ID="dgv_carrera" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered bs-table table-responsive" OnSelectedIndexChanged="btn_modificarCarrera_OnSelectedIndexChanged" OnRowDeleting="btn_eliminarMateria_OnRowDeleting">
                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <Columns>
                            <asp:BoundField DataField="nombreCarrera" HeaderText="Carreras" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px">
                            <ControlStyle Width="70px"></ControlStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_modificarCarrera" CommandName="select" runat="server" ><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                                    
                                </ItemTemplate>   
                                <ControlStyle Width="3px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_eliminarMateria" CommandName="delete"  runat="server" ><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
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

            <!-- Editorial -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Editorial:</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_editorialApunte" />
                    </div>
                    <asp:LinkButton ID="btn_registrarEditorial" OnClick="btn_registrarEditorial_onClick" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarEditorial" OnClick="btn_modificarEditorial_onClick"  runat="server" ><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <!-- Cantidad de hojas del apunte  -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Cantidad de Hojas :</label>
                    <div class="col-md-3">
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
                    <div class="col-md-2 col-lg-2">
                        <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></div>
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_precioXHoja" value="" ViewStateMode="Enabled"  Enabled="false"/>
                        </div>
                        </div>
                </div>
               </div>
            
            <br />

            <!--Precio apunte digital-->
            <div class="row">
                <div class="form-group form-inline">
                    <label for="nombre" class="control-label col-md-3">Precio del apunte digital :</label>
                    <div class="col-md-2 col-lg-2">
                        <div class="input-group">
                            <div class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></div>
                            <asp:TextBox runat="server" class="form-control" type="text" ID="txt_precioApunteDigital" value="" ViewStateMode="Enabled" Enabled="false" />
                        </div>
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
                    <asp:LinkButton ID="btn_modificarProfesor" runat="server" OnClick="btn_modificarProfesor_onClick"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
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
                    <asp:LinkButton ID="btn_modificarCategoria" runat="server" OnClick="btn_modificarCategoria_onClick"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <!-- Descripcion -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Descripcion:</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" type="text" ID="txt_descripcion" value="" ViewStateMode="Enabled"  />
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
