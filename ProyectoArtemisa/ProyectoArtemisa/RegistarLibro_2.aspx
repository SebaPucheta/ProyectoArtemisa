<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RegistarLibro_2.aspx.cs" Inherits="ProyectoArtemisa.RegistarLibro_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_encabezado" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_cuerpo" runat="server">
    <!-- -->
    <!--Cuerpo del form-->
    <div id="div_libro" class="container col-lg-offset-2 col-lg-7">
        <br />
        <br />
        <br />
        <br />
        <!--Nombre del libro -->
        <div>
            <asp:Label ID="lbl_nombreLibro" runat="server" Text="Nombre del libro: "></asp:Label>
            <asp:TextBox ID="txt_nombreDelLibro" runat="server"></asp:TextBox>
        </div>
        <!--Universidad -->
        <div>
            <asp:Label ID="lbl_universidad" runat="server" Text="Universidad: "></asp:Label>
            <asp:DropDownList ID="ddl_universidadesLibro" runat="server"></asp:DropDownList>
            <asp:Button ID="btn_registrarUniversidadLibro" runat="server" Text="Registrar" />
        </div>

        <!--Facultad -->
        <div>
            <asp:Label ID="lbl_facultades" runat="server" Text="Facultad: "></asp:Label>
            <asp:DropDownList ID="ddl_facultadesLibro" runat="server"></asp:DropDownList>
            <asp:Button ID="btn_registrarFacultadesLibro" runat="server" Text="Registrar" />
        </div>
        <!--Materia -->
        <div>
            <asp:Label ID="lbl_materias" runat="server" Text="Materia: "></asp:Label>
            <asp:DropDownList ID="ddl_materiasLibro" runat="server"></asp:DropDownList>
            <asp:Button ID="btn_registrarMateriasLibro" runat="server" Text="Registrar" />
        </div>
        <!--Carrera -->
        <div>
            <asp:Label ID="lbl_carreras" runat="server" Text="Carreras: "></asp:Label>
            <br />
            <asp:GridView ID="dgv_carrerasLibro" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="idCarrera" HeaderText="Carreras" />
                </Columns>
            </asp:GridView>
        </div>
        <!--Nombre autor -->
        <div>
            <asp:Label ID="lbl_nombreAutor" runat="server" Text="Nombre del autor: "></asp:Label>
            <asp:TextBox ID="txt_nombreAutorLibro" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbl_editorial" runat="server" Text="Editorial: "></asp:Label>
            <asp:DropDownList ID="ddl_editorialLibro" runat="server"></asp:DropDownList>
            <asp:Button ID="btn_registrarEditorialLibro" runat="server" Text="Registrar" />
        </div>
        <!--Cantidad hojas -->
        <div>
            <asp:Label ID="lbl_cantidadHojas" runat="server" Text="Cantidad de hojas: "></asp:Label>
            <asp:TextBox ID="lbl_cantidadHojasLibro" runat="server"></asp:TextBox>
        </div>
        <!--Descripcion -->
        <div>
            <asp:Label ID="lbl_descripcion" runat="server" Text="Descripcion: "></asp:Label>
            <br />
            <asp:TextBox ID="txt_descripcionLibro" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <!--Precio Libro -->
        <div>
            <asp:Label ID="lbl_precioLibro" runat="server" Text="Precio Libro: "></asp:Label>
            <asp:TextBox ID="txt_precioLibro" runat="server"></asp:TextBox>
        </div>
        <!--Boton confirmar -->
        <div>
            <asp:Button ID="btn_confirmar" runat="server" Text="Confirmar" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_pie" runat="server">
</asp:Content>
