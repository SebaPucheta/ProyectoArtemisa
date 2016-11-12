<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="ProyectoArtemisa.Login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>

    <title></title>
     <link rel="stylesheet" href="Estilo/Login.css" />
    <link href='https://fonts.googleapis.com/css?family=Raleway:200' rel='stylesheet' type='text/css' />
    
</head>
<body>
    <form id="form1" runat="server" name="formulario">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
           <div class="contenedor-formulario">
		<div class="wrap">
			   <div  class="formulario" name="formulario_registro" method="get">
                 <!-- Titulo -->
                <div>
                    <h1 class="text-primary text-center"><b>Inicio Sesión</b></h1>
                </div>
                <br />
                <%-- Login --%>
                
                    
                   <asp:Login id="log_in" runat="server" OnAuthenticate="Login1_Authenticate" LoginButtonText="Ingresar" PasswordLabelText="Contraseña" TextLayout="TextOnTop" TitleText=""  UserNameLabelText="Nombre de usuario">
                        <TextBoxStyle  />
                        <LayoutTemplate>

                            <div class="input-group">
                               <asp:TextBox id="UserName" runat="server" Name="usuario" type="text" CssClass="txt"></asp:TextBox>
                                <label  class="label" id="UserNameLabel"   AssociatedControlID="UserName">Usuario</label>
                               <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="log_in">*</asp:RequiredFieldValidator>
                               
                            </div>
                            <div class="input-group">
                                <asp:TextBox id="Password" runat="server" Name="pass" type="text" CssClass="txt" TextMode="Password"></asp:TextBox>
                                <label  class="label" id="PasswordLabel"  AssociatedControlID="Password">Contraseña</label>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="log_in">*</asp:RequiredFieldValidator>
                                
                            </div>  
                                                  <asp:CheckBox ID="RememberMe" runat="server" Text="Recordármelo la próxima vez." />
                                               
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                              
                            <asp:Button ID="LoginButton" runat="server"  type="submit" CommandName="Login" CssClass="btn-enviar" Text="Ingresar" ValidationGroup="log_in" />
                                      
                           
                        </LayoutTemplate>
                        <LoginButtonStyle  />
                    </asp:Login>
                    <br />
                   </div>
              </div>      
         </div>
    </form>
    
    <script type="text/javascript">
            // Recorrer los elementos y hacer que onchange ejecute una funcion para comprobar el valor de ese input
            (function () {

                var formulario = document.formulario_registro;
                var elementos = document.documentElement;
                
                // Funcion que se ejecuta cuando el evento click es activado

                var validarInputs = function () {
                    for (var i = 0; i < elementos.length; i++) {
                        // Identificamos si el elemento es de tipo texto, email, password, radio o checkbox
                        if (elementos[i].type == "text" || elementos[i].type == "email" || elementos[i].type == "password") {
                            // Si es tipo texto, email o password vamos a comprobar que esten completados los input
                            if (elementos[i].value.length == 0) {
                                console.log('El campo ' + elementos[i].name + ' esta incompleto');
                                elementos[i].className = elementos[i].className + " error";
                                return false;
                            } else {
                                elementos[i].className = elementos[i].className.replace(" error", "");
                            }
                        }
                    }

                    // Comprobando que las contraseñas coincidan
                    if (elementos.pass.value !== elementos.pass2.value) {
                        elementos.pass.value = "";
                        elementos.pass2.value = "";
                        elementos.pass.className = elementos.pass.className + " error";
                        elementos.pass2.className = elementos.pass2.className + " error";
                    } else {
                        elementos.pass.className = elementos.pass.className.replace(" error", "");
                        elementos.pass2.className = elementos.pass2.className.replace(" error", "");
                    }

                    return true;
                };

                //var validarRadios = function () {
                //    var opciones = document.getElementsByName('sexo'),
                //      resultado = false;

                //    for (var i = 0; i < elementos.length; i++) {
                //        if (elementos[i].type == "radio" && elementos[i].name == "sexo") {
                //            // Recorremos los radio button
                //            for (var o = 0; o < opciones.length; o++) {
                //                if (opciones[o].checked) {
                //                    resultado = true;
                //                    break;
                //                }
                //            }

                //            if (resultado == false) {
                //                elementos[i].parentNode.className = elementos[i].parentNode.className + " error";
                //                console.log('El campo sexo esta incompleto');
                //                return false;
                //            } else {
                //                // Eliminamos la clase Error del radio button
                //                elementos[i].parentNode.className = elementos[i].parentNode.className.replace(" error", "");
                //                return true;
                //            }
                //        }
                //    }
                //};

                //var validarCheckbox = function () {
                //    var opciones = document.getElementsByName('terminos'),
                //      resultado = false;

                //    for (var i = 0; i < elementos.length; i++) {
                //        if (elementos[i].type == "checkbox") {
                //            for (var o = 0; o < opciones.length; o++) {
                //                if (opciones[o].checked) {
                //                    resultado = true;
                //                    break;
                //                }
                //            }

                //            if (resultado == false) {
                //                elementos[i].parentNode.className = elementos[i].parentNode.className + " error";
                //                console.log('El campo checkbox esta incompleto');
                //                return false;
                //            } else {
                //                // Eliminamos la clase Error del checkbox
                //                elementos[i].parentNode.className = elementos[i].parentNode.className.replace(" error", "");
                //                return true;
                //            }
                //        }
                //    }
                //};

                var enviar = function (e) {
                    if (!validarInputs()) {
                        console.log('Falto validar los Input');
                        e.preventDefault();
                    //} else if (!validarRadios()) {
                    //    console.log('Falto validar los Radio Button');
                    //    e.preventDefault();
                    //} else if (!validarCheckbox()) {
                    //    console.log('Falto validar Checkbox');
                    //    e.preventDefault();
                    } else {
                        console.log('Envia');
                        //e.preventDefault();
                    }
                };

                var focusInput = function () {
                    this.parentElement.children[1].className = "label active";
                    this.parentElement.children[0].className = this.parentElement.children[0].className.replace("error", "");
                };

                var blurInput = function () {
                    if (this.value <= 0) {
                        this.parentElement.children[1].className = "label";
                        this.parentElement.children[0].className = this.parentElement.children[0].className + " error";
                    }
                };

                // --- Eventos ---
                document.addEventListener("submit", enviar);
                
                
            }());

        </script>
</body>
</html>
