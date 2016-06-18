<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarLibroApunte.aspx.cs" Inherits="ProyectoArtemisa.ConsultarLibroApunte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div id="div_form">
        <div>
            <!--Titulo que le coloco al form-->
            <h1>Reporte Libro/Apunte</h1>
        </div>
        <div>
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Tipo item</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_apunteLibro"/>
                   </div>
                </div>
            </div>
            <br />
    <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Carrera</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_carrera" OnSelectedIndexChanged="ddl_carrera_SelectedIndexChanged" AutoPostBack="true"/>
                   </div>
                </div>
            </div>
            <br />
    <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Materia</label>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_materia" AutoPostBack="true"/>
                   </div>
                </div>
            </div>
            <br />
    <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Digital</label>
                    <div class="col-md-5">
                        <asp:CheckBox CssClass="form-control" runat="server" ID="ckb_digital"/>
                   </div>
                </div>
            </div>
            <br />
    <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Impreso</label>
                    <div class="col-md-5">
                        <asp:CheckBox CssClass="form-control" runat="server" ID="ckb_impreso"/>
                   </div>
                </div>
            </div>
           <br />
        <div class="row col-lg-offset-8">
            <asp:Button Text="CONSULTAR" OnClick="btn_consultar_Click" ID="btn_consultar" CssClass="btn btn-primary btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
        </div>
        <br />
            <br />

            
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true">
        <Columns>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="precio" HeaderText="Precio" />
            <asp:BoundField DataField="stock" HeaderText="Stock" />
            <asp:BoundField DataField="carrera" HeaderText="Carrera" />
            <asp:BoundField DataField="materia" HeaderText="Materia" />
        </Columns>
    </asp:GridView>

            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
