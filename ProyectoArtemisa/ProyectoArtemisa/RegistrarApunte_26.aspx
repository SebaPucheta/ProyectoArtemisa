<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarApunte_26.aspx.cs" Inherits="ProyectoArtemisa.RegistrarApunte_26" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">Registar Apunte
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    
        <div class="row">
        <div class="container col-lg-offset-2 col-lg-7" id="div_form">


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

            <!-- Universidad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Universidad:</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_universidadApunte" OnSelectedIndexChanged="ddl_universidadApunte_OnSelectedIndexChanged" />
                    </div>
                    <asp:LinkButton ID="btn_registrarUniversidad" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <!-- Facultad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Facultad:</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_facultadApunte" />
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
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_materiaApunte" />
                    </div>
                    <asp:LinkButton ID="btn_registrarMateria" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

           <!-- Carrera -->
            <div class="row">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered bs-table table-responsive ">
                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <Columns>
                            <asp:BoundField DataField="df_carreraApunte" HeaderText="Carreras" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                <asp:LinkButton ID="btn_registrarCarrera" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
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
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_cantHojasApunte" value="" ViewStateMode="Enabled" />
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
                    <asp:TextBox runat="server" class="form-control" type="text" ID="txt_precioXHoja" value="" ViewStateMode="Enabled" />
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
                    <asp:TextBox runat="server" class="form-control" type="text" ID="txt_precioApunteDigital" value="" ViewStateMode="Enabled" />
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
                    <asp:LinkButton ID="btn_registrarProfesor" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
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
                    <asp:LinkButton ID="btn_registrarCategoria" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
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
               <asp:Button runat="server" ID="btn_confirmar" Text="Confirmar" CssClass="btn btn-primary btn_flat" ValidationGroup="AllValidator" Enabled="true" />
               <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-danger btn_flat"  />
            </div>
            <br />
         </div>
    </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
