<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarEditorial_22.aspx.cs" Inherits="ProyectoArtemisa.RegistrarEditorial_22" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-7" id="div_form">

        <!-- Titulo -->
        <div class="row">
            <h1 class="text-primary text-center"><b>Registrar Editorial</b></h1>
        </div>
        <br />



        <div>
            <!--Ingreso el nombre de la editorial -->
            <div class="row">
                <div class="form-group">
                    <label for="cuil" class="control-label col-md-3">Nombre de la editorial</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreEditorial" value="" ViewStateMode="Enabled" />
                        <br />
                        <!--Valido que se haya insertado una categoria-->
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nombreEditorial" Display="Dynamic" ValidationGroup="AllValidator" ForeColor="Red" ErrorMessage="Debe ingresar un nombre">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

        </div>


        <div class="row col-lg-offset-8">
            <asp:Button runat="server" ID="btn_guardar" Text="Confirmar" OnClick="btn_guardar_Click" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" />
            <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_cancelar_Click" />
        </div>
        <br />


        <asp:GridView ID="dgv_grillaEditorial" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true" OnRowDeleting="btn_eliminarEditorial_RowDeleting" OnSelectedIndexChanged="btn_modificarEditorial_SelectedIndexChanged">
            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#ffffcc" />
            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
            <Columns>
                <asp:BoundField DataField="idEditorial" HeaderText="Cod." />
                <asp:BoundField DataField="nombreEditorial" HeaderText="Nombre" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_modificarEditorial" CommandName="select" runat="server"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="10px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_eliminarEditorial" CommandName="delete" runat="server"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="10px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>

            </Columns>
        </asp:GridView>


    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
