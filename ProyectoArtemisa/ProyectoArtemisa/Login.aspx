<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoArtemisa.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title></title>
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Bootstrap/css/bootstrap-theme.min.css" />
    <link rel="stylesheet" href="Estilo/Login.css" />
    
</head>
<body>
    <form id="form1" runat="server">
       
        
        
        <div class="contenedor-formulario">
            <div class="wrap" >
                <div  class="formulario" name="formulario_registro" method="get">
                <!-- Titulo -->
                
                    <h1 class="text-primary text-center"><b>Inicio Sesión</b></h1>
                
                <br />
                
                <%-- Login --%>
                <div class="container">
                    <asp:Login ID="log_in" runat="server" CssClass="login" OnAuthenticate="Login1_Authenticate" LoginButtonText="Ingresar" PasswordLabelText="Contraseña" TextLayout="TextOnTop" TitleText="" Width="717px" UserNameLabelText="Nombre de usuario">
                        <TextBoxStyle  />
                        <LayoutTemplate>
                           <div>
					            <div class="input-group">
                                    <asp:label Id="Label1" class="label-login" runat="server" CssClass="txt" VISIBLE="false" AssociatedControlID="UserName"  ></asp:label>
                                     <label id="UserNameLabel" class="label-login" runat="server"   >Nombre de usuario</label>
                                    <asp:TextBox ID="UserName" type="text"   runat="server" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="log_in">*</asp:RequiredFieldValidator>
                                </div>
                           </div>
                            
                           <div>
					            <div class="input-group">
                                    <ASP:label id="Label2" class="label-login" CssClass="txt" runat="server" VISIBLE="false"  AssociatedControlID="Password">Contraseña</ASP:label>
                                    <label id="PasswordLabel" class="label-login" runat="server" >Contraseña</label>
                                    <asp:TextBox ID="Password" type="password"  runat="server"  TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="log_in">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            
                            <asp:CheckBox ID="RememberMe" runat="server" ForeColor="Black" Text="Recordármelo la próxima vez." />
                            
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            <div class="row">
                            <asp:Button ID="LoginButton" CssClass="submit" type="submit" runat="server" CommandName="Login"   Text="Ingresar" ValidationGroup="log_in" />
                            </div>
                        </LayoutTemplate>
                        
                    </asp:Login>
                   
                    </div>
               </div>     
            </div>
        </div>
    </form>


    
    <script src="Bootstrap/js/jquery.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
      <%--<script type="text/javascript">
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

              var focusInput = function (IdLabel, IdText) {
                  document.getElementById(IdLabel).className = "label-login active";
                  document.getElementById(IdText).className = document.getElementById(IdText).className.replace("error", "");
              };

              var blurInput = function (IdLabel,IdText) {
                  if (true) {
                      document.getElementById(IdLabel).className = "label-login";
                      document.getElementById(IdText).className = document.getElementById(IdText).className + " error";
                  }
              };

              // --- Eventos ---
              document.addEventListener("submit", enviar);
              document.getElementById("log_in_UserName").addEventListener("focus", focusInput("log_in_UserNameLabel", "log_in_UserName"));
              document.getElementById("log_in_UserName").addEventListener("blur", blurInput("log_in_UserNameLabel", "log_in_UserName"));
              document.getElementById("log_in_Password").addEventListener("focus", focusInput("log_in_PasswordLabel", "log_in_Password"));
              document.getElementById("log_in_Password").addEventListener("blur", blurInput("log_in_PasswordLabel", "log_in_Password"));
              
          }());

        </script>--%>
    <!-- Codigo js para que ande el boton btn-mostrarNav -->
    

</body>
</html>
