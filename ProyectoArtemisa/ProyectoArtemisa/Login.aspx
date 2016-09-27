<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoArtemisa.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title></title>
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Bootstrap/css/bootstrap-theme.min.css" />
    <link rel="stylesheet" href="Estilo/NavBar.css" />
    <link rel="stylesheet" href="Estilo/Sidebar.css" />
    <link rel="stylesheet" href="Estilo/Login.css" />
    <!-- Una fuente sacada de google que obviamente solo anda con internet, futuro problemaa solucionar-->
    <link href='https://fonts.googleapis.com/css?family=Raleway:200' rel='stylesheet' type='text/css' />
    <%-- Aca vamos a poner lo necesario para que funcione JQUERY Autor: Martin --%>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="row">
            <div class="container col-lg-offset-3 col-lg-6" id="login">
                <!-- Titulo -->
                <div>
                    <h1 class="text-primary text-center"><b>Inicio Sesión</b></h1>
                </div>
                <br />
                <%-- Login --%>
                
                    <asp:Login ID="log_in" runat="server" OnAuthenticate="Login1_Authenticate" LoginButtonText="Ingresar" PasswordLabelText="Contraseña" TextLayout="TextOnTop" TitleText="" Width="717px" UserNameLabelText="Nombre de usuario">
                        <TextBoxStyle CssClass="form-control txtboxs" />
                        <LoginButtonStyle CssClass="btn btn-lg btn_azul btn_flat" />
                    </asp:Login>
                    <br />
                    
            </div>
        </div>
    </form>


    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <script src="Bootstrap/js/jquery.js"></script>
    <%-- Aca vamos a poner lo necesario para que funcione JQUERY Autor: Martin --%>
    <script src="jquery-ui-1.11.4.custom\external\jquery\jquery.js"></script>
    <script src="jquery-ui-1.11.4.custom\jquery-ui.js"></script>

    <!-- Codigo js para que ande el boton btn-mostrarNav -->
    <script type="text/javascript">$('#btn_mostrarNav').on('click', function () {
    $('#sidenav').toggleClass('mostrar');
})</script>

</body>
</html>
