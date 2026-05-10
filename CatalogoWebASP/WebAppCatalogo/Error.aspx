<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebAppCatalogo.Error" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Error | Catálogo</title>
    <link href="<%: ResolveUrl("~/Content/error.css") %>" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <main class="error-page">
            <section class="error-card">
                <div class="error-card__code">!</div>

                <h1 class="error-card__title">Ocurrió un error</h1>

                <asp:Label Text="" runat="server" ID="lblError" CssClass="error-card__text"/>

<%--                <p class="error-card__text">
                    No pudimos procesar la solicitud en este momento.
                    Intentá nuevamente o volvé al inicio.
                </p>--%>

                <asp:Button
                    ID="btnVolver" 
                    runat="server" 
                    Text="Volver al inicio"
                    CssClass="error-card__button"
                    OnClick="btnVolver_Click" />
            </section>
        </main>
    </form>
</body>
</html>