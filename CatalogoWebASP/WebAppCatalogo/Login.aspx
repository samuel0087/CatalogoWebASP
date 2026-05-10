<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppCatalogo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ingresa a nuestra web</title>
        <link href="~/Content/myStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
         <main class="auth">

            <!-- LEFT -->
            <section class="auth__left">
                <div class="auth__content">
                    <h1 class="auth__title">Bienvenidos</h1>
                    <p class="auth__text">
                        Encuentra lo que buscas en nuestro catalogo de productos                   
                    </p>
                </div>
            </section>

            <!-- RIGHT -->
            <section class="auth__right">
                <div class="login">
                    <h2 class="login__title">Login de usuario</h2>

                    <div class="login__group">
                        <asp:TextBox ID="txtEmail" runat="server"
                            CssClass="login__input"
                            TextMode="Email"
                            placeholder="Email" />
                    </div>

                    <div class="login__group">
                        <asp:TextBox ID="txtPassword" runat="server"
                            CssClass="login__input"
                            TextMode="Password"
                            placeholder="Password" />
                    </div>

                    <asp:Button ID="btnLogin" runat="server"
                        Text="LOGIN"
                        CssClass="login__button"
                        OnClick="btnLogin_Click"/>
                </div>
            </section>

        </main>
    </form>
</body>
</html>
