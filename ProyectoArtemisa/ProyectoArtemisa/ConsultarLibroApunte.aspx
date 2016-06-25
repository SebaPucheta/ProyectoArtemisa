<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarLibroApunte.aspx.cs" Inherits="ProyectoArtemisa.ConsultarLibroApunte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
   <div class="container col-lg-offset-3 col-lg-7" id="div_form">
     <div class="form-group">
        
         <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Consultar Item</b></h1>
            </div>
            <br />
         
       
       
         <!-- Tipo de Item-->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Tipo Item:</label>
                    <div class="col-md-4">
                        <asp:DropDownList  CssClass="form-control" runat="server" ID="ddl_tipoItem" AutoPostBack="true" OnSelectedIndexChanged=" ddl_tipoItem_SelectedIndexChanged"/>
                   </div>
                </div>
             <br />
            <br />
            
                <!--Tipo de apunte -->
                <div class="row">
                    <div class="form-group">
                        <asp:label runat="server"  Visible="false" for="option" class="control-label col-md-3"><strong>Tipo de Apunte:</strong></asp:label>
                        <div class=" col-md-5">
                            <div class="col-md-4">
                                <asp:Label runat="server" Visible="false" class="checkbox-inline">
                                    <asp:CheckBox runat="server" type="checkbox" name="" ID="chk_apunteDigital" /><strong>Digital</strong></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:Label runat="server" Visible="false" class="checkbox-inline">
                                    <asp:CheckBox runat="server" type="checkbox" name="" ID="chk_apunteImpreso" /><strong>Impreso</strong></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
            
            
            <!-- Universidad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Universidad:</label>
                    <div class="col-md-7">
                        <asp:dropdownlist CssClass="form-control" runat="server"  ID="ddl_universidad" AutoPostBack="true" OnSelectedIndexChanged="ddl_universidad_SelectedIndexChanged"/>
                    </div>
                </div>
            </div>
            <br />

            <!-- Facultad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Facultad:</label>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_facultad" OnSelectedIndexChanged="ddl_facultad_SelectedIndexChanged" />
                    </div>
                </div>
            </div>
            <br />

            <!-- Materia -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Materia:</label>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_materia" OnSelectedIndexChanged="ddl_materia_SelectedIndexChanged" AutoPostBack="true" />
                    </div>
                </div>
            </div>
            <br />

            <!-- Carrera -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Carrera:</label>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_carrera" OnSelectedIndexChanged="ddl_carrera_SelectedIndexChanged" AutoPostBack="true" />
                    </div>
                </div>
            </div>
            <br />
                <br /><br />
    
            <!-- Boton de busqueda-->
            <div class="row col-lg-offset-9 col-md-offset-9 col-md-offset-9 col-sm-offset-9">
              <asp:Button Text="Buscar" OnClick="btn_buscar_Click" ID="btn_consultar" CssClass="btn btn-lg btn_verde btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
            </div>
            <br />
            <br />

            
    <asp:GridView ID="dgv_grillaItem" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
        <Columns>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="precio" HeaderText="Precio" />
            <asp:BoundField DataField="stock" HeaderText="Stock" />
            <asp:BoundField DataField="carrera" HeaderText="Carrera" />
            <asp:BoundField DataField="materia" HeaderText="Materia" />
            <asp:BoundField DataField="editorial" HeaderText="Editorial" />
            <asp:BoundField DataField="profesor" HeaderText="Profesor" />
            <asp:BoundField DataField="tipoApunte" HeaderText="Tipo Apunte" />
            <asp:ButtonField Text="Modificar" CommandName="select" />
            <asp:ButtonField Text="Eliminar" CommandName="delete" />
        </Columns>
    </asp:GridView>

            </div>
        </div>
     </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
