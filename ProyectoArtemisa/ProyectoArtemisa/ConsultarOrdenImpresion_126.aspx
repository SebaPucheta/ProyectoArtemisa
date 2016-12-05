<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarOrdenImpresion_126.aspx.cs" Inherits="ProyectoArtemisa.ConsultarOrdenImpresion_126" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
     <div class="form-group">
 
         <!-- Titulo -->
         <div class="row">
                <h1 class="text-primary text-center"><b>
                    <asp:Label ID="lbl_tituloCabecera" runat="server" Text="Registrar orden de impresión"></asp:Label></b></h1>
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

        
         <!--Grilla Nueva Orden de Impresion-->
         <asp:GridView ID="dgv_ordenNueva" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="false" OnRowDeleting="btn_limpiarGrilla_RowDeleting" OnSelectedIndexChanged="btn_registrarOrden_SelectedIndexChanged" >
             <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#ffffcc" />
             <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
             <Columns>
                 <asp:BoundField DataField="nombreApunte" HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                 <asp:TemplateField HeaderText="Cantidad" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                     <ItemTemplate>
                        <asp:TextBox ID="txt_cantidadImprimir" runat="server" HeaderText="Cantidad" Width="40px"></asp:TextBox>
                     </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
                 <asp:TemplateField >
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_registrarOrden" CommandName="select" runat="server" Text="Registrar"></asp:LinkButton>
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
          <br />

          <!-- Subtitulo de grilla -->
            <div class="row">
                <div class="form-group">
                    <asp:label runat="server" ID="lbl_nombreGrilla" Visible="false" for="cuil" class="control-label col-md-5"><b>Lista de órdenes de impresión</b></asp:label>
                </div>
            </div>
         <!-- Grilla Ordenes de Impresion-->
         <asp:GridView ID="dgv_grillaOrdenesImpresion" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true" OnRowDeleting="btn_eliminarOrden_RowDeleting" OnSelectedIndexChanged="btn_consultarApunte_SelectedIndexChanged" OnRowCommand="dgv_grillaApunte_RowCommand">
             <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#ffffcc" />
             <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
             <Columns>
                 <asp:BoundField DataField="fecha" HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                 <asp:BoundField DataField="nombre" HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                 <asp:BoundField DataField="cantidad" HeaderText="Cantidad"   ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                 <asp:TemplateField HeaderText="Consular">
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_consultarApunte" CommandName="select" runat="server"  ><span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span></asp:LinkButton>
                     </ItemTemplate>
                     <ControlStyle Width="10px" />
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
                 
                 <asp:CheckBoxField DataField="chk_impreso"  HeaderText="Impreso" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                 
                 <asp:TemplateField HeaderText="Eliminar">
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_eliminarOrden" CommandName="delete" runat="server"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                     </ItemTemplate>
                     <ControlStyle Width="10px" />
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Estado" >
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_impreso" CommandName="impreso" runat="server" Text="Impreso"></asp:LinkButton>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Ubicación">
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_enLocal" CommandName="enLocal" runat="server" Text="En Local"></asp:LinkButton>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>
         <br />

         <!-- Boton agregar Apunte-->
         <div class="row col-lg-offset-9 col-md-offset-9 col-md-offset-9 col-sm-offset-9">
              <asp:Button Text="Agregar" OnClick="btn_agregar_Click" ID="btn_agregar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
         </div>
         <br />

     </div>
    </div>
    <br />
    <br />


    


</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">

   

</asp:Content>
