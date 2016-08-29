<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarHistorialFactura_130.aspx.cs" Inherits="ProyectoArtemisa.ConsultarHistorialFactura_130" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">

     <div class="container col-lg-offset-3 col-lg-7" id="div_form">
     <div class="form-group">
 
         <!-- Titulo -->
         <div class="row">
                <h1 class="text-primary text-center"><b>Historial de Ventas</b></h1>
         </div>
         <br />

         <!-- Fecha desde  -->
         <div class="row">
             <div class="form-group">
                 <label for="documento" class="control-label col-md-2">Fecha desde :</label>
                 <div class="col-md-2">
                     <asp:TextBox runat="server" class="form-control" TextMode="Date" type="text" ID="txt_fechaDesde" value="" ViewStateMode="Enabled" />
                 </div>
             </div>
         </div>
         <br />
            
         <!-- Fecha hasta  -->
         <div class="row">
             <div class="form-group">
                 <label for="documento" class="control-label col-md-2">Fecha hasta :</label>
                 <div class="col-md-2">
                     <asp:TextBox runat="server" class="form-control" TextMode="Date" type="text" ID="txt_fechaHasta" value="" ViewStateMode="Enabled" />
                 </div>
             </div>
         </div>
         <br />

         
          <!-- Grilla Facturas-->
         <asp:GridView ID="dgv_grillaOrdenesImpresion" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true" OnSelectedIndexChanged="btn_consultarFactura_SelectedIndexChanged" >
             <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#ffffcc" />
             <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
             <Columns>
                 <asp:BoundField DataField="numero" HeaderText="Nº" />
                 <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                 <asp:BoundField DataField="total" HeaderText="Total"  ApplyFormatInEditMode="False" />
                 <asp:BoundField DataField="tipoPago" HeaderText="Tipo de Pago"  ApplyFormatInEditMode="False" />

                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_consultarFactura" CommandName="select" runat="server"><span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span></asp:LinkButton>
                     </ItemTemplate>
                     <ControlStyle Width="10px" />
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>

         <!-- Total -->
         <div class="row">
             <div class="form-group">
                 <label for="documento" class="control-label col-md-1">Total : </label>
                 <div class="col-md-2">
                     <asp:Label runat="server" class="form-control" type="text" ID="lbl_total" value="" ViewStateMode="Enabled" />
                 </div>
             </div>
         </div>
         <br />

         <br />
         <br />
              </div>
         </div>

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
