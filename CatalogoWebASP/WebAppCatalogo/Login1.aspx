<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="WebAppCatalogo.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <main class="auth">

            <!-- LEFT -->
            <section class="auth__left">
                <div class="auth__content">
                    <h1 class="auth__title">Welcome to website</h1>
                    <p class="auth__text">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                   
                    </p>
                </div>
            </section>

            <!-- RIGHT -->
            <section class="auth__right">
                <div class="login">
                    <h2 class="login__title">USER LOGIN</h2>

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
                        CssClass="login__button" />
                </div>
            </section>

        </main>
</asp:Content>
