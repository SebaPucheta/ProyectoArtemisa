<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarHistorialFactura_130.aspx.cs" Inherits="ProyectoArtemisa.ConsultarHistorialFactura_130" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">

    <div class="container col-lg-offset-3 col-lg-7" id="div_form">
       

            <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Historial de Ventas</b></h1>
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
            <%-- Autor: Martin --%>
            <div class="container col-lg-offset-10">
                <asp:Button runat="server" ID="btn_buscar" Text="Buscar" CssClass="btn btn-lg btn_azul btn_flat" Enabled="true" OnClick="btn_buscar_Click" />
            </div>
            <br />
            <br />


            <!-- Grilla Facturas-->
            <asp:GridView ID="dgv_grillaOrdenesImpresion" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
            OnPageIndexChanging="dgv_grilla_OnPageIndexChanging" OnSelectedIndexChanged="btn_consultarFactura_SelectedIndexChanged">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#ffffcc" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <Columns>
                    <asp:BoundField DataField="idFactura" ItemStyle-HorizontalAlign="Center" HeaderText="Nº" />
                    <asp:BoundField DataField="fecha" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha" />
                    <asp:BoundField DataField="nombreCompletoEmpleado" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre Empleado" />
                    <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-HorizontalAlign="Right" ApplyFormatInEditMode="False" />
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
             <div class="container form-group col-lg-offset-7">
                 <label for="documento" ID="lbl_total"  class="control-label col-md-1">Total: </label>
                 <div class="col-md-1">
                     <div class="input-group">
                      <div class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></div>
                     <asp:Label   runat="server" CssClass="form-control"  type="text" ID="txt_total"  />
                 </div>
               </div>
             </div>
         </div>
         <br />
            <br />

            <br />
            <br />
        
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
