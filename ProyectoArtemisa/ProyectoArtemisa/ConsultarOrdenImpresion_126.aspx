<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarOrdenImpresion_126.aspx.cs" Inherits="ProyectoArtemisa.ConsultarOrdenImpresion_126" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
     <div class="form-group">
 
         <!-- Titulo -->
         <div class="row">
                <h1 class="text-primary text-center"><b>Ordenes de Impresion</b></h1>
            </div>
         <br />

         <!-- Grilla Ordenes de Impresion-->
         <asp:GridView ID="dgv_grillaOrdenesImpresion" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true" OnRowDeleting="btn_eliminarOrden_RowDeleting" OnSelectedIndexChanged="btn_consultarApunte_SelectedIndexChanged">
             <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#ffffcc" />
             <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
             <Columns>
                 <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                 <asp:BoundField DataField="cantidad" HeaderText="Cantidad"  ApplyFormatInEditMode="False" />

                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_consultarApunte" CommandName="select" runat="server"><span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span></asp:LinkButton>
                     </ItemTemplate>
                     <ControlStyle Width="10px" />
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>

                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton ID="btn_eliminarOrden" CommandName="delete" runat="server"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                     </ItemTemplate>
                     <ControlStyle Width="10px" />
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:TemplateField>

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

         <!-- Boton agregar Apunte-->
         <div class="row col-lg-offset-9 col-md-offset-9 col-md-offset-9 col-sm-offset-9">
              <asp:Button Text="Agregar" OnClick="btn_agregar_Click" ID="btn_agregar" CssClass="btn btn-lg btn_verde btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
         </div>
         <br />

     </div>
    </div>
    <br />
    <br />

</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
