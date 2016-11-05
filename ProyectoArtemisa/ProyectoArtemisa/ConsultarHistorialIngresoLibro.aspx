<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarHistorialIngresoLibro.aspx.cs" Inherits="ProyectoArtemisa.ConsultarHistorialIngresoLibro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
       

            <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Historial de Ingresos de Libros</b></h1>
            </div>
            <br />

            <!-- Fecha desde  -->
            <div class="row">
                <div class="form-group">
                    <label for="documento" class="control-label col-md-2">Fecha desde: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" placeholder="dd/mm/aaaa" class="form-control" type="text" ID="txt_fechaDesde" value="" ViewStateMode="Enabled" />
                    </div>
                </div>
            </div>
            <br />

            <!-- Fecha hasta  -->
            <div class="row">
                <div class="form-group">
                    <label for="documento" class="control-label col-md-2">Fecha hasta: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" placeholder="dd/mm/aaaa" class="form-control" type="text" ID="txt_fechaHasta" value="" ViewStateMode="Enabled" />
                    </div>
                </div>
            </div>
            <br />

        <!-- Proveedores -->
         <div class="row">
             <div class="form-group">
                 <label for="documento" class="control-label col-md-2">Proveedores: </label>
                 <div class="col-md-3">
                     <asp:DropDownList runat="server" type="text" ID="ddl_proveedores" CssClass="form-control" value=""  />
                 </div>
             </div>
         </div>
         <br />

         <!-- Usuario -->
         <div class="row">
             <div class="form-group">
                 <label for="documento" class="control-label col-md-2">Usuario: </label>
                 <div class="col-md-3">
                     <asp:TextBox CssClass="form-control" runat="server" type="text" ID="txt_usuario" value=""  />
                 </div>
             </div>
         </div>
         <br />
            <%-- Autor: Martin --%>
            <div class="col-lg-offset-9">
                <asp:Button runat="server" ID="btn_buscar" Text="Buscar" CssClass="btn btn_azul btn_flat" Enabled="true" OnClick="btn_buscar_Click" />
            </div>
            <br />
            <br />


            <!-- Grilla Ingreso Libros-->
            <asp:GridView ID="dgv_grillaIngresoLibros" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnSelectedIndexChanged="btn_consultarFactura_SelectedIndexChanged">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#ffffcc" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <Columns>
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"  DataField="fecha" HeaderText="Fecha" />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"  DataField="proveedor" HeaderText="Nº" />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"  DataField="usuario" HeaderText="Usuario" />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"  DataField="total" HeaderText="Total" ApplyFormatInEditMode="False" />
                     <asp:TemplateField HeaderText="Consultar">
                        <ItemTemplate >
                            <asp:LinkButton ID="btn_consultarIngresoLibro" CommandName="select" runat="server"><span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span></asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        <br />
            <!-- Total -->
         <div class="row">
             <div class="form-group">
                 <label for="documento"  class="control-label col-md-2">Total: </label>
                 <div class="col-md-2">
                     <div class="input-group">
                      <div class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></div>
                     <asp:Label   runat="server" CssClass="form-control"  type="text" ID="lbl_total"  />
                 </div>
               </div>
             </div>
         </div>
         <br />
           <!-- Grilla Detalles Ingreso Libros-->
            <asp:GridView ID="dgv_grillaDetalleIngresoLibro" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnSelectedIndexChanged="btn_consultarFactura_SelectedIndexChanged">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#ffffcc" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <Columns>
                    <asp:BoundField DataField="nombreLibro" HeaderText="Libro" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="precio" HeaderText="Precio Unit." />
                    <asp:BoundField DataField="total" HeaderText="Total" ApplyFormatInEditMode="False" />
                </Columns>
            </asp:GridView>
         
        
            
            <br />
           
        
    </div>
    <br />
            <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
      <%-- Son los JQUERY para los datapicker Autor: Martin--%>
    <script>
        $(function () {
            $("#<%= txt_fechaDesde.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val();
        });
    </script>
    <script>
        $(function () {
            $("#<%= txt_fechaHasta.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val();
        });
    </script>
</asp:Content>
