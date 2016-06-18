<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistarLibro_2.aspx.cs" Inherits="ProyectoArtemisa.RegistarLibro_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <!-- -->
     <!--Cuerpo del form-->



    <div class="row">
        <div class="container col-lg-offset-2 col-lg-7" id="div_form">

            <h1 class="center-block">Registrar libro</h1>
            <br />
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


             <!--Nombre del libro -->
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
                    <asp:LinkButton ID="btn_registrarUniversidad" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:CustomValidator ID="cv_pension" Display="Dynamic" ValidationGroup="AllValidator" ControlToValidate="ddl_registrarUniversidad" OnServerValidate="ddl_customValidator" runat="server" ForeColor="Red" ErrorMessage="Debe seleccionar una universidad"></asp:CustomValidator>
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
                    <asp:LinkButton ID="btn_registrarFacultad" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:CustomValidator ID="CustomValidator1" Display="Dynamic" ValidationGroup="AllValidator" ControlToValidate="ddl_registrarFacultad" OnServerValidate="ddl_customValidator" runat="server" ForeColor="Red" ErrorMessage="Debe seleccionar una facultad"></asp:CustomValidator>
                </div>
            </div>
            <br />


            <!--Materia -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_materias" class="control-label col-md-3">Materia: </label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_materiasLibro" />
                    </div>
                    <asp:LinkButton ID="btn_registrarMateria" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:CustomValidator ID="CustomValidator2" Display="Dynamic" ValidationGroup="AllValidator" ControlToValidate="ddl_materiasLibro" OnServerValidate="ddl_customValidator" runat="server" ForeColor="Red" ErrorMessage="Debe seleccionar una materia"></asp:CustomValidator>
                </div>
            </div>
            <br />


            <!--Carrera -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_carreras" class="control-label col-md-3">Carreras: </label>
                    <br />
                    <asp:GridView CssClass="table table-bordered bs-table table-responsive" ID="dgv_carrerasLibro" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="idCarrera" HeaderText="Carreras" />
                            <asp:BoundField DataField="nombreCarrera" HeaderText="Nombre" />
                        </Columns>
                    </asp:GridView>
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
                    <asp:LinkButton ID="btn_registrarEditorial" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:CustomValidator ID="CustomValidator3" Display="Dynamic" ValidationGroup="AllValidator" ControlToValidate="ddl_editorialLibro" OnServerValidate="ddl_customValidator" runat="server" ForeColor="Red" ErrorMessage="Debe seleccionar una editorial"></asp:CustomValidator>
                </div>
            </div>
            <br />


            <!--Cantidad hojas -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_cantidadHojas" class="control-label col-md-3">Nombre del autor: </label>
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


            <!--Descripcion -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_descripcion" class="control-label col-md-3">Descripción:  </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_descripcionLibro" value="" ViewStateMode="Enabled" />
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


            <!--Precio Libro -->
            <div class="row">
                <div class="form-group">
                    <label for="option" id="lbl_precioLibro" class="control-label col-md-3">Precio libro:  </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_precioLibro" value="" ViewStateMode="Enabled" />
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



            <!--Boton confirmar -->
            <div class="row col-lg-offset-8">
                <asp:Button runat="server" ID="btn_confirmar" Text="Confirmar" CssClass="btn btn-primary btn_flat" ValidationGroup="AllValidator" Enabled="true" OnClick="btn_confirmar_Click" />
            </div>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
