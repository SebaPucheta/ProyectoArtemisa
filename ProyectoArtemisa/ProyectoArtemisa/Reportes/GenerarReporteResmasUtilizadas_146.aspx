﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="GenerarReporteResmasUtilizadas_146.aspx.cs" Inherits="ProyectoArtemisa.Reportes.GenerarReporteResmasUtilizadas_146" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="row">
        <div class="container col-lg-offset-3 col-lg-7" id="div_form">

            <!-- Titulo -->
            <div class="row">
                <h1 class="text-primary text-center"><b>Reporte de resmas utilizadas</b></h1>
            </div>
            <br />
            <!-- Fecha desde y hasta  -->
            <div class="row">
                <div class="form-group">
                    <label for="documento" class="control-label col-md-2">Fecha desde: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" placeholder="dd/mm/aaaa" class="form-control" type="text" ID="txt_fechaDesde" value="" ViewStateMode="Enabled" />
                        </div>
                    <label for="documento" class="control-label col-md-2">Fecha hasta: </label>
                    <div class="col-md-2">                        
                        <asp:TextBox runat="server" placeholder="dd/mm/aaaa" class="form-control" type="text" ID="txt_fechaHasta" value="" ViewStateMode="Enabled" />
                    </div>
                </div>
            </div>
            <br />

            <div>
                <asp:Button Text="Generar" runat="server" ID="btn_generar" OnClick="btn_generar_Click" CssClass="btn btn-primary btn_flat" />  
                </div>
            <br />
            <%-- Script manager, se necesita para que funcione el report viewer --%>
            <div>
                <asp:ScriptManager runat="server" ID="ScriptManager1" />
                
            </div>
            <%-- Reporte --%>
            <div>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="600px" Width="90%" CssClass="center-block"></rsweb:ReportViewer>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>