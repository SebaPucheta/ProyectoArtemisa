<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarCategoria_18.aspx.cs" Inherits="ProyectoArtemisa.RegistrarCategoria_18" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div id="div_form">

        <div>
            <!--Titulo que le coloco al form-->
            <h1>Registrar Categoria</h1>
        </div>

        <div>
            <!--Ingreso el nombre de la Categoria-->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Nombre de la Categoria</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreCategoria" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreCategoria" Display="Dynamic" ValidationGroup="AllValidator">
                            <div class="alert alert-danger">
                                  <strong>Se debe ingresar el nombre de la Categoria</strong> 
                                  <button class="close" data-dismiss="alert">
                                      <span>&times;</span>
                                 </button>
                                </div>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

        </div>
        <br />

        <div class="row col-lg-offset-8">
            <asp:Button runat="server" ID="btn_guardar" Text="GUARDAR" OnClick="btn_guardar_Click" CssClass="btn btn-primary btn_flat" ValidationGroup="AllValidator" Enabled="true" />
        </div>
        <br />


    </div>

</asp:Content>

