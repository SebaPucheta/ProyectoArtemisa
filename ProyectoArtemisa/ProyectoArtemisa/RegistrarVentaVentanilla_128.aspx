<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarVentaVentanilla_128.aspx.cs" Inherits="ProyectoArtemisa.RegistrarVentaVentanilla_128" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
     <div class="form-group">
        
         <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Registrar Factura</b></h1>
            </div>
            <br />
    
         <!-- Fecha -->
         <div class="row">
             <div class="form-group">
                 <label for="documento" class="control-label col-md-2">Fecha:</label>
                 <div class="col-md-2">
                     <asp:TextBox runat="server" class="form-control" TextMode="Date" type="text" ID="txt_fecha" value="" ViewStateMode="Enabled" />
                 </div>
             </div>
         </div>
         <br />

         <!-- Boton agregar Apunte-->
         <div class="row ">
              <asp:Button Text="Agregar" OnClick="btn_agregar_Click" ID="btn_agregar" CssClass="btn btn-lg btn_verde btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
         </div>
         <br />

         <!-- Grilla Detalle de factura-->
         <asp:GridView ID="dgv_grillaDetalleFactura" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true">
             <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#ffffcc" />
             <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
             <Columns>
                 <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                 <asp:BoundField DataField="cantidad" HeaderText="Cantidad"  ApplyFormatInEditMode="False" />
                 <asp:BoundField DataField="subtotal" HeaderText="Subtotal"  ApplyFormatInEditMode="False" />
             </Columns>
         </asp:GridView>

         <!-- Total -->
         <div class="row">
             <div class="form-group">
                 <label for="documento" class="control-label col-md-1">Total : </label>
                 <div class="col-md-2">
                     <asp:TextBox runat="server" class="form-control" type="text" ID="txt_total" value="" ViewStateMode="Enabled" />
                 </div>
             </div>
         </div>
         <br />

         <!-- Botones -->
            <div class="row col-lg-offset-8">
                <asp:Button runat="server" ID="btn_confirmar" Text="Confirmar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" OnClick="btn_confirmar_Click" />
                <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_cancelar_Click" />
            </div>
            <br />

                 
         </div>
        </div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
