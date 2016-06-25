<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistarLibro_2.aspx.cs" Inherits="ProyectoArtemisa.RegistarLibro_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <!-- -->
     <!--Cuerpo del form-->



    <div class="row">
        <div class="container col-lg-offset-3 col-lg-7" id="div_form">

            <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Registrar Libro</b></h1>
            </div>
            <br />
            


            <!--Nombre del libro -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_nombreLibro" class="control-label col-md-3">Nombre del libro: </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreDelLibro" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreDelLibro" Display="Dynamic" ValidationGroup="AllValidator">
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


             <!--Codigo de barra del libro -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_codigoBarra" class="control-label col-md-3">Código de barra: </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_codgoBarra" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_codgoBarra" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un código de barra</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />


            <!--Universidad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_universidad" class="control-label col-md-3">Universidad: </label>
                    <div class="col-md-5">
                        <asp:DropDownList AutoPostBack="true" CssClass="form-control" runat="server" ID="ddl_universidadesLibro" OnSelectedIndexChanged="ddl_universidadesLibro_SelectedIndexChanged" />
                    </div>
                    <asp:LinkButton ID="btn_registrarUniversidad" OnClick="btn_registrarUniversidad_Click" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarUniversidad"  runat="server" ><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span></asp:LinkButton>
                    <asp:CustomValidator ID="cv_pension" Display="Dynamic" ValidationGroup="AllValidator" ControlToValidate="ddl_universidadesLibro" OnServerValidate="ddl_customValidator" runat="server" ForeColor="Red" ErrorMessage="Debe seleccionar una universidad"></asp:CustomValidator>
                </div>
            </div>
            <br />


            <!--Facultad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_facultades" class="control-label col-md-3">Facultad: </label>
                    <div class="col-md-5">
                        <asp:DropDownList AutoPostBack="true" CssClass="form-control" runat="server" ID="ddl_facultadesLibro" OnSelectedIndexChanged="ddl_facultadesLibro_SelectedIndexChanged" />
                    </div>
                    <asp:LinkButton ID="btn_registrarFacultad" OnClick="btn_registrarFacultad_Click" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarFacultad"  runat="server" ><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span></asp:LinkButton>
                    <asp:CustomValidator ID="CustomValidator1" Display="Dynamic" ValidationGroup="AllValidator" ControlToValidate="ddl_facultadesLibro" OnServerValidate="ddl_customValidator" runat="server" ForeColor="Red" ErrorMessage="Debe seleccionar una facultad"></asp:CustomValidator>
                </div>
            </div>
            <br />


            <!--Materia -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_materias" class="control-label col-md-3">Materia: </label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_materiasLibro_SelectedIndexChanged" runat="server" ID="ddl_materiasLibro" />
                    </div>
                    <asp:LinkButton ID="btn_registrarMateria" OnClick="btn_registrarMateria_Click" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarMateria"  runat="server" ><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span></asp:LinkButton>
                    <asp:CustomValidator ID="CustomValidator2" Display="Dynamic" ValidationGroup="AllValidator" ControlToValidate="ddl_materiasLibro" OnServerValidate="ddl_customValidator" runat="server" ForeColor="Red" ErrorMessage="Debe seleccionar una materia"></asp:CustomValidator>
                </div>
            </div>
            <br />


            <!--Carrera -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_carreras" class="control-label col-md-3">Carreras: </label>
                    <br />
                    <div class="col-lg-6 ">
                    <asp:GridView CssClass="table table-bordered bs-table table-responsive" ID="dgv_carrerasLibro" runat="server" AutoGenerateColumns="False">
                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <Columns>
                             <asp:BoundField DataField="nombreCarrera" HeaderText="Carreras" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px">
                            <ControlStyle Width="70px"></ControlStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_modificarCarrera" CommandName="select" runat="server" ><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span></asp:LinkButton>
                                    <asp:LinkButton ID="btn_eliminarMateria" CommandName="select"  runat="server" ><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                                </ItemTemplate>   
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                        </div>
                    <asp:LinkButton ID="btn_registrarCarrera" runat="server" OnClick="btn_registrarCarrera_onClick" Visible="false"><span class="glyphicon glyphicon-plus" aria-hidden="true" ></span></asp:LinkButton>
                </div>
            </div>
            <br />


            <!--Nombre autor -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_nombreAutor" class="control-label col-md-3">Nombre del autor: </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreAutorLibro" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreAutorLibro" Display="Dynamic" ValidationGroup="AllValidator">
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


            <!-- Nombre editorial -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_editorial" class="control-label col-md-3">Editorial: </label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_editorialLibro" />
                    </div>
                    <asp:LinkButton ID="btn_registrarEditorial" OnClick="btn_registrarEditorial_onClick" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarEditorial"  runat="server" ><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span></asp:LinkButton>
                    <asp:CustomValidator ID="CustomValidator3" Display="Dynamic" ValidationGroup="AllValidator" ControlToValidate="ddl_editorialLibro" OnServerValidate="ddl_customValidator" runat="server" ForeColor="Red" ErrorMessage="Debe seleccionar una editorial"></asp:CustomValidator>
                </div>
            </div>
            <br />


            <!--Cantidad hojas -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_cantidadHojas" class="control-label col-md-3">Cantidad de Hojas: </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_cantidadHojasLibro" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_cantidadHojasLibro" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar una cantidad</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />


        


            <!--Precio Libro -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_precioLibro" class="control-label col-md-3">Precio libro:  </label>
                    <div class="col-md-2">
                        <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></div>
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_precioLibro" value="" ViewStateMode="Enabled" />
                        </div>
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_precioLibro" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un precio</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                              </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />

                <!--Descripcion -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_descripcion" class="control-label col-md-3">Descripción:  </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" TextMode="MultiLine" ID="txt_descripcionLibro" value="" ViewStateMode="Enabled" />
                        <!-- Verifica que se el textBox no este vacio-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_descripcionLibro" Display="Dynamic" ValidationGroup="AllValidator">
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

            <!--Boton confirmar -->
            <div class="row col-lg-offset-8">
                <asp:Button runat="server" ID="btn_confirmar" Text="Confirmar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" OnClick="btn_confirmar_Click" />
                <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_cancelar_Click"  />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
