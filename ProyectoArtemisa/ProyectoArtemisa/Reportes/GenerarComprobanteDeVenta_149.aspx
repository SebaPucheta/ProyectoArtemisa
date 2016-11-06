<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="GenerarComprobanteDeVenta_149.aspx.cs" Inherits="ProyectoArtemisa.Reportes.GenerarComprobanteDeVenta_149" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="row">
        <div class="container col-lg-offset-3 col-lg-7" id="div_form">

            <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Reporte comprobante de venta</b></h1>
            </div>
            <br />
            <%-- Id de la factura --%>
            <div class="row">
                <div class="form-group">
                    <label for="documento" class="control-label col-md-2">Número comprobante: </label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" placeholder="número" class="form-control" type="text" ID="txt_idFactura" value="" ViewStateMode="Enabled" />
                    </div>
                </div>

                <br />
            </div>
            <%-- Boton generar --%>
            <div>
                <asp:Button Text="Generar" runat="server" ID="btn_generar" OnClick="btn_generar_Click" CssClass="btn btn-primary btn_flat"/>
            </div>
            <br /> 
            
            <div>
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            </div> 
            <div>
               <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="600px" Width="90%" ShowPrintButton="true"></rsweb:ReportViewer>
            </div>
            
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
