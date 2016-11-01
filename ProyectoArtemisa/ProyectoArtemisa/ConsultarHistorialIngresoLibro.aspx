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
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Proveedor" HeaderText="Nº" />
                    <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="total" HeaderText="Total" ApplyFormatInEditMode="False" />
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_consultarIngresoLibro" CommandName="select" runat="server"><span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span></asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- Total -->
            <div class="row">
                <div class="form-group">
                    <div class="col-lg-10">
                        <div class="input-group">
                      <div class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></div>
                     <asp:Label Visible="false"   runat="server" CssClass="form-control"  type="text" ID="lbl_titulototal"  />
                        </div>
                        <div class="col-md-2">
                            <asp:Label runat="server" class="form-control" type="text" ID="txt_total" value="" ViewStateMode="Enabled" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
           <!-- Grilla Detalles Ingreso Libros-->
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnSelectedIndexChanged="btn_consultarFactura_SelectedIndexChanged">
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
         
        <!-- Total -->
            <div class="row">
                <div class="form-group">
                    <div class="col-lg-10">
                        <div class="input-group">
                      <div class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></div>
                     <asp:Label   runat="server" Visible="false" CssClass="form-control"  type="text" ID="lbl_titulosubtotal"  />
                        </div>
                        <div class="col-md-2">
                            <asp:Label runat="server" class="form-control" type="text" ID="lbl_subtotal" value="" ViewStateMode="Enabled" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
