<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarEditorial_25.aspx.cs" Inherits="ProyectoArtemisa.ConsultarEditorial_25" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">

    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
     <div class="form-group">
        
         <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Consultar Editorial</b></h1>
            </div>
            <br />
         
       
       
         
            <!-- Nombre de la editorial -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Nombre de la Editorial:</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreEditorial" value="" ViewStateMode="Enabled" />
                    </div>
                </div>
            </div>
            <br />
            
            <!-- Nombre del contacto -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Nombre del Contacto:</label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreContacto" value="" ViewStateMode="Enabled" />
                    </div>
                </div>
            </div>
            <br />
            
             <!-- Provincia -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Provincia:</label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_provincia" OnSelectedIndexChanged="ddl_provincia_SelectedIndexChanged"/>
                    </div>
                </div>
            </div>
            <br />

            <!--Ciudad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Ciudad:</label>
                    <div class="col-md-5">
                        <asp:dropdownlist CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_ciudad" />
                    </div>
                </div>
            </div>
            <br />
            <br />
                <br /><br />
    
            <!-- Boton de busqueda-->
            <div class="row col-lg-offset-9 col-md-offset-9 col-md-offset-9 col-sm-offset-9">
              <asp:Button Text="Buscar" OnClick="btn_buscar_Click" ID="btn_consultar" CssClass="btn btn-lg btn_verde btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
            </div>
            <br />
            <br />

            
    <asp:GridView ID="dgv_grillaEditorial" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true" OnRowDeleting="btn_eliminarEditorial_RowDeleting" OnSelectedIndexChanged="btn_modificarEditorial_SelectedIndexChanged">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
        <Columns>
            <asp:BoundField DataField="nombreEditorial" HeaderText="Nombre" />
            <asp:BoundField DataField="nombreContacto" HeaderText="Contacto" />
            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="nombreCiudadEditorial" HeaderText="Ciudad" />
            <asp:BoundField DataField="direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="email" HeaderText="Email" />
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
     </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
