<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarPrecioPorHoja_77.aspx.cs" Inherits="ProyectoArtemisa.ConsultarPrecioPorHoja_77" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">

    <div class="container col-lg-offset-5 col-lg-3" id="div_form">
     <div class="form-group">
        
         <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Precio Por Hoja</b></h1>
            </div>
            <br />

         <div class="row">
             <div class ="col-lg-offset-2 col-lg-8">
         <asp:GridView ID="dgv_grillaPrecio" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
        <Columns>
            <asp:BoundField DataField="precioHoja" HeaderText="Precio" />
            <asp:BoundField DataField="fecha" HeaderText="Fecha" />
        </Columns>
    </asp:GridView>
</div>
         </div>

         </div>
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
