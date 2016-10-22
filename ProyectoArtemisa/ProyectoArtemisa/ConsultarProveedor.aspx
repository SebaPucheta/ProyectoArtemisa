<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarProveedor.aspx.cs" Inherits="ProyectoArtemisa.ConsultarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-8" id="div_form">

        <!-- Titulo -->
        <div class="row">
            <h1 class="text-primary text-center"><b>Consultar Proveedor</b></h1>
        </div>
        <br />

        <!-- Grilla Proveedores-->
        <asp:GridView ID="dgv_grillaProveedores" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"
            AllowPaging="True" PageSize="5"
            OnPageIndexChanging="dgv_grillaProveedores_OnPageIndexChanging"
            OnSelectedIndexChanged="btn_modificarProveedor_SelectedIndexChanged"
            OnRowDeleting="dgv_grillaProveedores_OnRowDeleting">
            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#ffffcc" />
            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
            <Columns>
                <asp:BoundField DataField="nombreProveedor" HeaderText="Proveedor"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                <asp:BoundField DataField="telefonoProveedor" HeaderText="Teléfono" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                <asp:BoundField DataField="emailProveedor" HeaderText="e-mail" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                <asp:BoundField DataField="direccionProveedor" HeaderText="Dirección"/>
                <asp:BoundField DataField="nombreContactoProveedor" HeaderText="Nombre" />
                <asp:BoundField DataField="nombreCiudadEditorial" HeaderText="Ciudad" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                <asp:TemplateField HeaderText="Modificar">
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_modificarProveedor" CommandName="select" runat="server"><span class="glyphicon glyphicon-menu-down" aria-hidden="true"></span></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="10px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_eliminarProveedor" CommandName="delete" runat="server"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="10px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <!-- Grilla Editoriales -->
        <asp:GridView ID="dgv_grillaEditoriales" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#ffffcc" />
            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
            <Columns>
                <asp:BoundField DataField="nombreEditorial" HeaderText="Nombre" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
