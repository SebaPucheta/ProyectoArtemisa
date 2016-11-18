<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConsultarLibroApunte.aspx.cs" Inherits="ProyectoArtemisa.ConsultarLibroApunte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <div class="container col-lg-offset-3 col-lg-7" id="div_form">


        <!-- Titulo -->
        <div class="row">
            <h1 class="text-primary text-center"><b>Consultar Libros y Apuntes</b></h1>
        </div>
        <br />

        <!-- Codigo de barra del Item -->
        <div class="row">
            <div class="form-group">
                <label for="nombre" class="control-label col-md-3">Código de barra: </label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" class="form-control" type="text" ID="btn_codigoBarra" value="" ViewStateMode="Enabled" OnTextChanged="btn_codigoBarra_TextChanged" AutoPostBack="true" />
                </div>
            </div>
        </div>
        <br />

        <!-- Tipo de Item-->
        <div class="row">
            <div class="form-group">
                <label for="option" class="control-label col-md-3">Tipo Ítem: </label>
                <div class="col-md-4">
                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_tipoItem" AutoPostBack="true" OnSelectedIndexChanged="ddl_tipoItem_SelectedIndexChanged" />
                </div>
            </div>
            <br />
            <br />

            <!--Tipo de apunte -->
            <div class="row">
                <div class="form-group">
                    <asp:Label runat="server" ID="lbl_tipoApunte" Visible="false" for="option" class="control-label col-md-3"><strong>Tipo de Apunte: </strong></asp:Label>
                    <div class=" col-md-5">
                        <div class="col-md-4">
                            <asp:Label runat="server" ID="lbl_apunteDigital" Visible="false" class="checkbox-inline">
                                <asp:CheckBox runat="server" type="checkbox" name="" ID="chk_apunteDigital" /><strong>Digital</strong></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:Label runat="server" ID="lbl_apunteImpreso" Visible="false" class="checkbox-inline">
                                <asp:CheckBox runat="server" type="checkbox" name="" ID="chk_apunteImpreso" /><strong>Impreso</strong></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <br />

            <!-- Nombre del Item -->
            <div class="row">
                <div class="form-group">
                    <label for="nombre" class="control-label col-md-3">Nombre del Ítem: </label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" class="form-control" type="text" ID="txt_nombreItem" value="" ViewStateMode="Enabled" />
                    </div>
                </div>
            </div>
            <br />

            <!-- Universidad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Universidad: </label>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_universidad" AutoPostBack="true" OnSelectedIndexChanged="ddl_universidad_SelectedIndexChanged" />
                    </div>
                </div>
            </div>
            <br />

            <!-- Facultad -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Facultad: </label>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" runat="server" AutoPostBack="true" ID="ddl_facultad" OnSelectedIndexChanged="ddl_facultad_SelectedIndexChanged" />
                    </div>
                </div>
            </div>
            <br />

            <!-- Materia -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Materia: </label>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_materia" OnSelectedIndexChanged="ddl_materia_SelectedIndexChanged" AutoPostBack="true" />
                    </div>
                </div>
            </div>
            <br />

            <!-- Carrera -->
            <div class="row">
                <div class="form-group">
                    <label for="option" class="control-label col-md-3">Carrera: </label>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_carrera" OnSelectedIndexChanged="ddl_carrera_SelectedIndexChanged" AutoPostBack="true" />
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />

            <!-- Boton de busqueda-->
            <div class="row col-lg-offset-9 col-md-offset-9 col-md-offset-9 col-sm-offset-9">
                <asp:Button Text="Buscar" OnClick="btn_buscar_Click" ID="btn_consultar" CssClass="btn btn-lg btn_azul btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
                <asp:Button Text="Salir" OnClick="btn_salir_Click" ID="btn_salir" CssClass="btn btn-lg btn_rojo btn_flat" ValidationGroup="AllValidator" Enabled="true" runat="server" />
            </div>
            <br />
            <br />

            <!-- Grilla Apunte-->
            <div class="col-lg-12">
            <asp:GridView ID="dgv_grillaApunte" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"  AllowPaging="True" PageSize="20"
            OnPageIndexChanging="dgv_grillaApunte_OnPageIndexChanging" OnRowDeleting="btn_eliminarApunte_RowDeleting" OnSelectedIndexChanged="btn_modificarApunte_SelectedIndexChanged" OnRowCommand="dgv_grillaApunte_RowCommand">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#ffffcc" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <Columns>
                    <asp:BoundField DataField="nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre"  />
                    <asp:BoundField DataField="precio" ItemStyle-HorizontalAlign="Right" HeaderText="Precio" />
                    <asp:BoundField DataField="stock" ItemStyle-HorizontalAlign="Center" HeaderText="Stock" />
                    <asp:BoundField DataField="carrera" ItemStyle-HorizontalAlign="Center" HeaderText="Carrera">
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="materia" HeaderText="Materia">
                        <ItemStyle  VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="editorial" ItemStyle-HorizontalAlign="Center" HeaderText="Editorial" />
                    <asp:BoundField DataField="profesor" ItemStyle-HorizontalAlign="Center" HeaderText="Profesor" />
                    <asp:BoundField DataField="tipoApunte" ItemStyle-HorizontalAlign="Center" HeaderText="Tipo Apunte" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_imprimirApunte" CommandName="imprimir" runat="server"><span class="glyphicon glyphicon-circle-arrow-down" aria-hidden="true"></span></asp:LinkButton>

                        </ItemTemplate>
                        <ControlStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_modificarApunte" CommandName="select" runat="server"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>

                        </ItemTemplate>
                        <ControlStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_eliminarApunte" CommandName="delete" runat="server"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>

            <!-- Grilla Libro-->
            <div class="col-lg-12">
            <asp:GridView ID="dgv_grillaLibro" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Visible="true"  AllowPaging="True" PageSize="20"
                OnPageIndexChanging="dgv_grillaLibro_OnPageIndexChanging"
                OnRowDeleting="btn_eliminarLibro_RowDeleting"
                OnSelectedIndexChanged="btn_modificarLibro_SelectedIndexChanged"
                OnRowCommand="dgv_grillaLibro_RowCommand">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#ffffcc" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <Columns>
                    <asp:BoundField DataField="nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" />
                    <asp:BoundField DataField="precio" ItemStyle-HorizontalAlign="Right" HeaderText="Precio" />
                    <asp:BoundField DataField="stock" ItemStyle-HorizontalAlign="Center" HeaderText="Stock" />
                    <asp:BoundField DataField="carrera" ItemStyle-HorizontalAlign="Center" HeaderText="Carrera" />
                    <asp:BoundField DataField="materia" ItemStyle-HorizontalAlign="Center" HeaderText="Materia" />
                    <asp:BoundField DataField="editorial" ItemStyle-HorizontalAlign="Center" HeaderText="Editorial" />
                    <asp:BoundField DataField="autor" ItemStyle-HorizontalAlign="Center" HeaderText="Autor" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_imprimirApunte" CommandName="imprimir" runat="server"><span class="glyphicon glyphicon-circle-arrow-down" aria-hidden="true"></span></asp:LinkButton>

                        </ItemTemplate>
                        <ControlStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_modificarLibro" CommandName="select" runat="server"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>

                        </ItemTemplate>
                        <ControlStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_eliminarLibro" CommandName="delete" runat="server"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">

    <script type="text/javascript">

        document.getElementById("btn_imprimirApunte").onclick = function () { CrearOrdenImpresion() };

        function CrearOrdenImpresion() {
            __doPostBack('CrearOrdenImpresion', elemento.value);
        }
    </script>
</asp:Content>
