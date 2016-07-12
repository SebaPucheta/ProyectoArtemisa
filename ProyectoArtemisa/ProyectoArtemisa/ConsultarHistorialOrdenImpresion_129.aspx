﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarHistorialOrdenImpresion_129.aspx.cs" Inherits="ProyectoArtemisa.ConsultarHistorialOrdenImpresion_129" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">

    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
     <div class="form-group">
 
         <!-- Titulo -->
         <div class="row">
                <h1 class="text-primary text-center"><b>Historial de Ordenes de Impresion</b></h1>
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
         
          <!-- Grilla Ordenes de Impresion-->
         <asp:GridView ID="dgv_grillaOrdenesImpresion" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true" >
             <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#ffffcc" />
             <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
             <Columns>
                 <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                 <asp:BoundField DataField="cantidad" HeaderText="Cantidad"  ApplyFormatInEditMode="False" />
                 <asp:BoundField DataField="fecha" HeaderText="Fecha" />

                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" HeaderText="Impreso">
                     <ItemTemplate>
                         <asp:CheckBox ID="chk_impreso" runat="server" DataField="df_chk_impreso" EnableViewState="true" />
                     </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" HeaderText="En local">
                     <ItemTemplate>
                         <asp:CheckBox ID="chk_enLocal" runat="server" DataField="df_chk_enLocal" EnableViewState="true"  />
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>
         <br />

        <br />
        <br />
        </div>
       </div>


</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>