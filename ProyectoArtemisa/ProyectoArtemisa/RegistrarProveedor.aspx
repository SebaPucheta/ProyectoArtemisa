<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarProveedor.aspx.cs" Inherits="ProyectoArtemisa.RegistrarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    

    <div class="container col-lg-offset-3 col-lg-7" id="div_form">

        <!-- Titulo -->
        <div class="row">
            <h1 class="text-primary text-center"><b>Registrar Proveedor</b></h1>
        </div>
        <br />

        <div>
            <!--Ingreso el nombre del proveedor -->
            <div class="row">
                <div class="form-group">
                    <label for="nombreProveedor" class="control-label col-md-3">Nombre del proveedor: </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreProveedor" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreProveedor" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el nombre del proveedor</strong> 
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
            <!--Ingreso el nombre del contacto-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Nombre del contacto: </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreContacto" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreContacto" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el nombre del contacto</strong> 
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
            <!--Ingreso el telefono-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Teléfono: </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_telefono" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_telefono" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el número de teléfono de la editorial</strong> 
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
            <!-- Provincia -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Provincia: </label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_provincia" OnSelectedIndexChanged="ddl_provincia_SelectedIndexChanged" />
                    </div>
                    <asp:LinkButton ID="btn_registrarProvincia" runat="server" OnClick="btn_registrarProvincia_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarProvincia" runat="server"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>

                </div>
            </div>
            <br />

            <!--Ciudad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Ciudad: </label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_ciudad" />
                    </div>
                    <asp:LinkButton ID="btn_registrarCiudad" runat="server" OnClick="btn_registrarCiudad_onClick"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    <asp:LinkButton ID="btn_modificarCiudad" runat="server"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <br />

            <div>
                <!--Ingreso de la direccion-->
                <div class="row">
                    <div class="form-group">
                        <label for="cuil" class="control-label col-md-3">Dirección: </label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" class="form-control" type="text" ID="txt_direccion" value="" ViewStateMode="Enabled" />
                            <br />
                            <!--Valido que se haya insertado una categoria-->
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_direccion" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar una dirección</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div>
            <!--Ingreso el email-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">E-mail: </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_email" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_email" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el e-mail de la Editorial</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="reEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt_email" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar un e-mail válido</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
        </div>

        <!-- Grilla Editoriales-->
        <asp:GridView ID="dgv_grillaEditoriales" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnSelectedIndexChanged="btn_modificarEditorial_SelectedIndexChanged">
            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#ffffcc" />
            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
            <Columns>
                <asp:BoundField DataField="nombreEditorial" HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                <asp:TemplateField HeaderText="Agregar editorial">
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_agregarEditorial" CommandName="select" runat="server"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="10px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:GridView ID="dgv_grillaEditorialesSeleccionadas" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowDeleting="btn_eliminarEditorial_RowDeleting">
            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#ffffcc" />
            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
            <Columns>
                <asp:BoundField DataField="nombreEditorial" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_eliminarEditorial" CommandName="delete" runat="server"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="10px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


        <div class="row col-lg-offset-8">
            <asp:Button runat="server" ID="btn_guardar" Text="Confirmar" OnClick="btn_guardar_Click" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" />
            <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" OnClick="btn_cancelar_Click" CssClass="btn btn-lg btn_rojo btn_flat" />
        </div>
        <br />
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
