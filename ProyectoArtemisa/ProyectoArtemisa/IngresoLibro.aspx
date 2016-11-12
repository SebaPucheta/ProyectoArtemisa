<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="IngresoLibro.aspx.cs" Inherits="ProyectoArtemisa.IngresoLibro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
     
        
         <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Registrar Ingreso Libro</b></h1>
            </div>
            <br />
    
         <!-- Fecha -->
         <div class="row">
             <div class="form-group">
                 <label for="documento" class="control-label col-md-2">Fecha: </label>
                 <div class="col-md-3">
                     <asp:label runat="server" type="text" ID="lbl_fecha" value=""  />
                 </div>
             </div>
         </div>
         <br />
        
         <!-- Usuario -->
         <div class="row">
             <div class="form-group">
                 <label for="documento" class="control-label col-md-2">Usuario: </label>
                 <div class="col-md-3">
                     <asp:Label runat="server" type="text" ID="lbl_usuario" value=""  />
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

        <!-- Codigo de barra del Item -->
        <div class="row">
            <div class="form-group">
                <label for="nombre" class="control-label col-md-3">Código de barra: </label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" class="form-control" type="text" ID="btn_codigoBarra" value="" ViewStateMode="Enabled" OnTextChanged="btn_codigoBarra_TextChanged" AutoPostBack="true" />
                </div>
            </div>
        </div>
        <br />
        
        <br />

          <!--Grilla que tiene un nuevo detalle-->
         <asp:GridView ID="dgv_nuevoIngresoStockDetalle" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="false" OnRowDeleting="btn_limpiarGrilla_RowDeleting" OnSelectedIndexChanged="btn_agregarDetalle_SelectedIndexChanged" >
             <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#ffffcc" />
             <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
             <Columns>
                 <asp:BoundField DataField="nombreLibro" HeaderText="Nombre" />
                 <asp:TemplateField HeaderText="Precio Unit." HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                     <ItemTemplate>
                        <asp:TextBox ID="txt_precioUnitario" runat="server"  Width="60px"></asp:TextBox>
                     </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Cantidad" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                     <ItemTemplate>
                        <asp:TextBox ID="txt_cantidad" runat="server"  Width="40px"></asp:TextBox>
                     </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_agregarDetalle" CommandName="select" runat="server" Text="Registrar"></asp:LinkButton>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_limpiar" CommandName="delete" runat="server" Text="Limpiar"></asp:LinkButton>
                     </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
                 
             </Columns>
          </asp:GridView>
         <asp:Label runat="server" ID="lbl_info" ForeColor="Red"></asp:Label>
          <br />

         <!-- Boton agregar Apunte-->
         <div class="row">
              <asp:Button Text="Agregar" OnClick="btn_agregar_Click" ID="btn_agregar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
         </div>
         <br />

         <!-- Grilla Detalle de factura-->
         <asp:GridView ID="dgv_grillaIngresoStockDetalle" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true"  AllowPaging="True" PageSize="20"
            OnPageIndexChanging="dgv_grilla_OnPageIndexChanging" OnRowDeleting="btn_eliminarDetalle_RowDeleting" OnSelectedIndexChanged="btn_consultarApunte_SelectedIndexChanged">
             <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#ffffcc" />
             <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
             <Columns>
                 <asp:BoundField DataField="nombreLibro" HeaderText="Nombre" />
                 <asp:BoundField DataField="precioUnitario" HeaderText="Precio U."  ApplyFormatInEditMode="False" />
                 <asp:BoundField DataField="cantidad" HeaderText="Cantidad"  ApplyFormatInEditMode="False" />
                 <asp:BoundField DataField="subtotal" HeaderText="Subtotal"  ApplyFormatInEditMode="False" />
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_consultarApunte" CommandName="select" runat="server"  ><span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span></asp:LinkButton>
                     </ItemTemplate>
                     <ControlStyle Width="10px" />
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_eliminarDetalle" CommandName="delete" runat="server"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                     </ItemTemplate>
                     <ControlStyle Width="10px" />
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>

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

         <!-- Botones -->
            <div class="row col-lg-offset-8">
                <asp:Button runat="server" ID="btn_confirmar" Text="Confirmar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" OnClick="btn_confirmar_Click" />
                <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn-lg btn_rojo btn_flat" OnClick="btn_cancelar_Click" />
            </div>
            <br />

                 
         
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
