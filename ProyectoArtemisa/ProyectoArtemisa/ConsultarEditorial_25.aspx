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
                    
    <asp:GridView ID="dgv_grillaEditorial" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" >
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
        <Columns>
            <asp:BoundField DataField="idEditorial" HeaderText="Número" />
            <asp:BoundField DataField="nombreEditorial" HeaderText="Nombre" />

        </Columns>
    </asp:GridView>

            </div>
     </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
